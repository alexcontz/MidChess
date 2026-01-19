namespace MidChess
{
    partial class LANOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LANOptions));
            this.MainPanel = new MidChess.controls.BufferedTablePanel();
            this.NavigationTablePanel = new MidChess.controls.BufferedTablePanel();
            this.LeaveButton = new MidChess.controls.TransparentButton();
            this.FullscreenButton = new MidChess.controls.TransparentButton();
            this.JoinTablePanel = new MidChess.controls.BufferedTablePanel();
            this.IPMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.JoinLabel = new System.Windows.Forms.Label();
            this.JoinButton = new MidChess.controls.TransparentButton();
            this.PortJoinMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.HostTablePanel = new MidChess.controls.BufferedTablePanel();
            this.PortHostMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortHostLabel = new System.Windows.Forms.Label();
            this.StartingAsLabel = new System.Windows.Forms.Label();
            this.RadioTablePanel = new MidChess.controls.BufferedTablePanel();
            this.BlackRadioButton = new System.Windows.Forms.RadioButton();
            this.WhiteRadioButton = new System.Windows.Forms.RadioButton();
            this.HostButton = new MidChess.controls.TransparentButton();
            this.MainPanel.SuspendLayout();
            this.NavigationTablePanel.SuspendLayout();
            this.JoinTablePanel.SuspendLayout();
            this.HostTablePanel.SuspendLayout();
            this.RadioTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.ColumnCount = 7;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.Controls.Add(this.NavigationTablePanel, 1, 1);
            this.MainPanel.Controls.Add(this.JoinTablePanel, 3, 1);
            this.MainPanel.Controls.Add(this.HostTablePanel, 5, 1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 3;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.Size = new System.Drawing.Size(838, 441);
            this.MainPanel.TabIndex = 0;
            // 
            // NavigationTablePanel
            // 
            this.NavigationTablePanel.ColumnCount = 1;
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.Controls.Add(this.LeaveButton, 0, 0);
            this.NavigationTablePanel.Controls.Add(this.FullscreenButton, 0, 2);
            this.NavigationTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTablePanel.Location = new System.Drawing.Point(20, 11);
            this.NavigationTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationTablePanel.Name = "NavigationTablePanel";
            this.NavigationTablePanel.RowCount = 5;
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.NavigationTablePanel.Size = new System.Drawing.Size(62, 418);
            this.NavigationTablePanel.TabIndex = 0;
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
            this.LeaveButton.Location = new System.Drawing.Point(0, 0);
            this.LeaveButton.Margin = new System.Windows.Forms.Padding(0);
            this.LeaveButton.Name = "LeaveButton";
            this.LeaveButton.Size = new System.Drawing.Size(62, 62);
            this.LeaveButton.TabIndex = 0;
            this.LeaveButton.UseVisualStyleBackColor = false;
            this.LeaveButton.Click += new System.EventHandler(this.LeaveButton_Click);
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
            this.FullscreenButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.FullscreenButton.Location = new System.Drawing.Point(0, 72);
            this.FullscreenButton.Margin = new System.Windows.Forms.Padding(0);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(62, 62);
            this.FullscreenButton.TabIndex = 1;
            this.FullscreenButton.UseVisualStyleBackColor = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullscreenButton_Click);
            // 
            // JoinTablePanel
            // 
            this.JoinTablePanel.ColumnCount = 3;
            this.JoinTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.JoinTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.JoinTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.JoinTablePanel.Controls.Add(this.IPMaskedTextBox, 1, 1);
            this.JoinTablePanel.Controls.Add(this.IPLabel, 0, 1);
            this.JoinTablePanel.Controls.Add(this.PortLabel, 0, 3);
            this.JoinTablePanel.Controls.Add(this.JoinLabel, 1, 0);
            this.JoinTablePanel.Controls.Add(this.JoinButton, 1, 5);
            this.JoinTablePanel.Controls.Add(this.PortJoinMaskedTextBox, 1, 3);
            this.JoinTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JoinTablePanel.Location = new System.Drawing.Point(102, 11);
            this.JoinTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.JoinTablePanel.Name = "JoinTablePanel";
            this.JoinTablePanel.RowCount = 7;
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.JoinTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.JoinTablePanel.Size = new System.Drawing.Size(335, 418);
            this.JoinTablePanel.TabIndex = 1;
            // 
            // IPMaskedTextBox
            // 
            this.IPMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.IPMaskedTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.IPMaskedTextBox.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPMaskedTextBox.Location = new System.Drawing.Point(79, 93);
            this.IPMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.IPMaskedTextBox.Mask = "###.###.###.###";
            this.IPMaskedTextBox.Name = "IPMaskedTextBox";
            this.IPMaskedTextBox.Size = new System.Drawing.Size(210, 41);
            this.IPMaskedTextBox.TabIndex = 0;
            this.IPMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.IPLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPLabel.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPLabel.Location = new System.Drawing.Point(0, 83);
            this.IPLabel.Margin = new System.Windows.Forms.Padding(0);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(67, 62);
            this.IPLabel.TabIndex = 1;
            this.IPLabel.Text = "IP";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.Location = new System.Drawing.Point(0, 165);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(67, 62);
            this.PortLabel.TabIndex = 2;
            this.PortLabel.Text = "Port";
            this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JoinLabel
            // 
            this.JoinLabel.AutoSize = true;
            this.JoinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JoinLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinLabel.Location = new System.Drawing.Point(67, 0);
            this.JoinLabel.Margin = new System.Windows.Forms.Padding(0);
            this.JoinLabel.Name = "JoinLabel";
            this.JoinLabel.Size = new System.Drawing.Size(234, 83);
            this.JoinLabel.TabIndex = 5;
            this.JoinLabel.Text = "Join Options";
            this.JoinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JoinButton
            // 
            this.JoinButton.BackColor = System.Drawing.SystemColors.Info;
            this.JoinButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JoinButton.FlatAppearance.BorderSize = 0;
            this.JoinButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.JoinButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.JoinButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.JoinButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JoinButton.ForeColor = System.Drawing.Color.Black;
            this.JoinButton.Location = new System.Drawing.Point(67, 268);
            this.JoinButton.Margin = new System.Windows.Forms.Padding(0);
            this.JoinButton.Name = "JoinButton";
            this.JoinButton.Size = new System.Drawing.Size(234, 62);
            this.JoinButton.TabIndex = 6;
            this.JoinButton.Text = "Join Game";
            this.JoinButton.UseVisualStyleBackColor = false;
            this.JoinButton.Click += new System.EventHandler(this.JoinButton_Click);
            // 
            // PortJoinMaskedTextBox
            // 
            this.PortJoinMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PortJoinMaskedTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PortJoinMaskedTextBox.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortJoinMaskedTextBox.Location = new System.Drawing.Point(79, 175);
            this.PortJoinMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PortJoinMaskedTextBox.Name = "PortJoinMaskedTextBox";
            this.PortJoinMaskedTextBox.Size = new System.Drawing.Size(210, 41);
            this.PortJoinMaskedTextBox.TabIndex = 8;
            this.PortJoinMaskedTextBox.Text = "3000";
            this.PortJoinMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HostTablePanel
            // 
            this.HostTablePanel.ColumnCount = 3;
            this.HostTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.HostTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.HostTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.HostTablePanel.Controls.Add(this.PortHostMaskedTextBox, 1, 1);
            this.HostTablePanel.Controls.Add(this.HostLabel, 1, 0);
            this.HostTablePanel.Controls.Add(this.PortHostLabel, 0, 1);
            this.HostTablePanel.Controls.Add(this.StartingAsLabel, 0, 3);
            this.HostTablePanel.Controls.Add(this.RadioTablePanel, 1, 3);
            this.HostTablePanel.Controls.Add(this.HostButton, 1, 5);
            this.HostTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostTablePanel.Location = new System.Drawing.Point(478, 11);
            this.HostTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.HostTablePanel.Name = "HostTablePanel";
            this.HostTablePanel.RowCount = 7;
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.HostTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.HostTablePanel.Size = new System.Drawing.Size(335, 418);
            this.HostTablePanel.TabIndex = 2;
            // 
            // PortHostMaskedTextBox
            // 
            this.PortHostMaskedTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PortHostMaskedTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.PortHostMaskedTextBox.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortHostMaskedTextBox.Location = new System.Drawing.Point(79, 93);
            this.PortHostMaskedTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.PortHostMaskedTextBox.Name = "PortHostMaskedTextBox";
            this.PortHostMaskedTextBox.Size = new System.Drawing.Size(210, 41);
            this.PortHostMaskedTextBox.TabIndex = 7;
            this.PortHostMaskedTextBox.Text = "3000";
            this.PortHostMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostLabel.Location = new System.Drawing.Point(67, 0);
            this.HostLabel.Margin = new System.Windows.Forms.Padding(0);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(234, 83);
            this.HostLabel.TabIndex = 0;
            this.HostLabel.Text = "Host Options";
            this.HostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PortHostLabel
            // 
            this.PortHostLabel.AutoSize = true;
            this.PortHostLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortHostLabel.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortHostLabel.Location = new System.Drawing.Point(0, 83);
            this.PortHostLabel.Margin = new System.Windows.Forms.Padding(0);
            this.PortHostLabel.Name = "PortHostLabel";
            this.PortHostLabel.Size = new System.Drawing.Size(67, 62);
            this.PortHostLabel.TabIndex = 2;
            this.PortHostLabel.Text = "Port";
            this.PortHostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartingAsLabel
            // 
            this.StartingAsLabel.AutoSize = true;
            this.StartingAsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartingAsLabel.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartingAsLabel.Location = new System.Drawing.Point(0, 165);
            this.StartingAsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StartingAsLabel.Name = "StartingAsLabel";
            this.StartingAsLabel.Size = new System.Drawing.Size(67, 62);
            this.StartingAsLabel.TabIndex = 3;
            this.StartingAsLabel.Text = "Start As:";
            this.StartingAsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RadioTablePanel
            // 
            this.RadioTablePanel.ColumnCount = 2;
            this.RadioTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RadioTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.RadioTablePanel.Controls.Add(this.BlackRadioButton, 1, 0);
            this.RadioTablePanel.Controls.Add(this.WhiteRadioButton, 0, 0);
            this.RadioTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioTablePanel.Location = new System.Drawing.Point(67, 165);
            this.RadioTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.RadioTablePanel.Name = "RadioTablePanel";
            this.RadioTablePanel.RowCount = 1;
            this.RadioTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.RadioTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.RadioTablePanel.Size = new System.Drawing.Size(234, 62);
            this.RadioTablePanel.TabIndex = 8;
            // 
            // BlackRadioButton
            // 
            this.BlackRadioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BlackRadioButton.AutoSize = true;
            this.BlackRadioButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackRadioButton.Location = new System.Drawing.Point(133, 14);
            this.BlackRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.BlackRadioButton.Name = "BlackRadioButton";
            this.BlackRadioButton.Size = new System.Drawing.Size(84, 33);
            this.BlackRadioButton.TabIndex = 1;
            this.BlackRadioButton.Text = "Black";
            this.BlackRadioButton.UseVisualStyleBackColor = true;
            // 
            // WhiteRadioButton
            // 
            this.WhiteRadioButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.WhiteRadioButton.AutoSize = true;
            this.WhiteRadioButton.Checked = true;
            this.WhiteRadioButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteRadioButton.Location = new System.Drawing.Point(13, 14);
            this.WhiteRadioButton.Margin = new System.Windows.Forms.Padding(0);
            this.WhiteRadioButton.Name = "WhiteRadioButton";
            this.WhiteRadioButton.Size = new System.Drawing.Size(90, 33);
            this.WhiteRadioButton.TabIndex = 0;
            this.WhiteRadioButton.TabStop = true;
            this.WhiteRadioButton.Text = "White";
            this.WhiteRadioButton.UseVisualStyleBackColor = true;
            // 
            // HostButton
            // 
            this.HostButton.BackColor = System.Drawing.SystemColors.Info;
            this.HostButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HostButton.FlatAppearance.BorderSize = 0;
            this.HostButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.HostButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HostButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HostButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HostButton.ForeColor = System.Drawing.Color.Black;
            this.HostButton.Location = new System.Drawing.Point(67, 268);
            this.HostButton.Margin = new System.Windows.Forms.Padding(0);
            this.HostButton.Name = "HostButton";
            this.HostButton.Size = new System.Drawing.Size(234, 62);
            this.HostButton.TabIndex = 9;
            this.HostButton.Text = "Start Hosting";
            this.HostButton.UseVisualStyleBackColor = false;
            this.HostButton.Click += new System.EventHandler(this.HostButton_Click);
            // 
            // LANOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 441);
            this.Controls.Add(this.MainPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "LANOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MidChess";
            this.MainPanel.ResumeLayout(false);
            this.NavigationTablePanel.ResumeLayout(false);
            this.JoinTablePanel.ResumeLayout(false);
            this.JoinTablePanel.PerformLayout();
            this.HostTablePanel.ResumeLayout(false);
            this.HostTablePanel.PerformLayout();
            this.RadioTablePanel.ResumeLayout(false);
            this.RadioTablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private controls.BufferedTablePanel MainPanel;
        private controls.BufferedTablePanel NavigationTablePanel;
        private controls.TransparentButton LeaveButton;
        private controls.TransparentButton FullscreenButton;
        private controls.BufferedTablePanel JoinTablePanel;
        private System.Windows.Forms.MaskedTextBox IPMaskedTextBox;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label JoinLabel;
        private controls.TransparentButton JoinButton;
        private controls.BufferedTablePanel HostTablePanel;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label PortHostLabel;
        private System.Windows.Forms.Label StartingAsLabel;
        private System.Windows.Forms.MaskedTextBox PortHostMaskedTextBox;
        private controls.BufferedTablePanel RadioTablePanel;
        private System.Windows.Forms.RadioButton BlackRadioButton;
        private System.Windows.Forms.RadioButton WhiteRadioButton;
        private controls.TransparentButton HostButton;
        private System.Windows.Forms.MaskedTextBox PortJoinMaskedTextBox;
    }
}
