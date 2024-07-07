namespace DoAnShopOnl.Admin
{
    partial class fBill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnTotal = new System.Windows.Forms.Panel();
            this.gnDgvBill = new Guna.UI2.WinForms.Guna2DataGridView();
            this.dgvid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvtotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvbillInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvisPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBoxBillAddress = new System.Windows.Forms.TextBox();
            this.txtBoxBillTotalPrice = new System.Windows.Forms.TextBox();
            this.txtBoxBillDate = new System.Windows.Forms.TextBox();
            this.txtBoxBillEmail = new System.Windows.Forms.TextBox();
            this.txtBoxBillPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtBoxBillName = new System.Windows.Forms.TextBox();
            this.txtBoxBillId = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnSaveBill = new System.Windows.Forms.Button();
            this.comboBoxIsPaid = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.listViewBill = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gnDgvBill)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTotal
            // 
            this.pnTotal.BackColor = System.Drawing.Color.Gainsboro;
            this.pnTotal.Controls.Add(this.gnDgvBill);
            this.pnTotal.Controls.Add(this.panel1);
            this.pnTotal.Controls.Add(this.label1);
            this.pnTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTotal.Location = new System.Drawing.Point(0, 0);
            this.pnTotal.Name = "pnTotal";
            this.pnTotal.Size = new System.Drawing.Size(1942, 1063);
            this.pnTotal.TabIndex = 3;
            // 
            // gnDgvBill
            // 
            this.gnDgvBill.AllowUserToAddRows = false;
            this.gnDgvBill.AllowUserToDeleteRows = false;
            this.gnDgvBill.AllowUserToResizeColumns = false;
            this.gnDgvBill.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.gnDgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(61)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gnDgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gnDgvBill.ColumnHeadersHeight = 45;
            this.gnDgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gnDgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvid,
            this.dgvname,
            this.dgvmail,
            this.dgvphone,
            this.dgvaddress,
            this.dgvtotalPrice,
            this.dgvbillInfo,
            this.dgvisPaid});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gnDgvBill.DefaultCellStyle = dataGridViewCellStyle6;
            this.gnDgvBill.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gnDgvBill.Location = new System.Drawing.Point(38, 52);
            this.gnDgvBill.Name = "gnDgvBill";
            this.gnDgvBill.RowHeadersVisible = false;
            this.gnDgvBill.RowHeadersWidth = 51;
            this.gnDgvBill.RowTemplate.Height = 24;
            this.gnDgvBill.Size = new System.Drawing.Size(806, 909);
            this.gnDgvBill.TabIndex = 8;
            this.gnDgvBill.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gnDgvBill.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gnDgvBill.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gnDgvBill.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gnDgvBill.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gnDgvBill.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gnDgvBill.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gnDgvBill.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gnDgvBill.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gnDgvBill.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnDgvBill.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gnDgvBill.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gnDgvBill.ThemeStyle.HeaderStyle.Height = 45;
            this.gnDgvBill.ThemeStyle.ReadOnly = false;
            this.gnDgvBill.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gnDgvBill.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gnDgvBill.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnDgvBill.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gnDgvBill.ThemeStyle.RowsStyle.Height = 24;
            this.gnDgvBill.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gnDgvBill.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gnDgvBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gnDgvBill_CellClick);
            // 
            // dgvid
            // 
            this.dgvid.HeaderText = "id";
            this.dgvid.MinimumWidth = 6;
            this.dgvid.Name = "dgvid";
            this.dgvid.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvid.Visible = false;
            // 
            // dgvname
            // 
            this.dgvname.HeaderText = "Tên";
            this.dgvname.MinimumWidth = 6;
            this.dgvname.Name = "dgvname";
            this.dgvname.ReadOnly = true;
            this.dgvname.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvmail
            // 
            this.dgvmail.HeaderText = "Email";
            this.dgvmail.MinimumWidth = 6;
            this.dgvmail.Name = "dgvmail";
            this.dgvmail.ReadOnly = true;
            this.dgvmail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvphone
            // 
            this.dgvphone.HeaderText = "SĐT";
            this.dgvphone.MinimumWidth = 6;
            this.dgvphone.Name = "dgvphone";
            this.dgvphone.ReadOnly = true;
            this.dgvphone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dgvaddress
            // 
            this.dgvaddress.HeaderText = "Địa chỉ";
            this.dgvaddress.MinimumWidth = 6;
            this.dgvaddress.Name = "dgvaddress";
            this.dgvaddress.Visible = false;
            // 
            // dgvtotalPrice
            // 
            this.dgvtotalPrice.HeaderText = "Tổng hóa đơn";
            this.dgvtotalPrice.MinimumWidth = 6;
            this.dgvtotalPrice.Name = "dgvtotalPrice";
            this.dgvtotalPrice.ReadOnly = true;
            // 
            // dgvbillInfo
            // 
            this.dgvbillInfo.HeaderText = "Chi tiết hóa đơn";
            this.dgvbillInfo.MinimumWidth = 6;
            this.dgvbillInfo.Name = "dgvbillInfo";
            this.dgvbillInfo.Visible = false;
            // 
            // dgvisPaid
            // 
            this.dgvisPaid.HeaderText = "Đã thanh toán";
            this.dgvisPaid.MinimumWidth = 6;
            this.dgvisPaid.Name = "dgvisPaid";
            this.dgvisPaid.ReadOnly = true;
            this.dgvisPaid.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtBoxBillAddress);
            this.panel1.Controls.Add(this.txtBoxBillTotalPrice);
            this.panel1.Controls.Add(this.txtBoxBillDate);
            this.panel1.Controls.Add(this.txtBoxBillEmail);
            this.panel1.Controls.Add(this.txtBoxBillPhoneNumber);
            this.panel1.Controls.Add(this.txtBoxBillName);
            this.panel1.Controls.Add(this.txtBoxBillId);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.btnSaveBill);
            this.panel1.Controls.Add(this.comboBoxIsPaid);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.listViewBill);
            this.panel1.Location = new System.Drawing.Point(850, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1027, 909);
            this.panel1.TabIndex = 6;
            // 
            // txtBoxBillAddress
            // 
            this.txtBoxBillAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillAddress.Location = new System.Drawing.Point(159, 159);
            this.txtBoxBillAddress.Name = "txtBoxBillAddress";
            this.txtBoxBillAddress.ReadOnly = true;
            this.txtBoxBillAddress.Size = new System.Drawing.Size(832, 41);
            this.txtBoxBillAddress.TabIndex = 65;
            // 
            // txtBoxBillTotalPrice
            // 
            this.txtBoxBillTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillTotalPrice.Location = new System.Drawing.Point(739, 294);
            this.txtBoxBillTotalPrice.Name = "txtBoxBillTotalPrice";
            this.txtBoxBillTotalPrice.ReadOnly = true;
            this.txtBoxBillTotalPrice.Size = new System.Drawing.Size(252, 41);
            this.txtBoxBillTotalPrice.TabIndex = 63;
            // 
            // txtBoxBillDate
            // 
            this.txtBoxBillDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillDate.Location = new System.Drawing.Point(253, 226);
            this.txtBoxBillDate.Name = "txtBoxBillDate";
            this.txtBoxBillDate.ReadOnly = true;
            this.txtBoxBillDate.Size = new System.Drawing.Size(738, 41);
            this.txtBoxBillDate.TabIndex = 59;
            // 
            // txtBoxBillEmail
            // 
            this.txtBoxBillEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillEmail.Location = new System.Drawing.Point(138, 95);
            this.txtBoxBillEmail.Name = "txtBoxBillEmail";
            this.txtBoxBillEmail.ReadOnly = true;
            this.txtBoxBillEmail.Size = new System.Drawing.Size(502, 41);
            this.txtBoxBillEmail.TabIndex = 57;
            // 
            // txtBoxBillPhoneNumber
            // 
            this.txtBoxBillPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillPhoneNumber.Location = new System.Drawing.Point(757, 97);
            this.txtBoxBillPhoneNumber.Name = "txtBoxBillPhoneNumber";
            this.txtBoxBillPhoneNumber.ReadOnly = true;
            this.txtBoxBillPhoneNumber.Size = new System.Drawing.Size(229, 41);
            this.txtBoxBillPhoneNumber.TabIndex = 55;
            // 
            // txtBoxBillName
            // 
            this.txtBoxBillName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillName.Location = new System.Drawing.Point(404, 35);
            this.txtBoxBillName.Name = "txtBoxBillName";
            this.txtBoxBillName.ReadOnly = true;
            this.txtBoxBillName.Size = new System.Drawing.Size(582, 41);
            this.txtBoxBillName.TabIndex = 51;
            // 
            // txtBoxBillId
            // 
            this.txtBoxBillId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBillId.Location = new System.Drawing.Point(138, 35);
            this.txtBoxBillId.Name = "txtBoxBillId";
            this.txtBoxBillId.ReadOnly = true;
            this.txtBoxBillId.Size = new System.Drawing.Size(174, 41);
            this.txtBoxBillId.TabIndex = 48;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(22, 162);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(131, 36);
            this.label24.TabIndex = 64;
            this.label24.Text = "ĐỊA CHỈ:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(549, 297);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(184, 36);
            this.label23.TabIndex = 62;
            this.label23.Text = "TỔNG TIỀN:";
            // 
            // btnSaveBill
            // 
            this.btnSaveBill.BackColor = System.Drawing.Color.Silver;
            this.btnSaveBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBill.Location = new System.Drawing.Point(148, 791);
            this.btnSaveBill.Name = "btnSaveBill";
            this.btnSaveBill.Size = new System.Drawing.Size(718, 73);
            this.btnSaveBill.TabIndex = 61;
            this.btnSaveBill.Text = "CẬP NHẬT HÓA ĐƠN";
            this.btnSaveBill.UseVisualStyleBackColor = false;
            this.btnSaveBill.Click += new System.EventHandler(this.btnSaveBill_Click);
            // 
            // comboBoxIsPaid
            // 
            this.comboBoxIsPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxIsPaid.FormattingEnabled = true;
            this.comboBoxIsPaid.Items.AddRange(new object[] {
            "Chưa thanh toán ❎",
            "Đã thanh toán ✅"});
            this.comboBoxIsPaid.Location = new System.Drawing.Point(297, 294);
            this.comboBoxIsPaid.Name = "comboBoxIsPaid";
            this.comboBoxIsPaid.Size = new System.Drawing.Size(250, 37);
            this.comboBoxIsPaid.TabIndex = 60;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(22, 297);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(256, 36);
            this.label22.TabIndex = 58;
            this.label22.Text = "TÌNH TRẠNG HĐ:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(22, 100);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 36);
            this.label21.TabIndex = 56;
            this.label21.Text = "EMAIL:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(669, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 36);
            this.label20.TabIndex = 54;
            this.label20.Text = "SĐT:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(22, 229);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(225, 36);
            this.label19.TabIndex = 53;
            this.label19.Text = "NGÀY LẬP HĐ:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(22, 361);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(468, 36);
            this.label17.TabIndex = 52;
            this.label17.Text = "THÔNG TIN CHI TIẾT HÓA ĐƠN :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(334, 38);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 36);
            this.label16.TabIndex = 50;
            this.label16.Text = "KH:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(22, 38);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(110, 36);
            this.label18.TabIndex = 49;
            this.label18.Text = "Số HĐ:";
            // 
            // listViewBill
            // 
            this.listViewBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewBill.HideSelection = false;
            this.listViewBill.Location = new System.Drawing.Point(28, 409);
            this.listViewBill.Name = "listViewBill";
            this.listViewBill.Size = new System.Drawing.Size(963, 345);
            this.listViewBill.TabIndex = 47;
            this.listViewBill.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill";
            this.label1.Visible = false;
            // 
            // fBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1942, 1063);
            this.Controls.Add(this.pnTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fBill";
            this.Text = "fBill";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fBill_FormClosing);
            this.Load += new System.EventHandler(this.fBill_Load);
            this.pnTotal.ResumeLayout(false);
            this.pnTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gnDgvBill)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBoxBillAddress;
        private System.Windows.Forms.TextBox txtBoxBillTotalPrice;
        private System.Windows.Forms.TextBox txtBoxBillDate;
        private System.Windows.Forms.TextBox txtBoxBillEmail;
        private System.Windows.Forms.TextBox txtBoxBillPhoneNumber;
        private System.Windows.Forms.TextBox txtBoxBillName;
        private System.Windows.Forms.TextBox txtBoxBillId;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnSaveBill;
        private System.Windows.Forms.ComboBox comboBoxIsPaid;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListView listViewBill;
        private Guna.UI2.WinForms.Guna2DataGridView gnDgvBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvtotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvbillInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvisPaid;
    }
}