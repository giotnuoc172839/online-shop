using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl.Admin
{
    public partial class fModifyProduct : Form
    {
        public fModifyProduct()
        {
            InitializeComponent();
        }

        public int id;
        public int idCategory;
        public string name;
        public int lowPrice;
        public int highPrice;
        public string monitor;
        public string cpu;
        public string gpu;
        public string ram;
        public string rom;
        public string brand;
        public string battery;
        public string camera;
        public string os;
        public string imageSource;
        public int remain;

        public DataTable brandDt;
        public DataTable categoryDt;

        public void LoadData()
        {
            txtBoxName.Text = name;
            txtBoxBattery.Text = battery;
            txtBoxCamera.Text = camera;
            txtBoxRam.Text = ram;
            txtBoxRom.Text = rom;
            txtBoxPrice.Text = lowPrice.ToString();
            txtBoxHighPrice.Text = highPrice.ToString();
            txtBoxCpu.Text = cpu;
            txtBoxGpu.Text = gpu;
            txtBoxImageSource.Text = imageSource;
            txtBoxOs.Text = os;
            txtBoxMonitor.Text = monitor;
            numRemain.Value = remain;

            //cbBoxBrand.Text = brand;

            ptBoxImageSource.BackgroundImage = Bitmap.FromFile(txtBoxImageSource.Text);

            
        }

        private void ptBoxDefault_Click(object sender, EventArgs e)
        {
            // Create an instance of the OpenFileDialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // Configure the OpenFileDialog
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All Files|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                // Show the dialog and get the result
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string filePath = openFileDialog.FileName;

                    // Set the file path to the TextBox
                    txtBoxImageSource.Text = filePath;

                    ptBoxImageSource.BackgroundImage = Bitmap.FromFile(filePath);
                }
            }
        }


        private void gnBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fModifyProduct_Load(object sender, EventArgs e)
        {

        }

        public void LoadCbBox()
        {
            cbBoxBrand.DisplayMember = "brand";
            cbBoxBrand.ValueMember = "idBrand";

            cbBoxBrand.DataSource = brandDt;

            cbBoxCategory.DisplayMember = "category";
            cbBoxCategory.ValueMember = "idCategory";

            cbBoxCategory.DataSource = categoryDt;
        }

        void OnlyNumberTextBoxPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // If the key is not a valid input, prevent it from being entered into the TextBox
                    e.Handled = true;
                }
            }
        }
    }
}
