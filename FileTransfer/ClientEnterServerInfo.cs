using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class ClientEnterServerInfo : Form
    {
        public ClientEnterServerInfo()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(closed);
            this.AcceptButton = okButton;
        }

        private void closed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            IPAddress serverIp;
            bool isValidIp = IPAddress.TryParse(ipTextBox.Text, out serverIp);
            String enteredIp = ipTextBox.Text;
            int count = enteredIp.Length - enteredIp.Replace(".", "").Length;


            if (!isValidIp || count != 3)
            {
                enterInfoLabel.Text = "Enter Valid IP";
                return;
            }

            int port;
            bool isNumber = int.TryParse(portTextBox.Text, out port);

            if (!isNumber)
            {
                enterInfoLabel.Text = "Enter Valid Port";
                return;
            }
            else if (port > 65535 || port < 1)
            {
                enterInfoLabel.Text = "Enter Valid Port";
                return;
            }

            this.Hide();
            new Server(serverIp, port);
        }
    }
}
