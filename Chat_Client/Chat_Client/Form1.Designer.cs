
namespace Chat_Client
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.btn_bcolor = new System.Windows.Forms.Button();
            this.txtbox_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Nickname";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(12, 63);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(206, 20);
            this.txt_name.TabIndex = 1;
            this.txt_name.Click += new System.EventHandler(this.txt_name_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(12, 152);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(143, 152);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(12, 89);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(206, 23);
            this.btn_color.TabIndex = 4;
            this.btn_color.Text = "Pick Font Color";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_bcolor
            // 
            this.btn_bcolor.Location = new System.Drawing.Point(12, 118);
            this.btn_bcolor.Name = "btn_bcolor";
            this.btn_bcolor.Size = new System.Drawing.Size(206, 23);
            this.btn_bcolor.TabIndex = 5;
            this.btn_bcolor.Text = "Pick Background Color";
            this.btn_bcolor.UseVisualStyleBackColor = true;
            this.btn_bcolor.Click += new System.EventHandler(this.btn_bcolor_Click);
            // 
            // txtbox_ip
            // 
            this.txtbox_ip.Location = new System.Drawing.Point(12, 23);
            this.txtbox_ip.Name = "txtbox_ip";
            this.txtbox_ip.Size = new System.Drawing.Size(206, 20);
            this.txtbox_ip.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Enter IP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 188);
            this.Controls.Add(this.txtbox_ip);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_bcolor);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Connect...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.Button btn_bcolor;
        private System.Windows.Forms.TextBox txtbox_ip;
        private System.Windows.Forms.Label label2;
    }
}

