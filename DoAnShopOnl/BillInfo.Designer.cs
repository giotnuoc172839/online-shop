namespace DoAnShopOnl
{
    partial class BillInfo
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
            this.dtgvBillInfo = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBillInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvBillInfo
            // 
            this.dtgvBillInfo.AllowUserToAddRows = false;
            this.dtgvBillInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvBillInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvBillInfo.Location = new System.Drawing.Point(18, 62);
            this.dtgvBillInfo.Name = "dtgvBillInfo";
            this.dtgvBillInfo.RowHeadersWidth = 51;
            this.dtgvBillInfo.RowTemplate.Height = 24;
            this.dtgvBillInfo.Size = new System.Drawing.Size(1051, 264);
            this.dtgvBillInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chi tiết hóa đơn";
            // 
            // BillInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 355);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvBillInfo);
            this.Name = "BillInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hóa đơn";
            this.Load += new System.EventHandler(this.BillInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvBillInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvBillInfo;
        private System.Windows.Forms.Label label1;
    }
}