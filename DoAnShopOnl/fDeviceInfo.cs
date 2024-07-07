using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace DoAnShopOnl
{
    public partial class fDeviceInfo : Form
    {
        public fDeviceInfo()
        {
            InitializeComponent();
        }
        public int gender;
        public DataTable commentDt = null;
        public string maleAvaPath = @"D:\Lap trinh C#\FirstApp\FirstApp\bin\Debug\Chat\ava\1.png";
        public string femaleAvaPath = @"D:\Lap trinh C#\FirstApp\FirstApp\bin\Debug\Chat\ava\4.png";
        public string avaPath;

        public int id;
        public string deviceName;
        public int price;
        public int highPrice;
        public string brand;
        public string deviceImagePath;
        public List<string> deviceImageList;
        public int imageIndex = 0;

        public string monitor;
        public string cpu;
        public string gpu;
        public string ram;
        public string rom;
        public int battery;
        public string camera;
        public string os;
        public int quantity;

        public const int NUM_STARS = 5;
        public PictureBox[] stars;
        public PictureBox[] rateStars;
        PictureBox[] sidePtBoxes;
        public int starCount = 0;

        int yPos = 0; // Initial y-position
        int verticalSpacing = 85; // Vertical spacing between comments

        List<deviceUct> cart = new List<deviceUct>();

        int rateCount = 0;
        float averageStar = 0;
        int totalStar = 0;

        public float baseAverageStar = 0;
        public int baseRateCount = 0;

        private void fDeviceInfo_Load(object sender, EventArgs e)
        {
            avaPath = femaleAvaPath;
            pbAva.BackgroundImage = Bitmap.FromFile(avaPath);

            commentDt = new DataTable();

            stars = new PictureBox[] { pb1, pb2, pb3, pb4, pb5 };
            rateStars = new PictureBox[] { pbStar1, pbStar2, pbStar3, pbStar4, pbStar5 };
            sidePtBoxes = new PictureBox[] { ptBoxSmaillImage1, ptBoxSmaillImage2, ptBoxSmaillImage3 };

            LoadDeviceInfo();

            LoadComment();
            averageStar = baseAverageStar;
            rateCount = baseRateCount;

            pb1.Click += new EventHandler(Star_Click);
            pb2.Click += new EventHandler(Star_Click);
            pb3.Click += new EventHandler(Star_Click);
            pb4.Click += new EventHandler(Star_Click);
            pb5.Click += new EventHandler(Star_Click);

            cart = DataProvider.Instance.cart;

            //Star
            for (int i = 0; i < (int)averageStar; i++)
            {
                if (i < (int)averageStar)
                {
                    rateStars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_on; // Set on/star_on image for previous stars
                }
                else
                {
                    rateStars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off; // Set off/star_off image for subsequent stars
                }
            }

            lblAverageStar.Text = averageStar.ToString();
            lblRateCount.Text = rateCount.ToString() + " đánh giá";

            ResizeAsk();

        }

        int GetGender()
        {
            if (rBtnFemale.Checked)
            {
                gender = 0; //female
                
            }
            else
            {
                gender = 1; //male

            }
            return gender;
        }


        private void btnSendComment_Click(object sender, EventArgs e)
        {
            if (starCount == 0)
            {
                lblRatingError.Visible = true;
            }
            if (string.IsNullOrEmpty(txtBoxName.Text))
            {
                lblNameError.Visible = true;
            }
            if (string.IsNullOrEmpty(txtBoxComment.Text))
            {
                lblCommentError.Visible = true;
            }

            //Send successfully
            if (!string.IsNullOrEmpty(txtBoxName.Text) && !string.IsNullOrEmpty(txtBoxComment.Text) && starCount != 0)
            {
                CommentFile f = new CommentFile();
                f.userName = txtBoxName.Text;
                f.comment = txtBoxComment.Text;
                f.deviceName = deviceName;
                f.avaPath = avaPath;
                f.gender = GetGender();
                f.dateTime = DateTime.Now.ToString();
                f.starCount = starCount;
                f.SaveTxtFiles();

                lblCommentError.Visible = false;
                lblNameError.Visible = false;
                lblRatingError.Visible = false;

                txtBoxName.Clear();
                txtBoxComment.Clear();

                SearchFiles(@"D:\Lap trinh C#\DoAnShopOnl\Comment", $"{lblDeviceName.Text}.txt");

                //reset
                starCount = 0;
                foreach (PictureBox star in stars)
                {
                    star.BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off;
                }
            }

            
        }

        void LoadComment()
        {
            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Comment"; // Directory path to search
            string fileNameToFind = $"{lblDeviceName.Text}.txt"; // File name to find


            SearchFiles(directoryPath, fileNameToFind);
            //reset
            starCount = 0;
            foreach (PictureBox star in stars)
            {
                star.BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off;
            }
        }

        void SearchFiles(string directoryPath, string fileNameToFind)
        {
            rateCount = 0;
            totalStar = 0;
            averageStar = 0;
            try
            {
                // Search for files in the current directory
                string[] files = Directory.GetFiles(directoryPath, fileNameToFind, SearchOption.TopDirectoryOnly);

                // Check if the file is found in the current directory
                if (files.Length > 0)
                {
                    pnComment.Controls.Clear();
                    yPos = 0;
                    foreach (string file in files)
                    {
                        string[] lines = File.ReadAllLines(file);

                        foreach (string line in lines)
                        {
                            rateCount++;
                            // Split the line by '*'
                            string[] parts = line.Split('*');
                            commentUct comment = new commentUct();
                            comment.LoadData(parts[0], parts[1], int.Parse(parts[2]), parts[3], parts[4], int.Parse(parts[5]));

                            int star = Convert.ToInt32(parts[5]);
                            totalStar += star;

                            comment.Location = new Point(0, yPos);
                            yPos += verticalSpacing;
                            pnComment.Controls.Add(comment);
                        }

                    }
                }
                else
                {
                    // If the file is not found in the current directory, search subdirectories
                    string[] subDirectories = Directory.GetDirectories(directoryPath);
                    foreach (string subDirectory in subDirectories)
                    {
                        SearchFiles(subDirectory, fileNameToFind);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            averageStar = (float)Math.Round((float)totalStar / (float)rateCount, 1);


            for (int i = 0; i < (int)averageStar; i++)
            {
                if (i < (int)averageStar)
                {
                    rateStars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_on; // Set on/star_on image for previous stars
                }
                else
                {
                    rateStars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off; // Set off/star_off image for subsequent stars
                }
            }

            lblAverageStar.Text = averageStar.ToString();
            lblRateCount.Text = rateCount.ToString() + " đánh giá";
        }

        void LoadDeviceInfo()
        {
            lblDeviceName.Text = deviceName;
            lblMonitor.Text = monitor;
            lblOs.Text = os;
            lblCamera.Text = camera;
            lblGpu.Text = gpu;
            lblCpu.Text = cpu;
            lblRam.Text = ram + " GB";
            lblRom.Text = rom + " GB";
            lblBattery.Text = battery.ToString("N0", new CultureInfo("es-ES")) + " mAh";
            lblPrice.Text = price.ToString("N0", new CultureInfo("es-ES")) +"đ";
            lblHighPrice.Text = highPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            float discount = ((float)highPrice - (float)price) / (float)price * 100;

            if (price == highPrice)
            {
                lblDiscountPercent.Visible = false;
            }
            else
            {
                lblDiscountPercent.Visible = true;
                lblDiscountPercent.Text = "-" + ((int)discount).ToString() + "%";
            }

            lblBrand.Text = brand;
            pbSongImage.BackgroundImage = Bitmap.FromFile(deviceImagePath);

            LoadImageList();
        }



        private void pbAva_Click(object sender, EventArgs e)
        {
            // Open file dialog to select an image
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Load the selected image into PictureBox
                pbAva.BackgroundImage = new Bitmap(openFileDialog.FileName);
                avaPath = openFileDialog.FileName;
            }
        }

        private void Star_Click(object sender, EventArgs e)
        {
            PictureBox clickedStar = (PictureBox)sender;
            int clickedStarIndex = int.Parse(clickedStar.Tag.ToString());

            foreach (PictureBox star in stars)
            {
                star.BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off;
            }

            // Loop through all stars and toggle their state
            for (int i = 0; i < clickedStarIndex; i++)
            {
                if (i < clickedStarIndex)
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_on; // Set on/star_on image for previous stars
                }
                else
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off; // Set off/star_off image for subsequent stars
                }
            }

            starCount = clickedStarIndex;
        }

        private void ptReturn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            bool deviceExistInCart = false;

            deviceUct deviceUct = new deviceUct();
            deviceUct.id = id;
            deviceUct.imageSource = deviceImagePath;
            deviceUct.name = deviceName;
            deviceUct.price = price;
            deviceUct.highPrice = highPrice;
            deviceUct.quantity = quantity;

            foreach (deviceUct device in cart)
            {
                if (deviceUct.id == device.id && deviceUct.name == device.name)
                {
                    deviceExistInCart = true;
                    break;
                }
                else if (deviceUct.id != device.id || deviceUct.name != device.name)
                {
                    deviceExistInCart = false;
                }
            }

            if (deviceExistInCart)
            {
                foreach (deviceUct device in cart)
                {
                    if (deviceUct.id == device.id && deviceUct.name == device.name)
                    {
                        //device.quantity++;
                        //deviceUct.quantity = device.quantity;
                        MessageBox.Show("Sản phẩm này đã có trong giỏ hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    }
                }
            }

            if (deviceUct.quantity < 1 && !deviceExistInCart)
            {
                deviceUct.quantity = 1;
                cart.Add(deviceUct);
            }

            DataProvider.Instance.cart = this.cart;
        }

        void SendMessageThroughMail(string email, string deviceName, string message, List<string> imagePath)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("21521900@gm.uit.edu.vn");

            SmtpClient smtp = new SmtpClient
            {
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mail.From.Address, "janr mvln ibfg pkdd"),
                Host = "smtp.gmail.com"
            };

            mail.To.Add(new MailAddress(email));
            mail.IsBodyHtml = true;
            mail.Subject = "Hỏi đáp về sản phẩm " + deviceName + " từ " + email;
            mail.Body = message;

            bool isFilesExist = true;

            foreach(string path in imagePath)
            {
                if(!File.Exists(path)) //not exist
                {
                    isFilesExist = false;
                    break;
                }
            }

            // Add the image as an attachment
            if (isFilesExist && imagePath.Count > 0)
            {
                foreach(string filePath in imagePath)
                {
                    Attachment attachment = new Attachment(filePath);
                    mail.Attachments.Add(attachment);
                }
            }
            else
            {
                MessageBox.Show("The image files does not exist.");
                return;
            }

            try
            {
                smtp.Send(mail);
                MessageBox.Show("Gửi thành công! Chúng tôi sẽ liên hệ bạn sớm nhất", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi mail thất bại : " + ex.Message);
            }
        }

        List<string> imageList = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                SendMessageThroughMail(textBox1.Text, deviceName, textBox2.Text, imageList);
                imageList.Clear();
                flowPnSendImage.Controls.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
            }
            else
            {
                MessageBox.Show("Vui lòng điên đầy đủ thông tin!", "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResizeAsk();
        }

        void ResizeAsk()
        {
            if (imageList.Count > 0)
            {
                flowPnSendImage.Visible = true;
                button2.Location = new Point(31, 440);
                panel3.Size = new Size(1143, 550);
            }
            else
            {
                flowPnSendImage.Visible = false;
                button2.Location = new Point(31, 300);
                panel3.Size = new Size(1143, 400);
            }
        }

        private void ptBoxAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFile = openFileDialog.FileName;
                        imageList.Add(selectedFile);

                        imageAttach image = new imageAttach();
                        image.LoadImage(selectedFile);
                        flowPnSendImage.Controls.Add(image);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while trying to load the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            ResizeAsk();
        }

        string imagePath = @"D:\Lap trinh C#\DoAnShopOnl\Images";
        string imageFolder = @"D:\Lap trinh C#\DoAnShopOnl\ImageSource\";

        void LoadImageList()
        {
            deviceImageList = new List<string>();         

            deviceImageList.Add(deviceImagePath);

            string fileName = deviceName + ".txt";
            string imageFilePath = Path.Combine(imagePath, fileName);

            string[] lines = File.ReadAllLines(imageFilePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                for(int i = 0; i < parts.Length; i++)
                {
                    string image = imageFolder + parts[i];
                    deviceImageList.Add(image);
                }
            }

            //Load small image
            for(int i = 0; i < deviceImageList.Count; i++)
            {
                if (sidePtBoxes.Length < i) break; //Check if there are enough picturebox for side images
                sidePtBoxes[i].BackgroundImage = Bitmap.FromFile(deviceImageList[i]);
            }
        }

        private void ptBoxNext_Click(object sender, EventArgs e)
        {
            NextImage();
        }

        private void ptBoxBack_Click(object sender, EventArgs e)
        {
            BackImage();
        }

        void BackImage()
        {
            imageIndex--;

            if (imageIndex < 0)
            {
                imageIndex = deviceImageList.Count - 1;
            }

            pbSongImage.BackgroundImage = Bitmap.FromFile(deviceImageList[imageIndex]);

            foreach(PictureBox smallImage in flowPnSmallImage.Controls)
            {
                smallImage.BorderStyle = BorderStyle.None;
            }

            sidePtBoxes[imageIndex].BorderStyle = BorderStyle.FixedSingle;
        }

        void NextImage()
        {
            imageIndex++;

            if (imageIndex >= deviceImageList.Count)
            {
                imageIndex = 0;
            }

            pbSongImage.BackgroundImage = Bitmap.FromFile(deviceImageList[imageIndex]);

            foreach (PictureBox smallImage in flowPnSmallImage.Controls)
            {
                smallImage.BorderStyle = BorderStyle.None;
            }

            sidePtBoxes[imageIndex].BorderStyle = BorderStyle.FixedSingle;
        }

        private void rBtnMale_Click(object sender, EventArgs e)
        {
            avaPath = maleAvaPath;
            pbAva.BackgroundImage = Bitmap.FromFile(avaPath);
        }

        private void rBtnFemale_Click(object sender, EventArgs e)
        {
            avaPath = femaleAvaPath;
            pbAva.BackgroundImage = Bitmap.FromFile(avaPath);
        }

        public deviceUct uct;

        private void button1_Click(object sender, EventArgs e)
        {
            fBuyNow f = new fBuyNow();
            f.LoadData(this.uct);


            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
