namespace DoAnShopOnl
{
    partial class fFindReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFindReport));
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ptBoxQR = new System.Windows.Forms.PictureBox();
            this.gnBtnUploadQR = new Guna.UI2.WinForms.Guna2Button();
            this.gnBtnSearchReport = new Guna.UI2.WinForms.Guna2Button();
            this.flowPnReport = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxTotalBill = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBoxStatus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBoxDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBoxPhone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBoxEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxQR)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel5.Controls.Add(this.pictureBox2);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(2060, 75);
            this.panel5.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 70);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ptBoxQR);
            this.panel1.Controls.Add(this.gnBtnUploadQR);
            this.panel1.Controls.Add(this.gnBtnSearchReport);
            this.panel1.Location = new System.Drawing.Point(145, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 194);
            this.panel1.TabIndex = 15;
            // 
            // ptBoxQR
            // 
            this.ptBoxQR.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptBoxQR.BackgroundImage")));
            this.ptBoxQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBoxQR.Location = new System.Drawing.Point(458, 19);
            this.ptBoxQR.Name = "ptBoxQR";
            this.ptBoxQR.Size = new System.Drawing.Size(153, 153);
            this.ptBoxQR.TabIndex = 4;
            this.ptBoxQR.TabStop = false;
            this.ptBoxQR.Tag = "D:\\Lap trinh C#\\FirstApp\\FirstApp\\image.png";
            // 
            // gnBtnUploadQR
            // 
            this.gnBtnUploadQR.AutoRoundedCorners = true;
            this.gnBtnUploadQR.BorderRadius = 32;
            this.gnBtnUploadQR.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnUploadQR.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnUploadQR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnBtnUploadQR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnBtnUploadQR.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnBtnUploadQR.ForeColor = System.Drawing.Color.White;
            this.gnBtnUploadQR.Location = new System.Drawing.Point(122, 19);
            this.gnBtnUploadQR.Name = "gnBtnUploadQR";
            this.gnBtnUploadQR.Size = new System.Drawing.Size(242, 67);
            this.gnBtnUploadQR.TabIndex = 3;
            this.gnBtnUploadQR.Text = "Tải QR lên";
            this.gnBtnUploadQR.Click += new System.EventHandler(this.gnBtnUploadQR_Click);
            // 
            // gnBtnSearchReport
            // 
            this.gnBtnSearchReport.AutoRoundedCorners = true;
            this.gnBtnSearchReport.BorderRadius = 32;
            this.gnBtnSearchReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnSearchReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnSearchReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnBtnSearchReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnBtnSearchReport.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnBtnSearchReport.ForeColor = System.Drawing.Color.White;
            this.gnBtnSearchReport.Location = new System.Drawing.Point(122, 105);
            this.gnBtnSearchReport.Name = "gnBtnSearchReport";
            this.gnBtnSearchReport.Size = new System.Drawing.Size(242, 67);
            this.gnBtnSearchReport.TabIndex = 2;
            this.gnBtnSearchReport.Text = "Tra cứu";
            this.gnBtnSearchReport.Click += new System.EventHandler(this.btnLoadReport_Click);
            // 
            // flowPnReport
            // 
            this.flowPnReport.AutoScroll = true;
            this.flowPnReport.BackColor = System.Drawing.Color.White;
            this.flowPnReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowPnReport.Location = new System.Drawing.Point(1025, 169);
            this.flowPnReport.Name = "flowPnReport";
            this.flowPnReport.Size = new System.Drawing.Size(877, 713);
            this.flowPnReport.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtBoxTotalBill);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtBoxStatus);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtBoxDate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtBoxPhone);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtBoxEmail);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBoxName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(145, 369);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 513);
            this.panel2.TabIndex = 17;
            // 
            // txtBoxTotalBill
            // 
            this.txtBoxTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxTotalBill.Location = new System.Drawing.Point(266, 357);
            this.txtBoxTotalBill.Name = "txtBoxTotalBill";
            this.txtBoxTotalBill.ReadOnly = true;
            this.txtBoxTotalBill.Size = new System.Drawing.Size(532, 38);
            this.txtBoxTotalBill.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(56, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tổng hóa đơn :";
            // 
            // txtBoxStatus
            // 
            this.txtBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxStatus.Location = new System.Drawing.Point(266, 435);
            this.txtBoxStatus.Name = "txtBoxStatus";
            this.txtBoxStatus.ReadOnly = true;
            this.txtBoxStatus.Size = new System.Drawing.Size(532, 38);
            this.txtBoxStatus.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(103, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(157, 32);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tình trạng :";
            // 
            // txtBoxDate
            // 
            this.txtBoxDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxDate.Location = new System.Drawing.Point(266, 281);
            this.txtBoxDate.Name = "txtBoxDate";
            this.txtBoxDate.ReadOnly = true;
            this.txtBoxDate.Size = new System.Drawing.Size(532, 38);
            this.txtBoxDate.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(228, 32);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày mua hàng :";
            // 
            // txtBoxPhone
            // 
            this.txtBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPhone.Location = new System.Drawing.Point(266, 201);
            this.txtBoxPhone.Name = "txtBoxPhone";
            this.txtBoxPhone.ReadOnly = true;
            this.txtBoxPhone.Size = new System.Drawing.Size(532, 38);
            this.txtBoxPhone.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(188, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 32);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sđt :";
            // 
            // txtBoxEmail
            // 
            this.txtBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxEmail.Location = new System.Drawing.Point(266, 121);
            this.txtBoxEmail.Name = "txtBoxEmail";
            this.txtBoxEmail.ReadOnly = true;
            this.txtBoxEmail.Size = new System.Drawing.Size(532, 38);
            this.txtBoxEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Email :";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.Location = new System.Drawing.Point(266, 37);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.ReadOnly = true;
            this.txtBoxName.Size = new System.Drawing.Size(532, 38);
            this.txtBoxName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên :";
            // 
            // fFindReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1906, 961);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowPnReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fFindReport";
            this.Text = "fFindReport";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.fFindReport_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxQR)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowPnReport;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBoxStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBoxDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBoxPhone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button gnBtnSearchReport;
        private System.Windows.Forms.TextBox txtBoxTotalBill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox ptBoxQR;
        private Guna.UI2.WinForms.Guna2Button gnBtnUploadQR;
    }
}