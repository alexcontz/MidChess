using System;
using System.Windows.Forms;
using MidChess.lib;

namespace MidChess
{
    public partial class SplashScreenForm : Form
    {
        public bool isFullscreen = false;
        private FormLib formLib;

        public SplashScreenForm()
        {
            // Initialize libraries before component due to its use at OnResize at form initialization
            formLib = new FormLib();
            InitializeComponent();
        }

        #region Form Events

        protected override void OnResize(EventArgs e)
        {
            formLib.ApplyAll(this);
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
            if (e.CloseReason == CloseReason.UserClosing && !formLib.ConfirmExit())
                    e.Cancel = true;
            base.OnFormClosing(e);
        }

        #endregion

        #region Button Events

        private void LeaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FullScreenButton_Click(object sender, EventArgs e)
        {
            formLib.ToggleFullscreen(this, ref isFullscreen);
        }

        private void OnlineButton_Click(object sender, EventArgs e)
        {
            LANOptions lanOptions = new LANOptions(this);
            Hide();
        }

        private void OfflineButton_Click(object sender, EventArgs e)
        {
            GameForm game = new GameForm(this);
            Hide();    
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion

    }
}