namespace FileTransfer
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.chooseFilesButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.clearQueueButton = new System.Windows.Forms.Button();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.selectedFIleSizeLabel = new System.Windows.Forms.Label();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.sendButton = new System.Windows.Forms.Button();
            this.fileSizeLabel = new System.Windows.Forms.Label();
            this.userConsole = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // chooseFilesButton
            // 
            this.chooseFilesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.chooseFilesButton.FlatAppearance.BorderSize = 0;
            this.chooseFilesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseFilesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseFilesButton.Location = new System.Drawing.Point(12, 190);
            this.chooseFilesButton.Name = "chooseFilesButton";
            this.chooseFilesButton.Size = new System.Drawing.Size(224, 43);
            this.chooseFilesButton.TabIndex = 0;
            this.chooseFilesButton.Text = "Choose File(s) To Send";
            this.chooseFilesButton.UseVisualStyleBackColor = false;
            this.chooseFilesButton.Click += new System.EventHandler(this.chooseFilesButton_Click);
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.browseButton.FlatAppearance.BorderSize = 0;
            this.browseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(434, 86);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(125, 31);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // clearQueueButton
            // 
            this.clearQueueButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.clearQueueButton.FlatAppearance.BorderSize = 0;
            this.clearQueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearQueueButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearQueueButton.Location = new System.Drawing.Point(242, 190);
            this.clearQueueButton.Name = "clearQueueButton";
            this.clearQueueButton.Size = new System.Drawing.Size(193, 43);
            this.clearQueueButton.TabIndex = 2;
            this.clearQueueButton.Text = "Clear Send Queue";
            this.clearQueueButton.UseVisualStyleBackColor = false;
            this.clearQueueButton.Click += new System.EventHandler(this.clearQueueButton_Click);
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Location = new System.Drawing.Point(12, 88);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(126, 25);
            this.DestinationLabel.TabIndex = 3;
            this.DestinationLabel.Text = "Destination:";
            // 
            // selectedFIleSizeLabel
            // 
            this.selectedFIleSizeLabel.AutoSize = true;
            this.selectedFIleSizeLabel.Location = new System.Drawing.Point(13, 150);
            this.selectedFIleSizeLabel.Name = "selectedFIleSizeLabel";
            this.selectedFIleSizeLabel.Size = new System.Drawing.Size(202, 25);
            this.selectedFIleSizeLabel.TabIndex = 4;
            this.selectedFIleSizeLabel.Text = "Selected Files Size:";
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.destinationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destinationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.destinationTextBox.Location = new System.Drawing.Point(144, 92);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(284, 21);
            this.destinationTextBox.TabIndex = 5;
            // 
            // connectedLabel
            // 
            this.connectedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedLabel.Location = new System.Drawing.Point(12, 9);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(592, 61);
            this.connectedLabel.TabIndex = 6;
            this.connectedLabel.Text = "Not Connected To Anyone";
            this.connectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.sendButton.FlatAppearance.BorderSize = 0;
            this.sendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendButton.Location = new System.Drawing.Point(441, 190);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(118, 43);
            this.sendButton.TabIndex = 7;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = false;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // fileSizeLabel
            // 
            this.fileSizeLabel.AutoSize = true;
            this.fileSizeLabel.Location = new System.Drawing.Point(221, 150);
            this.fileSizeLabel.Name = "fileSizeLabel";
            this.fileSizeLabel.Size = new System.Drawing.Size(84, 25);
            this.fileSizeLabel.TabIndex = 8;
            this.fileSizeLabel.Text = "0 Bytes";
            // 
            // userConsole
            // 
            this.userConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.userConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.userConsole.Location = new System.Drawing.Point(12, 239);
            this.userConsole.Name = "userConsole";
            this.userConsole.ReadOnly = true;
            this.userConsole.Size = new System.Drawing.Size(547, 97);
            this.userConsole.TabIndex = 9;
            this.userConsole.Text = "";
            this.userConsole.TextChanged += new System.EventHandler(this.userConsole_TextChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(568, 348);
            this.Controls.Add(this.userConsole);
            this.Controls.Add(this.fileSizeLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.connectedLabel);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(this.selectedFIleSizeLabel);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.clearQueueButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.chooseFilesButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseFilesButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button clearQueueButton;
        private System.Windows.Forms.Label DestinationLabel;
        private System.Windows.Forms.Label selectedFIleSizeLabel;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.Label connectedLabel;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label fileSizeLabel;
        private System.Windows.Forms.RichTextBox userConsole;

    }
}

