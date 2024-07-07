namespace DoAnShopOnl
{
    partial class cartItemUct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cartItemUct));
            this.lblDeviceName = new System.Windows.Forms.Label();
            this.lblOnePrice = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblAllPrice = new System.Windows.Forms.Label();
            this.ptBoxImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAllHighPrice = new System.Windows.Forms.Label();
            this.ptBoxTrash = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxTrash)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDeviceName
            // 
            this.lblDeviceName.AutoSize = true;
            this.lblDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceName.Location = new System.Drawing.Point(187, 16);
            this.lblDeviceName.Name = "lblDeviceName";
            this.lblDeviceName.Size = new System.Drawing.Size(98, 32);
            this.lblDeviceName.TabIndex = 1;
            this.lblDeviceName.Text = "label1";
            // 
            // lblOnePrice
            // 
            this.lblOnePrice.AutoSize = true;
            this.lblOnePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnePrice.Location = new System.Drawing.Point(498, 102);
            this.lblOnePrice.Name = "lblOnePrice";
            this.lblOnePrice.Size = new System.Drawing.Size(70, 25);
            this.lblOnePrice.TabIndex = 2;
            this.lblOnePrice.Text = "label1";
            this.lblOnePrice.Visible = false;
            // 
            // numQuantity
            // 
            this.numQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantity.Location = new System.Drawing.Point(195, 97);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(70, 30);
            this.numQuantity.TabIndex = 3;
            this.numQuantity.ValueChanged += new System.EventHandler(this.numQuantity_ValueChanged);
            // 
            // lblAllPrice
            // 
            this.lblAllPrice.AutoSize = true;
            this.lblAllPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllPrice.ForeColor = System.Drawing.Color.Red;
            this.lblAllPrice.Location = new System.Drawing.Point(925, 64);
            this.lblAllPrice.Name = "lblAllPrice";
            this.lblAllPrice.Size = new System.Drawing.Size(85, 29);
            this.lblAllPrice.TabIndex = 4;
            this.lblAllPrice.Text = "label2";
            // 
            // ptBoxImage
            // 
            this.ptBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptBoxImage.Location = new System.Drawing.Point(19, 16);
            this.ptBoxImage.Name = "ptBoxImage";
            this.ptBoxImage.Size = new System.Drawing.Size(141, 124);
            this.ptBoxImage.TabIndex = 0;
            this.ptBoxImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(191, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số lượng";
            // 
            // lblAllHighPrice
            // 
            this.lblAllHighPrice.AutoSize = true;
            this.lblAllHighPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllHighPrice.ForeColor = System.Drawing.Color.Gray;
            this.lblAllHighPrice.Location = new System.Drawing.Point(930, 98);
            this.lblAllHighPrice.Name = "lblAllHighPrice";
            this.lblAllHighPrice.Size = new System.Drawing.Size(64, 25);
            this.lblAllHighPrice.TabIndex = 6;
            this.lblAllHighPrice.Text = "label2";
            // 
            // ptBoxTrash
            // 
            this.ptBoxTrash.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ptBoxTrash.BackgroundImage")));
            this.ptBoxTrash.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBoxTrash.Location = new System.Drawing.Point(1023, 16);
            this.ptBoxTrash.Name = "ptBoxTrash";
            this.ptBoxTrash.Size = new System.Drawing.Size(33, 38);
            this.ptBoxTrash.TabIndex = 7;
            this.ptBoxTrash.TabStop = false;
            // 
            // cartItemUct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.ptBoxTrash);
            this.Controls.Add(this.lblAllHighPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAllPrice);
            this.Controls.Add(this.numQuantity);
            this.Controls.Add(this.lblOnePrice);
            this.Controls.Add(this.lblDeviceName);
            this.Controls.Add(this.ptBoxImage);
            this.Name = "cartItemUct";
            this.Size = new System.Drawing.Size(1115, 157);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxTrash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptBoxImage;
        private System.Windows.Forms.Label lblDeviceName;
        private System.Windows.Forms.Label lblOnePrice;
        public System.Windows.Forms.NumericUpDown numQuantity;
        public System.Windows.Forms.Label lblAllPrice;
        public System.Windows.Forms.Label lblAllHighPrice;
        public System.Windows.Forms.PictureBox ptBoxTrash;
        public System.Windows.Forms.Label label1;
    }
}
