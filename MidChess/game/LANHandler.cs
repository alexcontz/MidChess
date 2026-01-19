using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MidChess.game
{
    /// <summary>
    /// Handles LAN networking for chess games using TCP sockets.
    /// Server (Host) uses TcpListener, Client (Join) uses TcpClient.
    /// </summary>
    public class LANHandler : IDisposable
    {
        #region Constants

        private const int BUFFER_SIZE = 1024;
        private const string MSG_DELIMITER = "\n";

        // Message types
        public const string MSG_MOVE = "MOVE";
        public const string MSG_DRAW_OFFER = "DRAW_OFFER";
        public const string MSG_DRAW_ACCEPT = "DRAW_ACCEPT";
        public const string MSG_DRAW_DECLINE = "DRAW_DECLINE";
        public const string MSG_TAKEBACK_OFFER = "TAKEBACK_OFFER";
        public const string MSG_TAKEBACK_ACCEPT = "TAKEBACK_ACCEPT";
        public const string MSG_TAKEBACK_DECLINE = "TAKEBACK_DECLINE";
        public const string MSG_RESIGN = "RESIGN";
        public const string MSG_DISCONNECT = "DISCONNECT";
        public const string MSG_READY = "READY";

        #endregion

        #region Properties

        public bool IsHost { get; private set; }
        public bool IsConnected { get; private set; }
        public char LocalPlayerColor { get; private set; }
        public string RemoteIP { get; private set; }
        public int Port { get; private set; }

        #endregion

        #region Fields

        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private CancellationTokenSource cancellationTokenSource;
        private bool isDisposed;

        #endregion

        #region Events

        public event EventHandler<string> OnMessageReceived;
        public event EventHandler<MoveReceivedEventArgs> OnMoveReceived;
        public event EventHandler OnDrawOffered;
        public event EventHandler OnDrawAccepted;
        public event EventHandler OnDrawDeclined;
        public event EventHandler OnTakebackOffered;
        public event EventHandler OnTakebackAccepted;
        public event EventHandler OnTakebackDeclined;
        public event EventHandler OnOpponentResigned;
        public event EventHandler OnOpponentDisconnected;
        public event EventHandler OnConnectionEstablished;
        public event EventHandler<string> OnConnectionFailed;
        public event EventHandler<string> OnStatusChanged;

        #endregion

        #region Constructor

        public LANHandler()
        {
            cancellationTokenSource = new CancellationTokenSource();
        }

        #endregion

        #region Connection Methods

        /// <summary>
        /// Starts hosting a game on the specified port.
        /// </summary>
        public async Task<bool> StartHostingAsync(int port, char hostColor)
        {
            try
            {
                IsHost = true;
                Port = port;
                LocalPlayerColor = hostColor;

                RaiseStatusChanged("Starting server...");

                server = new TcpListener(IPAddress.Any, port);
                server.Start();

                RaiseStatusChanged($"Waiting for opponent on port {port}...");

                // Wait for client connection with cancellation support
                client = await WaitForClientAsync();

                if (client == null)
                {
                    RaiseConnectionFailed("Connection cancelled.");
                    return false;
                }

                stream = client.GetStream();
                RemoteIP = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                IsConnected = true;

                // Send ready message with host color info
                await SendMessageAsync($"{MSG_READY}:{LocalPlayerColor}");

                RaiseStatusChanged($"Opponent connected from {RemoteIP}");
                RaiseConnectionEstablished();

                // Start listening for messages
                StartListening();

                return true;
            }
            catch (OperationCanceledException)
            {
                RaiseConnectionFailed("Connection cancelled.");
                return false;
            }
            catch (Exception ex)
            {
                RaiseConnectionFailed($"Failed to start hosting: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Joins a hosted game at the specified IP and port.
        /// </summary>
        public async Task<bool> JoinGameAsync(string ipAddress, int port)
        {
            try
            {
                IsHost = false;
                RemoteIP = ipAddress;
                Port = port;

                RaiseStatusChanged($"Connecting to {ipAddress}:{port}...");

                client = new TcpClient();

                // Connect with timeout
                if (!await ConnectWithTimeoutAsync(ipAddress, port))
                    return false;

                stream = client.GetStream();
                IsConnected = true;

                RaiseStatusChanged("Connected! Waiting for host...");

                // Start listening for messages (will receive READY message with color info)
                StartListening();

                return true;
            }
            catch (OperationCanceledException)
            {
                RaiseConnectionFailed("Connection cancelled.");
                return false;
            }
            catch (Exception ex)
            {
                RaiseConnectionFailed($"Failed to connect: {ex.Message}");
                return false;
            }
        }

        private async Task<TcpClient> WaitForClientAsync()
        {
            return await Task.Run(() =>
            {
                while (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    if (server.Pending())
                        return server.AcceptTcpClient();
                    Thread.Sleep(100);
                }
                return null;
            }, cancellationTokenSource.Token);
        }

        private async Task<bool> ConnectWithTimeoutAsync(string ipAddress, int port)
        {
            var connectTask = client.ConnectAsync(ipAddress, port);
            var timeoutTask = Task.Delay(10000, cancellationTokenSource.Token);

            var completedTask = await Task.WhenAny(connectTask, timeoutTask);

            if (completedTask == timeoutTask)
            {
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    RaiseConnectionFailed("Connection cancelled.");
                }
                else
                {
                    RaiseConnectionFailed("Connection timed out.");
                }
                return false;
            }

            await connectTask; // Ensure any exceptions are thrown
            return true;
        }

        #endregion

        #region Message Handling

        private void StartListening()
        {
            Task.Run(async () =>
            {
                byte[] buffer = new byte[BUFFER_SIZE];
                StringBuilder messageBuilder = new StringBuilder();

                try
                {
                    while (IsConnected && !cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        if (stream.DataAvailable)
                        {
                            int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationTokenSource.Token);
                            if (bytesRead == 0)
                            {
                                HandleDisconnection();
                                break;
                            }

                            messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

                            // Process complete messages
                            ProcessCompleteMessages(messageBuilder);
                        }
                        else
                        {
                            await Task.Delay(50, cancellationTokenSource.Token);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Normal cancellation
                }
                catch (Exception)
                {
                    HandleDisconnection();
                }
            }, cancellationTokenSource.Token);
        }

        private void ProcessCompleteMessages(StringBuilder messageBuilder)
        {
            string data = messageBuilder.ToString();
            int delimiterIndex;

            while ((delimiterIndex = data.IndexOf(MSG_DELIMITER)) >= 0)
            {
                string message = data.Substring(0, delimiterIndex);
                data = data.Substring(delimiterIndex + MSG_DELIMITER.Length);
                ProcessMessage(message);
            }

            messageBuilder.Clear();
            messageBuilder.Append(data);
        }

        private void ProcessMessage(string message)
        {
            if (string.IsNullOrEmpty(message)) return;

            OnMessageReceived?.Invoke(this, message);

            string[] parts = message.Split(':');
            string messageType = parts[0];

            switch (messageType)
            {
                case MSG_READY:
                    HandleReadyMessage(parts);
                    break;
                case MSG_MOVE:
                    HandleMoveMessage(parts);
                    break;
                case MSG_DRAW_OFFER:
                    OnDrawOffered?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_DRAW_ACCEPT:
                    OnDrawAccepted?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_DRAW_DECLINE:
                    OnDrawDeclined?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_TAKEBACK_OFFER:
                    OnTakebackOffered?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_TAKEBACK_ACCEPT:
                    OnTakebackAccepted?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_TAKEBACK_DECLINE:
                    OnTakebackDeclined?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_RESIGN:
                    OnOpponentResigned?.Invoke(this, EventArgs.Empty);
                    break;
                case MSG_DISCONNECT:
                    HandleDisconnection();
                    break;
            }
        }

        private void HandleReadyMessage(string[] parts)
        {
            if (!IsHost && parts.Length > 1)
            {
                char hostColor = parts[1][0];
                LocalPlayerColor = hostColor == 'w' ? 'b' : 'w';
                RaiseConnectionEstablished();
            }
        }

        private void HandleMoveMessage(string[] parts)
        {
            if (parts.Length >= 6)
            {
                int fromX = int.Parse(parts[1]);
                int fromY = int.Parse(parts[2]);
                int toX = int.Parse(parts[3]);
                int toY = int.Parse(parts[4]);
                char promotion = parts[5][0];
                OnMoveReceived?.Invoke(this, new MoveReceivedEventArgs(fromX, fromY, toX, toY, promotion));
            }
        }

        private void HandleDisconnection()
        {
            if (!IsConnected) return;
            IsConnected = false;
            OnOpponentDisconnected?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Send Methods

        public async Task SendMessageAsync(string message)
        {
            if (!IsConnected || stream == null) return;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message + MSG_DELIMITER);
                await stream.WriteAsync(data, 0, data.Length);
                await stream.FlushAsync();
            }
            catch (Exception)
            {
                HandleDisconnection();
            }
        }

        public async Task SendMoveAsync(int fromX, int fromY, int toX, int toY, char promotion)
        {
            await SendMessageAsync($"{MSG_MOVE}:{fromX}:{fromY}:{toX}:{toY}:{promotion}");
        }

        public async Task SendDrawOfferAsync()
        {
            await SendMessageAsync(MSG_DRAW_OFFER);
        }

        public async Task SendDrawAcceptAsync()
        {
            await SendMessageAsync(MSG_DRAW_ACCEPT);
        }

        public async Task SendDrawDeclineAsync()
        {
            await SendMessageAsync(MSG_DRAW_DECLINE);
        }

        public async Task SendTakebackOfferAsync()
        {
            await SendMessageAsync(MSG_TAKEBACK_OFFER);
        }

        public async Task SendTakebackAcceptAsync()
        {
            await SendMessageAsync(MSG_TAKEBACK_ACCEPT);
        }

        public async Task SendTakebackDeclineAsync()
        {
            await SendMessageAsync(MSG_TAKEBACK_DECLINE);
        }

        public async Task SendResignAsync()
        {
            await SendMessageAsync(MSG_RESIGN);
        }

        public async Task SendDisconnectAsync()
        {
            await SendMessageAsync(MSG_DISCONNECT);
        }

        #endregion

        #region Turn Validation

        public bool IsLocalPlayerTurn(char currentTurn)
        {
            return currentTurn == LocalPlayerColor;
        }

        public bool IsLocalPlayerPiece(char pieceColor)
        {
            return pieceColor == LocalPlayerColor;
        }

        public bool CanSelectPiece(char pieceColor, char currentTurn)
        {
            return IsLocalPlayerTurn(currentTurn) && IsLocalPlayerPiece(pieceColor);
        }

        #endregion

        #region Disconnect Helpers

        public async Task ResignAndDisconnectAsync()
        {
            await SendResignAsync();
            await SendDisconnectAsync();
            Dispose();
        }

        public async Task DisconnectAsync()
        {
            await SendDisconnectAsync();
            Dispose();
        }

        #endregion

        #region Event Helpers

        private void RaiseStatusChanged(string status)
        {
            OnStatusChanged?.Invoke(this, status);
        }

        private void RaiseConnectionEstablished()
        {
            OnConnectionEstablished?.Invoke(this, EventArgs.Empty);
        }

        private void RaiseConnectionFailed(string reason)
        {
            OnConnectionFailed?.Invoke(this, reason);
        }

        #endregion

        #region Cleanup

        public void Cancel()
        {
            cancellationTokenSource?.Cancel();
        }

        public void Dispose()
        {
            if (isDisposed) return;
            isDisposed = true;

            cancellationTokenSource?.Cancel();

            try
            {
                stream?.Close();
                client?.Close();
                server?.Stop();
            }
            catch { }

            cancellationTokenSource?.Dispose();
        }

        #endregion
    }

    #region Event Args

    public class MoveReceivedEventArgs : EventArgs
    {
        public int FromX { get; }
        public int FromY { get; }
        public int ToX { get; }
        public int ToY { get; }
        public char Promotion { get; }

        public MoveReceivedEventArgs(int fromX, int fromY, int toX, int toY, char promotion)
        {
            FromX = fromX;
            FromY = fromY;
            ToX = toX;
            ToY = toY;
            Promotion = promotion;
        }
    }

    #endregion

}