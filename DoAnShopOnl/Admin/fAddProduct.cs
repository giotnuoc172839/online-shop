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
    public partial class fAddProduct : Form
    {
        public fAddProduct()
        {
            InitializeComponent();
        }

        public DataTable deviceDt;

        private void gnBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gnBtnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxName.Text) && !string.IsNullOrEmpty(txtBoxOs.Text)
                 && !string.IsNullOrEmpty(txtBoxPrice.Text) && !string.IsNullOrEmpty(txtBoxMonitor.Text)
                 && !string.IsNullOrEmpty(txtBoxCpu.Text) && !string.IsNullOrEmpty(txtBoxGpu.Text)
                 && !string.IsNullOrEmpty(txtBoxRam.Text) && !string.IsNullOrEmpty(txtBoxRom.Text)
                 && !string.IsNullOrEmpty(txtBoxBattery.Text) && !string.IsNullOrEmpty(txtBoxImageSource.Text)
                 && !string.IsNullOrEmpty(txtBoxHighPrice.Text))
            {
                DataRow newRow = deviceDt.NewRow();
                newRow["name"] = txtBoxName.Text;

                if (int.Parse(txtBoxPrice.Text) > int.Parse(txtBoxHighPrice.Text))
                {
                    newRow["lowPrice"] = decimal.Parse(txtBoxHighPrice.Text); // Make sure to handle parsing errors
                    newRow["highPrice"] = decimal.Parse(txtBoxHighPrice.Text);
                }
                else
                {
                    newRow["lowPrice"] = decimal.Parse(txtBoxPrice.Text); // Make sure to handle parsing errors
                    newRow["highPrice"] = decimal.Parse(txtBoxHighPrice.Text);
                }
                newRow["monitor"] = txtBoxMonitor.Text;
                newRow["cpu"] = txtBoxCpu.Text;
                newRow["gpu"] = txtBoxGpu.Text;
                newRow["ram"] = txtBoxRam.Text;
                newRow["rom"] = txtBoxRom.Text;
                newRow["battery"] = txtBoxBattery.Text;
                newRow["camera"] = txtBoxCamera.Text;
                newRow["os"] = txtBoxOs.Text;
                newRow["imageSource"] = txtBoxImageSource.Text;
                newRow["remain"] = (int)numRemain.Value;
                newRow["idCategory"] = (int)(cbBoxCategory.SelectedIndex) + 1;
                newRow["brand"] = cbBoxBrand.Text;
                newRow["id"] = deviceDt.Rows.Count;

                // Add the DataRow to the DataTable.
                deviceDt.Rows.Add(newRow);

                MessageBox.Show("Thêm thiết bị mới thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm thiết bị mới không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
