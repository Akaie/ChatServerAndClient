using System;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AsyncClient.username_txtbox = txt_name;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            AsyncClient.ipaddress = txtbox_ip.Text;
            AsyncClient.StartClient();
            if(AsyncClient.getConnected()) {
                this.Visible = false;
                Form2 f = new Form2();
                f.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                txt_name.ForeColor = color.Color;
            }
        }

        private void btn_bcolor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                txt_name.BackColor = color.Color;
            }
        }

        private void txt_name_Click(object sender, EventArgs e)
        {
            if(txt_name.Text.Equals("Username Taken or Invalid! Try again!"))
            {
                txt_name.Text = "";
            }
            if(txt_name.Text.Equals("IP address is in use."))
            {
                txt_name.Text = "";
            }
        }
    }
}
