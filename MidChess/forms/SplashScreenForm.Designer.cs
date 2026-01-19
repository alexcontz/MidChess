using System.Windows.Forms;
namespace MidChess
{
    partial class SplashScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashScreenForm));
            this.MainPanel = new MidChess.controls.BufferedTablePanel();
            this.TitlePanel = new MidChess.controls.BufferedTablePanel();
            this.LogoButton = new MidChess.controls.TransparentButton();
            this.IconPanel = new MidChess.controls.BufferedTablePanel();
            this.FullscreenButton = new MidChess.controls.TransparentButton();
            this.LeaveButton = new MidChess.controls.TransparentButton();
            this.ButtonPanel = new MidChess.controls.BufferedTablePanel();
            this.OfflineButton = new MidChess.controls.TransparentButton();
            this.OnlineButton = new MidChess.controls.TransparentButton();
            this.ExitButton = new MidChess.controls.TransparentButton();
            this.OfflineLabel = new System.Windows.Forms.Label();
            this.OnlineLabel = new System.Windows.Forms.Label();
            this.ExitLabel = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.IconPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MainPanel.ColumnCount = 1;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainPanel.Controls.Add(this.TitlePanel, 0, 0);
            this.MainPanel.Controls.Add(this.ButtonPanel, 0, 2);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 4;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.MainPanel.Size = new System.Drawing.Size(838, 441);
            this.MainPanel.TabIndex = 0;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TitlePanel.ColumnCount = 3;
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TitlePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.TitlePanel.Controls.Add(this.LogoButton, 1, 0);
            this.TitlePanel.Controls.Add(this.IconPanel, 0, 0);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.RowCount = 1;
            this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TitlePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.TitlePanel.Size = new System.Drawing.Size(838, 132);
            this.TitlePanel.TabIndex = 0;
            // 
            // LogoButton
            // 
            this.LogoButton.BackColor = System.Drawing.Color.Transparent;
            this.LogoButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LogoButton.BackgroundImage")));
            this.LogoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LogoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogoButton.Enabled = false;
            this.LogoButton.FlatAppearance.BorderSize = 0;
            this.LogoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LogoButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LogoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogoButton.ForeColor = System.Drawing.Color.White;
            this.LogoButton.Location = new System.Drawing.Point(125, 0);
            this.LogoButton.Margin = new System.Windows.Forms.Padding(0);
            this.LogoButton.Name = "LogoButton";
            this.LogoButton.Size = new System.Drawing.Size(586, 132);
            this.LogoButton.TabIndex = 1;
            this.LogoButton.UseVisualStyleBackColor = false;
            // 
            // IconPanel
            // 
            this.IconPanel.AutoSize = true;
            this.IconPanel.ColumnCount = 1;
            this.IconPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.IconPanel.Controls.Add(this.FullscreenButton, 0, 3);
            this.IconPanel.Controls.Add(this.LeaveButton, 0, 1);
            this.IconPanel.Location = new System.Drawing.Point(0, 0);
            this.IconPanel.Margin = new System.Windows.Forms.Padding(0);
            this.IconPanel.Name = "IconPanel";
            this.IconPanel.RowCount = 4;
            this.IconPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.IconPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.IconPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.IconPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.IconPanel.Size = new System.Drawing.Size(75, 132);
            this.IconPanel.TabIndex = 2;
            // 
            // FullscreenButton
            // 
            this.FullscreenButton.BackColor = System.Drawing.Color.Transparent;
            this.FullscreenButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FullscreenButton.BackgroundImage")));
            this.FullscreenButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.FullscreenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullscreenButton.FlatAppearance.BorderSize = 0;
            this.FullscreenButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.FullscreenButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FullscreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FullscreenButton.ForeColor = System.Drawing.Color.White;
            this.FullscreenButton.Location = new System.Drawing.Point(0, 71);
            this.FullscreenButton.Margin = new System.Windows.Forms.Padding(0);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(75, 61);
            this.FullscreenButton.TabIndex = 0;
            this.FullscreenButton.UseVisualStyleBackColor = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullScreenButton_Click);
            // 
            // LeaveButton
            // 
            this.LeaveButton.BackColor = System.Drawing.Color.Transparent;
            this.LeaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LeaveButton.BackgroundImage")));
            this.LeaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LeaveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeaveButton.FlatAppearance.BorderSize = 0;
            this.LeaveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LeaveButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.LeaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeaveButton.ForeColor = System.Drawing.Color.White;
            this.LeaveButton.Location = new System.Drawing.Point(0, 6);
            this.LeaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(75, 59);
            this.LeaveButton.TabIndex = 1;
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.ColumnCount = 7;
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.34F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33F));
            this.ButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.ButtonPanel.Controls.Add(this.OfflineButton, 1, 0);
            this.ButtonPanel.Controls.Add(this.OnlineButton, 3, 0);
            this.ButtonPanel.Controls.Add(this.ExitButton, 5, 0);
            this.ButtonPanel.Controls.Add(this.OfflineLabel, 1, 1);
            this.ButtonPanel.Controls.Add(this.OnlineLabel, 3, 1);
            this.ButtonPanel.Controls.Add(this.ExitLabel, 5, 1);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 189);
            this.ButtonPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.RowCount = 2;
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.ButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ButtonPanel.Size = new System.Drawing.Size(838, 198);
            this.ButtonPanel.TabIndex = 1;
            // 
            // OfflineButton
            // 
            this.OfflineButton.BackColor = System.Drawing.Color.Transparent;
            this.OfflineButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OfflineButton.BackgroundImage")));
            this.OfflineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OfflineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OfflineButton.FlatAppearance.BorderSize = 0;
            this.OfflineButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.OfflineButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OfflineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OfflineButton.ForeColor = System.Drawing.Color.White;
            this.OfflineButton.Location = new System.Drawing.Point(83, 0);
            this.OfflineButton.Margin = new System.Windows.Forms.Padding(0);
            this.OfflineButton.Name = "OfflineButton";
            this.OfflineButton.Size = new System.Drawing.Size(195, 158);
            this.OfflineButton.TabIndex = 0;
            this.OfflineButton.UseVisualStyleBackColor = false;
            this.OfflineButton.Click += new System.EventHandler(this.OfflineButton_Click);
            // 
            // OnlineButton
            // 
            this.OnlineButton.BackColor = System.Drawing.Color.Transparent;
            this.OnlineButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OnlineButton.BackgroundImage")));
            this.OnlineButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OnlineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OnlineButton.FlatAppearance.BorderSize = 0;
            this.OnlineButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.OnlineButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.OnlineButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OnlineButton.ForeColor = System.Drawing.Color.White;
            this.OnlineButton.Location = new System.Drawing.Point(319, 0);
            this.OnlineButton.Margin = new System.Windows.Forms.Padding(0);
            this.OnlineButton.Name = "OnlineButton";
            this.OnlineButton.Size = new System.Drawing.Size(195, 158);
            this.OnlineButton.TabIndex = 1;
            this.OnlineButton.UseVisualStyleBackColor = false;
            this.OnlineButton.Click += new System.EventHandler(this.OnlineButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitButton.BackgroundImage")));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(555, 0);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(195, 158);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OfflineLabel
            // 
            this.OfflineLabel.AutoSize = true;
            this.OfflineLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OfflineLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.OfflineLabel.ForeColor = System.Drawing.Color.White;
            this.OfflineLabel.Location = new System.Drawing.Point(83, 158);
            this.OfflineLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OfflineLabel.Name = "OfflineLabel";
            this.OfflineLabel.Size = new System.Drawing.Size(195, 40);
            this.OfflineLabel.TabIndex = 3;
            this.OfflineLabel.Text = "OFFLINE";
            this.OfflineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OnlineLabel
            // 
            this.OnlineLabel.AutoSize = true;
            this.OnlineLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OnlineLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.OnlineLabel.ForeColor = System.Drawing.Color.White;
            this.OnlineLabel.Location = new System.Drawing.Point(319, 158);
            this.OnlineLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OnlineLabel.Name = "OnlineLabel";
            this.OnlineLabel.Size = new System.Drawing.Size(195, 38);
            this.OnlineLabel.TabIndex = 4;
            this.OnlineLabel.Text = "ONLINE";
            this.OnlineLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ExitLabel
            // 
            this.ExitLabel.AutoSize = true;
            this.ExitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExitLabel.Font = new System.Drawing.Font("Comic Sans MS", 20.25F);
            this.ExitLabel.Location = new System.Drawing.Point(555, 158);
            this.ExitLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ExitLabel.Name = "ExitLabel";
            this.ExitLabel.Size = new System.Drawing.Size(195, 40);
            this.ExitLabel.TabIndex = 5;
            this.ExitLabel.Text = "EXIT";
            this.ExitLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SplashScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "SplashScreenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "MidChess";
            this.MainPanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.TitlePanel.PerformLayout();
            this.IconPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private controls.BufferedTablePanel MainPanel;
        private controls.BufferedTablePanel TitlePanel;
        private controls.TransparentButton LogoButton;
        private controls.BufferedTablePanel ButtonPanel;
        private controls.TransparentButton OfflineButton;
        private controls.TransparentButton OnlineButton;
        private controls.TransparentButton ExitButton;
        private Label OfflineLabel;
        private Label OnlineLabel;
        private Label ExitLabel;
        private controls.TransparentButton FullscreenButton;
        private controls.BufferedTablePanel IconPanel;
        private controls.TransparentButton LeaveButton;
    }
}

