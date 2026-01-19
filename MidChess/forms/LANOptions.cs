using System;
using System.Windows.Forms;
using MidChess.game;
using MidChess.lib;

namespace MidChess
{
    public partial class LANOptions : Form
    {
        #region Fields

        public bool isFullscreen;

        private bool toSplash;
        private FormLib formLib;
        private LANLib lanLib;
        private SplashScreenForm splashScreen;

        #endregion

        #region Constructor

        public LANOptions(SplashScreenForm parent)
        {
            // Initialize libraries before component due to its use at OnResize at form initialization
            formLib = new FormLib();
            lanLib = new LANLib();
            InitializeComponent();

            // Initialize variables
            splashScreen = parent;
            toSplash = true;

            // Keep parent form fullscreen state
            if(splashScreen.isFullscreen)
                formLib.ToggleFullscreen(this, ref isFullscreen);

            // Capture initial TextBox states for scaling
            formLib.CaptureTextBoxStates(this);
            Show();
        }

        #endregion

        #region Form Events

        protected override void OnResize(EventArgs e)
        {
            formLib.ApplyAll(this);
            formLib.ScaleTextBoxes(this);
            base.OnResize(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (formLib.ProcessFullscreenKeys(this, keyData, ref isFullscreen))
                formLib.ToggleFullscreen(this, ref isFullscreen);
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Confirm return to splash screen
                if (toSplash)
                {
                    DialogResult result = MessageBox.Show("Return to main menu?", "MidChess",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }

                    splashScreen.Show();

                    // Synchronize fullscreen state with splash screen
                    if (isFullscreen != splashScreen.isFullscreen)
                        formLib.ToggleFullscreen(splashScreen, ref splashScreen.isFullscreen);
                }
                else
                    splashScreen.isFullscreen = isFullscreen;

            }

            base.OnFormClosing(e);
        }

        #endregion

        #region Button Event Handlers

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FullscreenButton_Click(object sender, EventArgs e)
        {
            formLib.ToggleFullscreen(this, ref isFullscreen);
        }

        private void HostButton_Click(object sender, EventArgs e)
        {
            // Validate starting color
            if (!lanLib.ValidateStartingColor(WhiteRadioButton.Checked, BlackRadioButton.Checked,
                out string startingAs, out string colorError))
            {
                ShowValidationError(colorError);
                return;
            }

            // Validate port
            if (!ValidateAndGetPort(PortHostMaskedTextBox.Text, out int port))
                return;

            // Start hosting
            char hostColor = WhiteRadioButton.Checked ? 'w' : 'b';
            ConnectionDialog connectionDialog = new ConnectionDialog(port, hostColor);
            HandleConnectionDialog(connectionDialog);
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            // Validate IP address
            if (!lanLib.ValidateIPAddress(IPMaskedTextBox.Text, out string ipAddress, out string ipError))
            {
                ShowValidationError(ipError);
                return;
            }

            // Validate port
            if (!ValidateAndGetPort(PortJoinMaskedTextBox.Text, out int port))
                return;

            // Start joining
            ConnectionDialog connectionDialog = new ConnectionDialog(ipAddress, port);
            HandleConnectionDialog(connectionDialog);
        }

        #endregion

        #region Validation Methods

        private bool ValidateAndGetPort(string portText, out int port)
        {
            if (!lanLib.ValidatePort(portText, out port, out string portError))
            {
                ShowValidationError(portError);
                return false;
            }
            return true;
        }

        private void ShowValidationError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

        #region Connection Handling

        private void HandleConnectionDialog(ConnectionDialog connectionDialog)
        {
            using (connectionDialog)
            {
                DialogResult result = connectionDialog.ShowDialog(this);

                if (result == DialogResult.OK && connectionDialog.ConnectionSuccessful)
                    LaunchGameForm(connectionDialog.LANHandler);
            }
        }

        private void LaunchGameForm(LANHandler lanHandler)
        {
            // Store fullscreen state into splash screen before closing
            splashScreen.isFullscreen = isFullscreen;

            GameForm gameForm = new GameForm(splashScreen, lanHandler);
                
            toSplash = false;
            Close();
        }

        #endregion
    }
}