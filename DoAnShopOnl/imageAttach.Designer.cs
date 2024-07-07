namespace DoAnShopOnl
{
    partial class imageAttach
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
            this.ptBoxImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ptBoxImage
            // 
            this.ptBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ptBoxImage.Location = new System.Drawing.Point(0, 0);
            this.ptBoxImage.Name = "ptBoxImage";
            this.ptBoxImage.Size = new System.Drawing.Size(150, 150);
            this.ptBoxImage.TabIndex = 0;
            this.ptBoxImage.TabStop = false;
            // 
            // imageAttach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ptBoxImage);
            this.Name = "imageAttach";
            ((System.ComponentModel.ISupportInitialize)(this.ptBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox ptBoxImage;
    }
}
