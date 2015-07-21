using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class ChoosePort : Form
    {
        public ChoosePort()
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
            int port;
            bool isNumber = int.TryParse(portTextBox.Text, out port);

            if (!isNumber)
            {
                portTextBox.Text = "Enter Valid Port";
                return;
            }
            if (port > 65535 || port < 1)
            {
                portTextBox.Text = "Enter Valid Port";
                return;
            }

            this.Hide();
            new Server(port);

        }
    }
}
