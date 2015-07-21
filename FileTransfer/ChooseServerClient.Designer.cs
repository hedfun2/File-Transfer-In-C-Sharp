namespace FileTransfer
{
    partial class ChooseServerClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseServerClient));
            this.areYouLabel = new System.Windows.Forms.Label();
            this.serverButton = new System.Windows.Forms.Button();
            this.clientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // areYouLabel
            // 
            this.areYouLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.areYouLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areYouLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.areYouLabel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.areYouLabel.Location = new System.Drawing.Point(12, 9);
            this.areYouLabel.Name = "areYouLabel";
            this.areYouLabel.Size = new System.Drawing.Size(409, 61);
            this.areYouLabel.TabIndex = 0;
            this.areYouLabel.Text = "Are You?";
            this.areYouLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serverButton
            // 
            this.serverButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.serverButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.serverButton.FlatAppearance.BorderSize = 0;
            this.serverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.serverButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.serverButton.Location = new System.Drawing.Point(76, 79);
            this.serverButton.Name = "serverButton";
            this.serverButton.Size = new System.Drawing.Size(95, 46);
            this.serverButton.TabIndex = 1;
            this.serverButton.Text = "Server";
            this.serverButton.UseVisualStyleBackColor = false;
            this.serverButton.Click += new System.EventHandler(this.serverButton_Click);
            // 
            // clientButton
            // 
            this.clientButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clientButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.clientButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.clientButton.FlatAppearance.BorderSize = 0;
            this.clientButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clientButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.clientButton.Location = new System.Drawing.Point(262, 79);
            this.clientButton.Name = "clientButton";
            this.clientButton.Size = new System.Drawing.Size(95, 46);
            this.clientButton.TabIndex = 2;
            this.clientButton.Text = "Client";
            this.clientButton.UseVisualStyleBackColor = false;
            this.clientButton.Click += new System.EventHandler(this.clientButton_Click);
            // 
            // ChooseServerClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(433, 170);
            this.Controls.Add(this.clientButton);
            this.Controls.Add(this.serverButton);
            this.Controls.Add(this.areYouLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChooseServerClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label areYouLabel;
        private System.Windows.Forms.Button serverButton;
        private System.Windows.Forms.Button clientButton;
    }
}