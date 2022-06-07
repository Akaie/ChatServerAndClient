using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Chat_Client
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AsyncClient.users = lst_users;
            AsyncClient.message_txtbox = txt_chat;
            AsyncClient.chat = lst_chat;
            AsyncClient.getUsers();
            lst_chat.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void tmr_usrlst_Tick(object sender, EventArgs e)
        {
            AsyncClient.poll();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            AsyncClient.sendMessage();
            txt_chat.Text = "";
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lst_chat_DrawItem(object sender, DrawItemEventArgs e)
        {
            if(e.Index < 0)
            {
                return;
            }
            ListBox lb = (ListBox)sender;
            e.DrawBackground();
            string content = lb.Items[e.Index].ToString();
            message messageObj = ((message)lb.Items[e.Index]);
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(messageObj.backgroundColor), e.Bounds);
            g.DrawString(content, e.Font, new SolidBrush(messageObj.color), new PointF(e.Bounds.X, e.Bounds.Y));
            e.DrawFocusRectangle();

        }

        private void btn_changesetting_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Visible = true;
        }
    }
}
