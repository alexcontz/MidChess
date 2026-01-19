using System;
using System.Windows.Forms;
using MidChess.game;

namespace MidChess
{
    /// <summary>
    /// Modal dialog for displaying connection progress during LAN game setup.
    /// </summary>
    public partial class ConnectionDialog : Form
    {
        #region Fields

        private LANHandler lanHandler;
        private readonly bool isHost;
        private readonly int port;
        private readonly string ipAddress;
        private readonly char hostColor;
        private bool connectionSuccessful;

        #endregion

        #region Properties

        public LANHandler LANHandler => lanHandler;
        public bool ConnectionSuccessful => connectionSuccessful;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a connection dialog for hosting a game.
        /// </summary>
        public ConnectionDialog(int port, char hostColor)
        {
            InitializeComponent();
            isHost = true;
            this.port = port;
            this.hostColor = hostColor;
            lanHandler = new LANHandler();
            SetupEventHandlers();
        }

        /// <summary>
        /// Creates a connection dialog for joining a game.
        /// </summary>
        public ConnectionDialog(string ipAddress, int port)
        {
            InitializeComponent();
            isHost = false;
            this.ipAddress = ipAddress;
            this.port = port;
            lanHandler = new LANHandler();
            SetupEventHandlers();
        }

        #endregion

        #region Initialization

        private void SetupEventHandlers()
        {
            lanHandler.OnStatusChanged += LANHandler_OnStatusChanged;
            lanHandler.OnConnectionEstablished += LANHandler_OnConnectionEstablished;
            lanHandler.OnConnectionFailed += LANHandler_OnConnectionFailed;
        }

        #endregion

        #region Event Handlers

        private async void ConnectionDialog_Load(object sender, EventArgs e)
        {
            Text = isHost ? "Hosting Game..." : "Joining Game...";

            if (isHost)
                await lanHandler.StartHostingAsync(port, hostColor);
            else
                await lanHandler.JoinGameAsync(ipAddress, port);
        }

        private void ConnectionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!connectionSuccessful)
            {
                lanHandler.Cancel();
                lanHandler.Dispose();
            }
        }

        private void CancelConnectionButton_Click(object sender, EventArgs e)
        {
            lanHandler.Cancel();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LANHandler_OnStatusChanged(object sender, string status)
        {
            InvokeOnUI(() => UpdateStatus(status));
        }

        private void LANHandler_OnConnectionEstablished(object sender, EventArgs e)
        {
            InvokeOnUI(HandleConnectionSuccess);
        }

        private void LANHandler_OnConnectionFailed(object sender, string reason)
        {
            InvokeOnUI(() => HandleConnectionFailure(reason));
        }

        #endregion

        #region Helper Methods

        private void InvokeOnUI(Action action)
        {
            if (InvokeRequired)
                Invoke(action);
            else
                action();
        }

        private void UpdateStatus(string status)
        {
            StatusLabel.Text = status;
        }

        private void HandleConnectionSuccess()
        {
            connectionSuccessful = true;
            ProgressIndicator.Style = ProgressBarStyle.Continuous;
            ProgressIndicator.Value = 100;
            StatusLabel.Text = "Connected!";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void HandleConnectionFailure(string reason)
        {
            connectionSuccessful = false;
            ProgressIndicator.Style = ProgressBarStyle.Continuous;
            ProgressIndicator.Value = 0;
            StatusLabel.Text = reason;
            CancelConnectionButton.Text = "Close";
        }

        #endregion
    }
}