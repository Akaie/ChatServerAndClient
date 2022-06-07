
namespace Chat_Client
{
    partial class Form3
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_bcolor = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(146, 122);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(15, 122);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 6;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // txt_name
            // 
            this.txt_name.Enabled = false;
            this.txt_name.Location = new System.Drawing.Point(14, 34);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(206, 20);
            this.txt_name.TabIndex = 5;
            this.txt_name.Click += new System.EventHandler(this.txt_name_Click);
            // 
            // btn_bcolor
            // 
            this.btn_bcolor.Location = new System.Drawing.Point(13, 91);
            this.btn_bcolor.Name = "btn_bcolor";
            this.btn_bcolor.Size = new System.Drawing.Size(206, 23);
            this.btn_bcolor.TabIndex = 9;
            this.btn_bcolor.Text = "Pick Background Color";
            this.btn_bcolor.UseVisualStyleBackColor = true;
            this.btn_bcolor.Click += new System.EventHandler(this.btn_bcolor_Click);
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(13, 62);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(206, 23);
            this.btn_color.TabIndex = 8;
            this.btn_color.Text = "Pick Font Color";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(13, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Chnage Nickname";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 153);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_bcolor);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_bcolor;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}