using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DoAnShopOnl
{
    public partial class deviceUct : UserControl
    {
        public deviceUct()
        {
            InitializeComponent();
        }
        public int id;
        public int idCategory;
        public string name;
        public int price;
        public int lowPrice;
        public int highPrice;
        public string brand;
        public string imageSource;

        public string monitor;
        public string cpu;
        public string gpu;
        public string ram;
        public string rom;
        public int battery;
        public string camera;
        public string os;
        public int remain;

        public int quantity = 0;

        int rateCount = 0;
        public float averageStar = 0;
        int totalStar = 0;
        public PictureBox[] stars;

        public void LoadData(int id, int idCategory, string name, int lowPrice, int highPrice, string monitor, string cpu, string gpu, string ram, string rom, string brand, int battery, string camera, string os, string imageSource, int remain)
        {
            this.id = id;
            this.name = name;

            this.lowPrice = lowPrice;
            this.highPrice = highPrice;

            if(lowPrice < highPrice)
            {
                this.price = lowPrice;
                lblHighPrice.Text = highPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

                float discount = ((float)highPrice - (float)lowPrice)/(float)lowPrice * 100;
                lblDiscountPercent.Text = "-" + ((int)discount).ToString() + "%";
            }
            else
            {
                this.price = highPrice;
                lblHighPrice.Visible = false;
                lblDiscountPercent.Visible = false;
            }

            this.brand = brand;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.rom = rom;
            this.battery = battery;
            this.camera = camera;
            this.os = os;
            this.remain = remain;
            this.monitor = monitor;
            this.imageSource = imageSource;
            this.idCategory = idCategory;

            lblName.Text = this.name;
            lblPrice.Text = this.price.ToString("N0", new CultureInfo("es-ES")) +"đ";
            lblBrand.Text = this.brand;
            ptBoxImage.BackgroundImage = Bitmap.FromFile(this.imageSource);

            LoadAvarageStars();
        }

        private void deviceUct_Click(object sender, EventArgs e)
        {
            fDeviceInfo deviceInfo = new fDeviceInfo();
            deviceInfo.deviceName = name;
            deviceInfo.brand = brand;
            deviceInfo.id = id;
            deviceInfo.uct = this;
            deviceInfo.price = price;
            
            if(price == highPrice)
            {
                deviceInfo.lblHighPrice.Visible = false;
            }
            else
            {
                deviceInfo.lblHighPrice.Visible = true;
            }

            deviceInfo.highPrice = highPrice;

            deviceInfo.cpu = cpu;
            deviceInfo.gpu = gpu;
            deviceInfo.ram = ram;
            deviceInfo.rom = rom;
            deviceInfo.battery = battery;
            deviceInfo.camera = camera;
            deviceInfo.os = os;
            deviceInfo.price = price;
            deviceInfo.monitor = monitor;
            deviceInfo.quantity = quantity;

            deviceInfo.deviceImagePath = imageSource;

            deviceInfo.baseAverageStar = averageStar;
            deviceInfo.baseRateCount = rateCount;

            if(deviceInfo.IsDisposed)
            {
                quantity = deviceInfo.quantity;
            }

            deviceInfo.ShowDialog();
            this.Show();
            LoadAvarageStars();
        }

        public void LoadAvarageStars()
        {
            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Comment"; // Directory path to search
            string fileNameToFind = $"{name}.txt"; // File name to find


            SearchFiles(directoryPath, fileNameToFind);
        }

        string commentFile;

        void SearchFiles(string directoryPath, string fileNameToFind)
        {
            rateCount = 0;
            totalStar = 0;
            averageStar = 0;
            
            try
            {
                // Search for files in the current directory
                string[] files = Directory.GetFiles(directoryPath, fileNameToFind, SearchOption.TopDirectoryOnly);

                string commentFilePath = Path.Combine(directoryPath, fileNameToFind);


               //Get this device comment file
               for (int i = 0; i < files.Length; i++)
                {
                    if (files[i] == commentFilePath)
                    {
                        commentFile = files[i];
                        break;
                    }
                }

                if (commentFile == null) return;

                // Check if the file is found
                string[] lines = File.ReadAllLines(commentFile);

                if (lines.Length <= 0) return;

                foreach (string line in lines)
                {
                    rateCount++;
                    // Split the line by '*'
                    string[] parts = line.Split('*');

                    int star = Convert.ToInt32(parts[5]);
                    totalStar += star;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            averageStar = (float)Math.Round((float)totalStar / (float)rateCount, 1);
            lblAverageStar.Text = averageStar.ToString();
            lblRateCount.Text = "(" + rateCount.ToString() + ")";

            stars = new PictureBox[] { pb1, pb2, pb3, pb4, pb5 };

            for (int i = 0; i < (int)averageStar; i++)
            {
                if (i < (int)averageStar)
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_on; // Set on/star_on image for previous stars
                }
                else
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off; // Set off/star_off image for subsequent stars
                }
            }
        }

        private void pb1_Click(object sender, EventArgs e)
        {

        }

        private void lblAverageStar_Click(object sender, EventArgs e)
        {

        }

        private void pb2_Click(object sender, EventArgs e)
        {

        }

        private void pb3_Click(object sender, EventArgs e)
        {

        }

        private void pb4_Click(object sender, EventArgs e)
        {

        }

        private void pb5_Click(object sender, EventArgs e)
        {

        }
    }
}
