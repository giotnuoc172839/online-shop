namespace DoAnShopOnl.Admin
{
    partial class fOldDashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea21 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend21 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea22 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend22 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea23 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend23 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea24 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend24 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel5 = new System.Windows.Forms.Panel();
            this.gnBtnRevenue = new Guna.UI2.WinForms.Guna2Button();
            this.chart3Category = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gnBtn3 = new Guna.UI2.WinForms.Guna2Button();
            this.chartTopSelling = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel6 = new System.Windows.Forms.Panel();
            this.chartTopRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbBoxCategory = new System.Windows.Forms.ComboBox();
            this.gnBtnTopSelling = new Guna.UI2.WinForms.Guna2Button();
            this.dateTimePickerToTopSelling = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFromTopSelling = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart3Category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSelling)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DarkGray;
            this.panel5.Controls.Add(this.dateTimePickerTo);
            this.panel5.Controls.Add(this.dateTimePickerFrom);
            this.panel5.Controls.Add(this.gnBtnRevenue);
            this.panel5.Controls.Add(this.chart3Category);
            this.panel5.Controls.Add(this.chartRevenue);
            this.panel5.Location = new System.Drawing.Point(12, 22);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1166, 504);
            this.panel5.TabIndex = 7;
            // 
            // gnBtnRevenue
            // 
            this.gnBtnRevenue.AutoRoundedCorners = true;
            this.gnBtnRevenue.BorderRadius = 26;
            this.gnBtnRevenue.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnRevenue.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnRevenue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnBtnRevenue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnBtnRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnBtnRevenue.ForeColor = System.Drawing.Color.White;
            this.gnBtnRevenue.Location = new System.Drawing.Point(619, 27);
            this.gnBtnRevenue.Name = "gnBtnRevenue";
            this.gnBtnRevenue.Size = new System.Drawing.Size(211, 54);
            this.gnBtnRevenue.TabIndex = 3;
            this.gnBtnRevenue.Text = "Tra cứu";
            this.gnBtnRevenue.Click += new System.EventHandler(this.gnBtnRevenue_Click);
            // 
            // chart3Category
            // 
            chartArea21.Name = "ChartArea1";
            this.chart3Category.ChartAreas.Add(chartArea21);
            legend21.Name = "Legend1";
            this.chart3Category.Legends.Add(legend21);
            this.chart3Category.Location = new System.Drawing.Point(578, 96);
            this.chart3Category.Name = "chart3Category";
            this.chart3Category.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chart3Category.Size = new System.Drawing.Size(554, 382);
            this.chart3Category.TabIndex = 4;
            this.chart3Category.Text = "chart1";
            // 
            // chartRevenue
            // 
            chartArea22.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea22);
            legend22.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend22);
            this.chartRevenue.Location = new System.Drawing.Point(18, 97);
            this.chartRevenue.Name = "chartRevenue";
            this.chartRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartRevenue.Size = new System.Drawing.Size(554, 381);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.DarkGray;
            this.panel7.Controls.Add(this.gnBtn3);
            this.panel7.Controls.Add(this.chartTopSelling);
            this.panel7.Location = new System.Drawing.Point(1196, 22);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(596, 892);
            this.panel7.TabIndex = 9;
            // 
            // gnBtn3
            // 
            this.gnBtn3.AutoRoundedCorners = true;
            this.gnBtn3.BorderRadius = 26;
            this.gnBtn3.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnBtn3.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnBtn3.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnBtn3.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnBtn3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnBtn3.ForeColor = System.Drawing.Color.White;
            this.gnBtn3.Location = new System.Drawing.Point(389, 3);
            this.gnBtn3.Name = "gnBtn3";
            this.gnBtn3.Size = new System.Drawing.Size(204, 54);
            this.gnBtn3.TabIndex = 6;
            this.gnBtn3.Text = "Tra cứu";
            this.gnBtn3.Click += new System.EventHandler(this.gnBtn3_Click);
            // 
            // chartTopSelling
            // 
            chartArea23.Name = "ChartArea1";
            this.chartTopSelling.ChartAreas.Add(chartArea23);
            legend23.Name = "Legend1";
            this.chartTopSelling.Legends.Add(legend23);
            this.chartTopSelling.Location = new System.Drawing.Point(3, 96);
            this.chartTopSelling.Name = "chartTopSelling";
            this.chartTopSelling.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartTopSelling.Size = new System.Drawing.Size(590, 793);
            this.chartTopSelling.TabIndex = 4;
            this.chartTopSelling.Text = "chart1";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel6.Controls.Add(this.chartTopRevenue);
            this.panel6.Controls.Add(this.cbBoxCategory);
            this.panel6.Controls.Add(this.gnBtnTopSelling);
            this.panel6.Controls.Add(this.dateTimePickerToTopSelling);
            this.panel6.Controls.Add(this.dateTimePickerFromTopSelling);
            this.panel6.Location = new System.Drawing.Point(3, 540);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1141, 503);
            this.panel6.TabIndex = 8;
            // 
            // chartTopRevenue
            // 
            chartArea24.Name = "ChartArea1";
            this.chartTopRevenue.ChartAreas.Add(chartArea24);
            legend24.Name = "Legend1";
            this.chartTopRevenue.Legends.Add(legend24);
            this.chartTopRevenue.Location = new System.Drawing.Point(193, 108);
            this.chartTopRevenue.Name = "chartTopRevenue";
            this.chartTopRevenue.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            this.chartTopRevenue.Size = new System.Drawing.Size(841, 363);
            this.chartTopRevenue.TabIndex = 8;
            this.chartTopRevenue.Text = "chart1";
            // 
            // cbBoxCategory
            // 
            this.cbBoxCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoxCategory.FormattingEnabled = true;
            this.cbBoxCategory.Items.AddRange(new object[] {
            "Phone",
            "Laptop",
            "Ipad"});
            this.cbBoxCategory.Location = new System.Drawing.Point(623, 47);
            this.cbBoxCategory.Name = "cbBoxCategory";
            this.cbBoxCategory.Size = new System.Drawing.Size(176, 33);
            this.cbBoxCategory.TabIndex = 7;
            // 
            // gnBtnTopSelling
            // 
            this.gnBtnTopSelling.AutoRoundedCorners = true;
            this.gnBtnTopSelling.BorderRadius = 26;
            this.gnBtnTopSelling.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnTopSelling.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.gnBtnTopSelling.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.gnBtnTopSelling.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.gnBtnTopSelling.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnBtnTopSelling.ForeColor = System.Drawing.Color.White;
            this.gnBtnTopSelling.Location = new System.Drawing.Point(830, 35);
            this.gnBtnTopSelling.Name = "gnBtnTopSelling";
            this.gnBtnTopSelling.Size = new System.Drawing.Size(204, 54);
            this.gnBtnTopSelling.TabIndex = 6;
            this.gnBtnTopSelling.Text = "Tra cứu";
            this.gnBtnTopSelling.Click += new System.EventHandler(this.gnBtnTopSelling_Click);
            // 
            // dateTimePickerToTopSelling
            // 
            this.dateTimePickerToTopSelling.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerToTopSelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerToTopSelling.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerToTopSelling.Location = new System.Drawing.Point(399, 46);
            this.dateTimePickerToTopSelling.Name = "dateTimePickerToTopSelling";
            this.dateTimePickerToTopSelling.Size = new System.Drawing.Size(200, 34);
            this.dateTimePickerToTopSelling.TabIndex = 5;
            // 
            // dateTimePickerFromTopSelling
            // 
            this.dateTimePickerFromTopSelling.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFromTopSelling.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFromTopSelling.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFromTopSelling.Location = new System.Drawing.Point(193, 46);
            this.dateTimePickerFromTopSelling.Name = "dateTimePickerFromTopSelling";
            this.dateTimePickerFromTopSelling.Size = new System.Drawing.Size(200, 34);
            this.dateTimePickerFromTopSelling.TabIndex = 4;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTo.Location = new System.Drawing.Point(414, 27);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(200, 41);
            this.dateTimePickerTo.TabIndex = 6;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerFrom.Location = new System.Drawing.Point(184, 27);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(200, 41);
            this.dateTimePickerFrom.TabIndex = 5;
            // 
            // fOldDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1597, 809);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel5);
            this.Name = "fOldDashboard";
            this.Text = "fOldDashboard";
            this.Load += new System.EventHandler(this.fOldDashboard_Load);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart3Category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSelling)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel5;
        private Guna.UI2.WinForms.Guna2Button gnBtnRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3Category;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Panel panel7;
        private Guna.UI2.WinForms.Guna2Button gnBtn3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSelling;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopRevenue;
        private System.Windows.Forms.ComboBox cbBoxCategory;
        private Guna.UI2.WinForms.Guna2Button gnBtnTopSelling;
        private System.Windows.Forms.DateTimePicker dateTimePickerToTopSelling;
        private System.Windows.Forms.DateTimePicker dateTimePickerFromTopSelling;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
    }
}