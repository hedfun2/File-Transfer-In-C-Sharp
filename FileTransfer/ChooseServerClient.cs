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
    public partial class ChooseServerClient : Form
    {
        public ChooseServerClient()
        {
            InitializeComponent();
        }

        private void serverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var choosePort = new ChoosePort();
            choosePort.Show();

        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var window = new ClientEnterServerInfo();
            window.Show();
        }
    }
}
