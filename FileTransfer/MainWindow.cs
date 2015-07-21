using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class MainWindow : Form
    {

        Server server;
        delegate void SetTextCallback(string text);
        delegate void SetEnabledCallback(Boolean enabled);
        delegate void setFileSizeLabelCallback(String text);
        delegate void updateUserConsoleTextCallback(String message);

        public MainWindow()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(closed);
            destinationTextBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        public void giveServer(Server server)
        {
            this.server = server;
        }

        public void setConnectedText(string text)
        {
            if (this.connectedLabel.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setConnectedText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.connectedLabel.Text = text;
            }
        }

        public void setEnabled(Boolean enabled)
        {
            if (this.InvokeRequired)
            {
                SetEnabledCallback d = new SetEnabledCallback(setEnabled);
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.Enabled = enabled;
            }
        }

        public void setFileSizeLabel(String text)
        {
            if (this.fileSizeLabel.InvokeRequired)
            {
                setFileSizeLabelCallback d = new setFileSizeLabelCallback(setFileSizeLabel);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.fileSizeLabel.Text = text;
            }
        }

        public void sendMessageToUser(String message)
        {
            int length = -1;
            if (userConsole.InvokeRequired)
            {
                try
                {
                    userConsole.Invoke(new MethodInvoker(delegate { length = userConsole.Text.Length; }));
                }
                catch (ObjectDisposedException e)
                {

                }
            }
            else
            {
                length = userConsole.Text.Length;
            }

            if (length == 0)
            {
                updateUserConsoleText(message);
            }
            else
            {
                updateUserConsoleText(getUserConsoleText() + "\n" + message);
            }
        }

        public String getUserConsoleText()
        {
            String text = "";
            if (userConsole.InvokeRequired)
            {
                userConsole.Invoke(new MethodInvoker(delegate { text = userConsole.Text; }));
            }
            else
            {
                text = userConsole.Text;
            }
            return text;
        }

        private void updateUserConsoleText(String message)
        {
            if (this.userConsole.InvokeRequired)
            {
                updateUserConsoleTextCallback d = new updateUserConsoleTextCallback(updateUserConsoleText);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.userConsole.Text = message;
            }
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileChooser = new FolderBrowserDialog();
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                destinationTextBox.Text = fileChooser.SelectedPath;
            }
        }

        private void chooseFilesButton_Click(object sender, EventArgs e)
        {
            if (server.isTransfering())
            {
                MessageBox.Show("You are sending / receiving files");
                return;
            }

            OpenFileDialog fileChooser = new OpenFileDialog();
            fileChooser.Filter = "All Files (*.*)|*.*";
            fileChooser.Multiselect = true;
            String[] files;
            if (fileChooser.ShowDialog() == DialogResult.OK)
            {
                files = fileChooser.FileNames;
                server.setFilesToSend(files);
            }
        }

        public String getFileSavePath()
        {
            return this.destinationTextBox.Text;
        }

        public void determineFilesSize(String[] files)
        {
            long collectiveFileSize = 0L;
            FileInfo fileInfo;
            if (files == null)
            {
                setFileSizeLabel("0 Bytes");
                return;
            }

            foreach (String file in files)
            {
                fileInfo = new FileInfo(file);
                collectiveFileSize += fileInfo.Length;
            }

            long gb = 10 * 1024 * 1024 * 1024L;
            long mb = 10 * 1024 * 1024L;
            long kb = 10 * 1024L;

            if (collectiveFileSize > gb)
            {
                setFileSizeLabel(collectiveFileSize / 1024 / 1024 / 1024 + " GBs");
            }
            else if (collectiveFileSize >= mb)
            {
                setFileSizeLabel(collectiveFileSize / 1024 / 1024 + " MBs");
            }
            else if (collectiveFileSize >= kb)
            {
                setFileSizeLabel(collectiveFileSize / 1024 + " KBs");
            }
            else
            {
                setFileSizeLabel(collectiveFileSize + " Bytes");
            }
        }

        private void clearQueueButton_Click(object sender, EventArgs e)
        {
            server.setFilesToSend(null);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!server.isTransfering())
                server.sendAllFiles();
            else
            {
                MessageBox.Show("You are already sending / receiving files");
            }
        }

        private void userConsole_TextChanged(object sender, EventArgs e)
        {
            userConsole.SelectionStart = userConsole.Text.Length;
            userConsole.ScrollToCaret();
        }
    }
}
