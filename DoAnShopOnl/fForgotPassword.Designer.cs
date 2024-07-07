namespace DoAnShopOnl
{
    partial class fForgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fForgotPassword));
            this.btnGetPassword = new System.Windows.Forms.Button();
            this.lblForgetPass = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ptBoxClose = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetPassword
            // 
            this.btnGetPassword.BackColor = System.Drawing.Color.Red;
            this.btnGetPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGetPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetPassword.ForeColor = System.Drawing.Color.White;
            this.btnGetPassword.Location = new System.Drawing.Point(306, 211);
            this.btnGetPassword.Name = "btnGetPassword";
            this.btnGetPassword.Size = new System.Drawing.Size(505, 87);
            this.btnGetPassword.TabIndex = 20;
            this.btnGetPassword.Text = "Lấy mật khẩu";
            this.btnGetPassword.UseVisualStyleBackColor = false;
            this.btnGetPassword.Click += new System.EventHandler(this.btnGetPassword_Click);
            // 
            // lblForgetPass
            // 
            this.lblForgetPass.AutoSize = true;
            this.lblForgetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForgetPass.Location = new System.Drawing.Point(24, 24);
            this.lblForgetPass.Name = "lblForgetPass";
            this.lblForgetPass.Size = new System.Drawing.Size(425, 54);
            this.lblForgetPass.TabIndex = 19;
            this.lblForgetPass.Text = "QUÊN MẬT KHẨU";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEmail.Location = new System.Drawing.Point(306, 122);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.Size = new System.Drawing.Size(833, 53);
            this.txtBoxEmail.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 46);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nhập Email :";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Controls.Add(this.ptBoxClose);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2060, 75);
            this.panel5.TabIndex = 22;
            // 
            // ptBoxClose
            // 
            this.ptBoxClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptBoxClose.BackgroundImage")));
            this.ptBoxClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBoxClose.Location = new System.Drawing.Point(1980, 3);
            this.ptBoxClose.Name = "ptBoxClose";
            this.ptBoxClose.Size = new System.Drawing.Size(70, 70);
            this.ptBoxClose.TabIndex = 0;
            this.ptBoxClose.TabStop = false;
            this.ptBoxClose.Click += new System.EventHandler(this.ptBoxClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGetPassword);
            this.panel1.Controls.Add(this.lblForgetPass);
            this.panel1.Controls.Add(this.txtBoxEmail);
            this.panel1.Location = new System.Drawing.Point(416, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1187, 352);
            this.panel1.TabIndex = 23;
            // 
            // fForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 961);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxClose)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetPassword;
        private System.Windows.Forms.Label lblForgetPass;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox ptBoxClose;
        private System.Windows.Forms.Panel panel1;
    }
}