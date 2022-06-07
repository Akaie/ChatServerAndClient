using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_Client
{
    public partial class Form3 : Form
    {
        user_noip user_change;
        bool foreChanged = false;
        bool backChanged = false;
        public Form3()
        {
            InitializeComponent();
            AsyncClient.setting_form = this;
            AsyncClient.setting_txtbox = txt_name;
            user_change = AsyncClient.getUser();
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                txt_name.ForeColor = color.Color;
                foreChanged = true;
            }
        }

        private void btn_bcolor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            if (color.ShowDialog() == DialogResult.OK)
            {
                txt_name.BackColor = color.Color;
                backChanged = true;
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Equals("") && checkBox1.Checked)
            {
                txt_name.Text = "You must enter a username to change to!";
            }
            else
            {
                if (foreChanged)
                {
                    user_change.color = txt_name.ForeColor;
                }
                if (backChanged)
                {
                    user_change.backgroundColor = txt_name.BackColor;
                }
                if (!txt_name.Text.Equals(""))
                {
                    user_change.username = txt_name.Text;
                }
                AsyncClient.changeSettings();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txt_name_Click(object sender, EventArgs e)
        {
            if (txt_name.Text.Equals("Username Taken or Invalid! Try again!"))
            {
                txt_name.Text = "";
            }
            if(txt_name.Text.Equals("You must enter a username to change to!"))
            {
                txt_name.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txt_name.Enabled = false;
            }
            else
            {
                txt_name.Enabled = true;
            }
        }
    }
}
