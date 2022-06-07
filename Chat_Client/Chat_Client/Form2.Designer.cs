
namespace Chat_Client
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.lst_chat = new System.Windows.Forms.ListBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.txt_chat = new System.Windows.Forms.TextBox();
            this.lst_users = new System.Windows.Forms.ListBox();
            this.btn_changenick = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lst_chat
            // 
            this.lst_chat.FormattingEnabled = true;
            this.lst_chat.Location = new System.Drawing.Point(13, 15);
            this.lst_chat.Name = "lst_chat";
            this.lst_chat.Size = new System.Drawing.Size(431, 381);
            this.lst_chat.TabIndex = 0;
            this.lst_chat.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lst_chat_DrawItem);
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(368, 406);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 1;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // txt_chat
            // 
            this.txt_chat.Location = new System.Drawing.Point(13, 409);
            this.txt_chat.Name = "txt_chat";
            this.txt_chat.Size = new System.Drawing.Size(349, 20);
            this.txt_chat.TabIndex = 2;
            // 
            // lst_users
            // 
            this.lst_users.FormattingEnabled = true;
            this.lst_users.Location = new System.Drawing.Point(450, 15);
            this.lst_users.Name = "lst_users";
            this.lst_users.Size = new System.Drawing.Size(119, 381);
            this.lst_users.TabIndex = 3;
            // 
            // btn_changenick
            // 
            this.btn_changenick.Location = new System.Drawing.Point(450, 406);
            this.btn_changenick.Name = "btn_changenick";
            this.btn_changenick.Size = new System.Drawing.Size(119, 23);
            this.btn_changenick.TabIndex = 6;
            this.btn_changenick.Text = "Settings";
            this.btn_changenick.UseVisualStyleBackColor = true;
            this.btn_changenick.Click += new System.EventHandler(this.btn_changesetting_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.tmr_usrlst_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 441);
            this.Controls.Add(this.btn_changenick);
            this.Controls.Add(this.lst_users);
            this.Controls.Add(this.txt_chat);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.lst_chat);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_chat;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox txt_chat;
        private System.Windows.Forms.ListBox lst_users;
        private System.Windows.Forms.Button btn_changenick;
        private System.Windows.Forms.Timer timer1;
    }
}