namespace MidChess
{
    partial class ConnectionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectionDialog));
            this.StatusLabel = new System.Windows.Forms.Label();
            this.CancelConnectionButton = new System.Windows.Forms.Button();
            this.ProgressIndicator = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // StatusLabel
            // 
            this.StatusLabel.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.Location = new System.Drawing.Point(20, 30);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(360, 60);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Initializing...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelConnectionButton
            // 
            this.CancelConnectionButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelConnectionButton.Location = new System.Drawing.Point(125, 145);
            this.CancelConnectionButton.Name = "CancelConnectionButton";
            this.CancelConnectionButton.Size = new System.Drawing.Size(150, 40);
            this.CancelConnectionButton.TabIndex = 1;
            this.CancelConnectionButton.Text = "Cancel";
            this.CancelConnectionButton.UseVisualStyleBackColor = true;
            this.CancelConnectionButton.Click += new System.EventHandler(this.CancelConnectionButton_Click);
            // 
            // ProgressIndicator
            // 
            this.ProgressIndicator.Location = new System.Drawing.Point(50, 100);
            this.ProgressIndicator.MarqueeAnimationSpeed = 30;
            this.ProgressIndicator.Name = "ProgressIndicator";
            this.ProgressIndicator.Size = new System.Drawing.Size(300, 25);
            this.ProgressIndicator.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressIndicator.TabIndex = 2;
            // 
            // ConnectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.ProgressIndicator);
            this.Controls.Add(this.CancelConnectionButton);
            this.Controls.Add(this.StatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnectionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connecting...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnectionDialog_FormClosing);
            this.Load += new System.EventHandler(this.ConnectionDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Button CancelConnectionButton;
        private System.Windows.Forms.ProgressBar ProgressIndicator;
    }
}
