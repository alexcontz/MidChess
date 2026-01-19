namespace MidChess
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.MainPanel = new MidChess.controls.BufferedTablePanel();
            this.BoardPanel = new MidChess.controls.BufferedPanel();
            this.NavigationTablePanel = new MidChess.controls.BufferedTablePanel();
            this.LeaveButton = new MidChess.controls.TransparentButton();
            this.FullscreenButton = new MidChess.controls.TransparentButton();
            this.SwitchViewButton = new MidChess.controls.TransparentButton();
            this.ExtraPanel = new MidChess.controls.BufferedTablePanel();
            this.MovesListView = new MidChess.controls.BufferedListView();
            this.MoveNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WhiteMoves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BlackMoves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonsTablePanel = new MidChess.controls.BufferedTablePanel();
            this.DrawButton = new MidChess.controls.TransparentButton();
            this.TakebackButton = new MidChess.controls.TransparentButton();
            this.ResignButton = new MidChess.controls.TransparentButton();
            this.ExportButton = new MidChess.controls.TransparentButton();
            this.MainPanel.SuspendLayout();
            this.NavigationTablePanel.SuspendLayout();
            this.ExtraPanel.SuspendLayout();
            this.ButtonsTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.Transparent;
            this.MainPanel.ColumnCount = 7;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.MainPanel.Controls.Add(this.BoardPanel, 3, 1);
            this.MainPanel.Controls.Add(this.NavigationTablePanel, 1, 1);
            this.MainPanel.Controls.Add(this.ExtraPanel, 5, 1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 3;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.MainPanel.Size = new System.Drawing.Size(838, 441);
            this.MainPanel.TabIndex = 0;
            // 
            // BoardPanel
            // 
            this.BoardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoardPanel.Location = new System.Drawing.Point(102, 22);
            this.BoardPanel.Margin = new System.Windows.Forms.Padding(0);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(419, 396);
            this.BoardPanel.TabIndex = 0;
            this.BoardPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.BoardPanel_Paint);
            this.BoardPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BoardPanel_MouseClick);
            // 
            // NavigationTablePanel
            // 
            this.NavigationTablePanel.ColumnCount = 1;
            this.NavigationTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.NavigationTablePanel.Controls.Add(this.LeaveButton, 0, 0);
            this.NavigationTablePanel.Controls.Add(this.FullscreenButton, 0, 2);
            this.NavigationTablePanel.Controls.Add(this.SwitchViewButton, 0, 4);
            this.NavigationTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTablePanel.Location = new System.Drawing.Point(20, 22);
            this.NavigationTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.NavigationTablePanel.Name = "NavigationTablePanel";
            this.NavigationTablePanel.RowCount = 6;
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.NavigationTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.NavigationTablePanel.Size = new System.Drawing.Size(62, 396);
            this.NavigationTablePanel.TabIndex = 1;
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
            this.LeaveButton.Size = new System.Drawing.Size(62, 47);
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
            this.FullscreenButton.Location = new System.Drawing.Point(0, 54);
            this.FullscreenButton.Margin = new System.Windows.Forms.Padding(0);
            this.FullscreenButton.Name = "FullscreenButton";
            this.FullscreenButton.Size = new System.Drawing.Size(62, 47);
            this.FullscreenButton.TabIndex = 1;
            this.FullscreenButton.UseVisualStyleBackColor = false;
            this.FullscreenButton.Click += new System.EventHandler(this.FullscreenButton_Click);
            // 
            // SwitchViewButton
            // 
            this.SwitchViewButton.BackColor = System.Drawing.Color.Transparent;
            this.SwitchViewButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SwitchViewButton.BackgroundImage")));
            this.SwitchViewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.SwitchViewButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SwitchViewButton.FlatAppearance.BorderSize = 0;
            this.SwitchViewButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SwitchViewButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.SwitchViewButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchViewButton.ForeColor = System.Drawing.Color.White;
            this.SwitchViewButton.Location = new System.Drawing.Point(0, 108);
            this.SwitchViewButton.Margin = new System.Windows.Forms.Padding(0);
            this.SwitchViewButton.Name = "SwitchViewButton";
            this.SwitchViewButton.Size = new System.Drawing.Size(62, 47);
            this.SwitchViewButton.TabIndex = 2;
            this.SwitchViewButton.UseVisualStyleBackColor = false;
            this.SwitchViewButton.Click += new System.EventHandler(this.SwitchViewButton_Click);
            // 
            // ExtraPanel
            // 
            this.ExtraPanel.ColumnCount = 1;
            this.ExtraPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ExtraPanel.Controls.Add(this.MovesListView, 0, 0);
            this.ExtraPanel.Controls.Add(this.ButtonsTablePanel, 0, 2);
            this.ExtraPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExtraPanel.Location = new System.Drawing.Point(562, 22);
            this.ExtraPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ExtraPanel.Name = "ExtraPanel";
            this.ExtraPanel.RowCount = 3;
            this.ExtraPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.ExtraPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.ExtraPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.ExtraPanel.Size = new System.Drawing.Size(251, 396);
            this.ExtraPanel.TabIndex = 2;
            // 
            // MovesListView
            // 
            this.MovesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.MovesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MovesListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MovesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MoveNumber,
            this.WhiteMoves,
            this.BlackMoves});
            this.MovesListView.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovesListView.ForeColor = System.Drawing.Color.White;
            this.MovesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.MovesListView.HideSelection = false;
            this.MovesListView.Location = new System.Drawing.Point(0, 0);
            this.MovesListView.Margin = new System.Windows.Forms.Padding(0);
            this.MovesListView.Name = "MovesListView";
            this.MovesListView.Size = new System.Drawing.Size(251, 297);
            this.MovesListView.TabIndex = 0;
            this.MovesListView.UseCompatibleStateImageBehavior = false;
            this.MovesListView.View = System.Windows.Forms.View.Details;
            // 
            // MoveNumber
            // 
            this.MoveNumber.Text = "#";
            this.MoveNumber.Width = 30;
            // 
            // WhiteMoves
            // 
            this.WhiteMoves.Text = "White";
            this.WhiteMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteMoves.Width = 110;
            // 
            // BlackMoves
            // 
            this.BlackMoves.Text = "Black";
            this.BlackMoves.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlackMoves.Width = 110;
            // 
            // ButtonsTablePanel
            // 
            this.ButtonsTablePanel.ColumnCount = 7;
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.ButtonsTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.ButtonsTablePanel.Controls.Add(this.DrawButton, 0, 0);
            this.ButtonsTablePanel.Controls.Add(this.TakebackButton, 2, 0);
            this.ButtonsTablePanel.Controls.Add(this.ResignButton, 4, 0);
            this.ButtonsTablePanel.Controls.Add(this.ExportButton, 6, 0);
            this.ButtonsTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsTablePanel.Location = new System.Drawing.Point(0, 316);
            this.ButtonsTablePanel.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonsTablePanel.Name = "ButtonsTablePanel";
            this.ButtonsTablePanel.RowCount = 1;
            this.ButtonsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonsTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ButtonsTablePanel.Size = new System.Drawing.Size(251, 80);
            this.ButtonsTablePanel.TabIndex = 1;
            // 
            // DrawButton
            // 
            this.DrawButton.BackColor = System.Drawing.Color.Transparent;
            this.DrawButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DrawButton.BackgroundImage")));
            this.DrawButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DrawButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawButton.FlatAppearance.BorderSize = 0;
            this.DrawButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.DrawButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DrawButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DrawButton.ForeColor = System.Drawing.Color.White;
            this.DrawButton.Location = new System.Drawing.Point(0, 0);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(0);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(55, 80);
            this.DrawButton.TabIndex = 0;
            this.DrawButton.UseVisualStyleBackColor = false;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // TakebackButton
            // 
            this.TakebackButton.BackColor = System.Drawing.Color.Transparent;
            this.TakebackButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TakebackButton.BackgroundImage")));
            this.TakebackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TakebackButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TakebackButton.FlatAppearance.BorderSize = 0;
            this.TakebackButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.TakebackButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TakebackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TakebackButton.ForeColor = System.Drawing.Color.White;
            this.TakebackButton.Location = new System.Drawing.Point(65, 0);
            this.TakebackButton.Margin = new System.Windows.Forms.Padding(0);
            this.TakebackButton.Name = "TakebackButton";
            this.TakebackButton.Size = new System.Drawing.Size(55, 80);
            this.TakebackButton.TabIndex = 1;
            this.TakebackButton.UseVisualStyleBackColor = false;
            this.TakebackButton.Click += new System.EventHandler(this.TakebackButton_Click);
            // 
            // ResignButton
            // 
            this.ResignButton.BackColor = System.Drawing.Color.Transparent;
            this.ResignButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ResignButton.BackgroundImage")));
            this.ResignButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ResignButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResignButton.FlatAppearance.BorderSize = 0;
            this.ResignButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ResignButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ResignButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResignButton.ForeColor = System.Drawing.Color.White;
            this.ResignButton.Location = new System.Drawing.Point(130, 0);
            this.ResignButton.Margin = new System.Windows.Forms.Padding(0);
            this.ResignButton.Name = "ResignButton";
            this.ResignButton.Size = new System.Drawing.Size(55, 80);
            this.ResignButton.TabIndex = 2;
            this.ResignButton.UseVisualStyleBackColor = false;
            this.ResignButton.Click += new System.EventHandler(this.ResignButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.BackColor = System.Drawing.Color.Transparent;
            this.ExportButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExportButton.BackgroundImage")));
            this.ExportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ExportButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExportButton.FlatAppearance.BorderSize = 0;
            this.ExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExportButton.ForeColor = System.Drawing.Color.White;
            this.ExportButton.Location = new System.Drawing.Point(195, 0);
            this.ExportButton.Margin = new System.Windows.Forms.Padding(0);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(56, 80);
            this.ExportButton.TabIndex = 3;
            this.ExportButton.UseVisualStyleBackColor = false;
            this.ExportButton.Click += new System.EventHandler(this.ExportButton_Click);
            // 
            // GameForm
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
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MidChess";
            this.MainPanel.ResumeLayout(false);
            this.NavigationTablePanel.ResumeLayout(false);
            this.ExtraPanel.ResumeLayout(false);
            this.ButtonsTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.BufferedTablePanel MainPanel;
        private controls.BufferedPanel BoardPanel;
        private controls.BufferedTablePanel NavigationTablePanel;
        private controls.TransparentButton LeaveButton;
        private controls.TransparentButton FullscreenButton;
        private controls.BufferedTablePanel ExtraPanel;
        private controls.BufferedListView MovesListView;
        private System.Windows.Forms.ColumnHeader MoveNumber;
        private System.Windows.Forms.ColumnHeader WhiteMoves;
        private System.Windows.Forms.ColumnHeader BlackMoves;
        private controls.BufferedTablePanel ButtonsTablePanel;
        private controls.TransparentButton DrawButton;
        private controls.TransparentButton TakebackButton;
        private controls.TransparentButton ResignButton;
        private controls.TransparentButton ExportButton;
        private controls.TransparentButton SwitchViewButton;
    }
}