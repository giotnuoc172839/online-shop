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
    public partial class fProduct : Form
    {
        public fProduct()
        {
            InitializeComponent();
        }

        public DataTable deviceDt = new DataTable();
        DataTable brandDt = new DataTable();
        DataTable categoryDt = new DataTable();

        string deviceFilePath = @"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt";
        string brandFilePath = @"D:\Lap trinh C#\DoAnShopOnl\brand.txt";
        string categoryFilePath = @"D:\Lap trinh C#\DoAnShopOnl\category.txt";
        string defaultImageSource = @"D:\Lap trinh C#\FirstApp\FirstApp\image.png";

        string brand;
        int id = -1;

        private void fProduct_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(deviceFilePath);
            brandDt = DataProvider.Instance.LoadBrandDataTableFromTextFile(brandFilePath);
            categoryDt = DataProvider.Instance.LoadCategoryDataTableFromTextFile(categoryFilePath);

            Font font = new Font("Arial", 14);

            dtgvDevice.Font = font;
            //LoadDtgvDevice();
            LoadData();

            LoadCbBox();

            txtBoxPrice.KeyPress += new KeyPressEventHandler(OnlyNumberTextBoxPress);
            txtBoxBattery.KeyPress += new KeyPressEventHandler(OnlyNumberTextBoxPress);

        }

        void LoadDtgvDevice()
        {
            dtgvDevice.DataSource = deviceDt;
            dtgvDevice.Columns["id"].HeaderText = "Mã số";
            dtgvDevice.Columns["idCategory"].HeaderText = "Mã số loại sản phẩm";
            dtgvDevice.Columns["name"].HeaderText = "Tên thiết bị";
            dtgvDevice.Columns["lowPrice"].HeaderText = "Giá khuyến mãi";
            dtgvDevice.Columns["highPrice"].HeaderText = "Giá gốc";
            dtgvDevice.Columns["monitor"].HeaderText = "Màn hình";
            dtgvDevice.Columns["brand"].HeaderText = "Hãng";
            dtgvDevice.Columns["battery"].HeaderText = "Pin";
            dtgvDevice.Columns["os"].HeaderText = "Hệ điều hành";
            dtgvDevice.Columns["imageSource"].HeaderText = "Nguồn ảnh";
            dtgvDevice.Columns["remain"].HeaderText = "Số lượng";
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

        void LoadCbBox()
        {
            cbBoxBrand.DisplayMember = "brand";
            cbBoxBrand.ValueMember = "idBrand";

            cbBoxBrand.DataSource = brandDt;

            cbBoxCategory.DisplayMember = "category";
            cbBoxCategory.ValueMember = "idCategory";

            cbBoxCategory.DataSource = categoryDt;
        }

        private void dtgvDevice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            int idCategory = 0;

            DataGridViewRow row = dtgvDevice.Rows[rowId];

            txtBoxName.Text = row.Cells[2].Value.ToString();
            txtBoxPrice.Text = row.Cells[3].Value.ToString();
            txtBoxHighPrice.Text = row.Cells[4].Value.ToString();
            txtBoxMonitor.Text = row.Cells[5].Value.ToString();
            txtBoxCpu.Text = row.Cells[6].Value.ToString();
            txtBoxGpu.Text = row.Cells[7].Value.ToString();
            txtBoxRam.Text = row.Cells[8].Value.ToString();
            txtBoxRom.Text = row.Cells[9].Value.ToString();
            txtBoxBattery.Text = row.Cells[11].Value.ToString();
            txtBoxCamera.Text = row.Cells[12].Value.ToString();
            txtBoxOs.Text = row.Cells[13].Value.ToString();
            txtBoxImageSource.Text = row.Cells[14].Value.ToString();

            numRemain.Value = (int)row.Cells[15].Value;
            cbBoxBrand.Text = row.Cells[10].Value.ToString();
            idCategory = (int)row.Cells[1].Value;
            id = (int)row.Cells[0].Value;

            ptBoxImageSource.BackgroundImage = Bitmap.FromFile(txtBoxImageSource.Text);

            switch (idCategory)
            {
                case 1:
                    cbBoxCategory.Text = "Phone";
                    break;

                case 2:
                    cbBoxCategory.Text = "Laptop";
                    break;

                case 3:
                    cbBoxCategory.Text = "Ipad";
                    break;
            }
        }

        private void cbBoxBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            brand = comboBox.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
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

                if(int.Parse(txtBoxPrice.Text) > int.Parse(txtBoxHighPrice.Text))
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
                newRow["idCategory"] = (int)(cbBoxCategory.SelectedValue);
                newRow["brand"] = cbBoxBrand.Text;
                newRow["id"] = deviceDt.Rows.Count;

                // Add the DataRow to the DataTable.
                deviceDt.Rows.Add(newRow);

                // Optionally, refresh the DataGridView to reflect the new row.
                dtgvDevice.DataSource = null;
                LoadDtgvDevice();

                ptBoxImageSource.BackgroundImage = Bitmap.FromFile(defaultImageSource);

                MessageBox.Show("Thêm thiết bị mới thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm thiết bị mới không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            // Find the row in the DataTable by the ID.
            DataRow[] rowsToUpdate = deviceDt.Select($"id = {id}");

            if (id == -1) return;

            if (rowsToUpdate.Length > 0)
            {
                DataRow rowToUpdate = rowsToUpdate[0];

                // Update the DataRow with the values from the input controls.
                rowToUpdate["name"] = txtBoxName.Text;
                if (int.Parse(txtBoxPrice.Text) > int.Parse(txtBoxHighPrice.Text))
                {
                    rowToUpdate["lowPrice"] = decimal.Parse(txtBoxHighPrice.Text); // Make sure to handle parsing errors
                    rowToUpdate["highPrice"] = decimal.Parse(txtBoxHighPrice.Text);
                }
                else
                {
                    rowToUpdate["lowPrice"] = decimal.Parse(txtBoxPrice.Text); // Make sure to handle parsing errors
                    rowToUpdate["highPrice"] = decimal.Parse(txtBoxHighPrice.Text);
                }
                rowToUpdate["monitor"] = txtBoxMonitor.Text;
                rowToUpdate["cpu"] = txtBoxCpu.Text;
                rowToUpdate["gpu"] = txtBoxGpu.Text;
                rowToUpdate["ram"] = txtBoxRam.Text;
                rowToUpdate["rom"] = txtBoxRom.Text;
                rowToUpdate["battery"] = txtBoxBattery.Text;
                rowToUpdate["camera"] = txtBoxCamera.Text;
                rowToUpdate["os"] = txtBoxOs.Text;
                rowToUpdate["imageSource"] = txtBoxImageSource.Text;
                rowToUpdate["remain"] = (int)numRemain.Value;
                rowToUpdate["idCategory"] = (int)cbBoxCategory.SelectedValue;
                rowToUpdate["brand"] = cbBoxBrand.Text;

                // Optionally, refresh the DataGridView to reflect the modified row.
                dtgvDevice.DataSource = null;
                LoadDtgvDevice();

                ptBoxImageSource.BackgroundImage = Bitmap.FromFile(defaultImageSource);
                
                MessageBox.Show("Cập nhật thiết bị thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

               
            }
            else
            {
                MessageBox.Show("Cập nhật thiết bị không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Find the row in the DataTable by the ID.
            DataRow[] rowsToDelete = deviceDt.Select($"id = {id}");

            if (id == -1) return;

            if (rowsToDelete.Length > 0)
            {
                DataRow rowToDelete = rowsToDelete[0];

                // Delete the DataRow from the DataTable.
                deviceDt.Rows.Remove(rowToDelete);

                // Optionally, refresh the DataGridView to reflect the deleted row.
                dtgvDevice.DataSource = null;
                LoadDtgvDevice();

                ptBoxImageSource.BackgroundImage = Bitmap.FromFile(defaultImageSource);
                MessageBox.Show("Xóa thiết bị thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Xóa thiết bị không thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void fProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataProvider.Instance.SaveDataTableToTextFile(deviceDt, deviceFilePath);
        }

        void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvidCategory);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvlowPrice);
            lb.Items.Add(dgvhighPrice);
            lb.Items.Add(dgvmonitor);
            lb.Items.Add(dgvcpu);
            lb.Items.Add(dgvgpu);
            lb.Items.Add(dgvram);
            lb.Items.Add(dgvrom);
            lb.Items.Add(dgvBrand);
            lb.Items.Add(dgvbattery);
            lb.Items.Add(dgvcamera);
            lb.Items.Add(dgvos);
            lb.Items.Add(dgvimageSource);
            lb.Items.Add(dgvremain);

            for (int i = 0; i < lb.Items.Count; i++)
            {
                string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;                
                guna2DataGridView1.Columns[colNam1].DataPropertyName = deviceDt.Columns[i].ToString();
            }

            guna2DataGridView1.DataSource = deviceDt;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvEdit")
            {
                fModifyProduct f = new fModifyProduct();
                
                f.brandDt = brandDt;
                f.categoryDt = categoryDt;

                f.Show();

                f.id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                id = f.id;

                f.name = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvname"].Value);
                f.lowPrice = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvlowPrice"].Value);
                f.highPrice = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvhighPrice"].Value);
                f.monitor = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvmonitor"].Value);
                f.cpu = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcpu"].Value);
                f.gpu = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvgpu"].Value);
                f.ram = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvram"].Value);
                f.rom = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvrom"].Value);
                f.brand = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbrand"].Value);
                f.battery = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvbattery"].Value);
                f.camera = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvcamera"].Value);
                f.os = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvos"].Value);
                f.imageSource = Convert.ToString(guna2DataGridView1.CurrentRow.Cells["dgvimageSource"].Value);
                f.remain = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvremain"].Value);

                int idCategory = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvidCategory"].Value);


                f.LoadData();

                f.cbBoxBrand.Text = f.brand;

                switch (idCategory)
                {
                    case 1:
                        f.cbBoxCategory.Text = "Phone";
                        break;

                    case 2:
                        f.cbBoxCategory.Text = "Laptop";
                        break;

                    case 3:
                        f.cbBoxCategory.Text = "Ipad";
                        break;
                }

                f.gnBtnSave.Click += new EventHandler(gnBtnSave_Click);
                
            }

            if (guna2DataGridView1.CurrentCell.OwningColumn.Name == "dgvDel")
            {
                id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dgvid"].Value);

                // Find the row in the DataTable by the ID.
                DataRow[] rowsToDelete = deviceDt.Select($"id = {id}");

                if (id == -1) return;
                if (rowsToDelete.Length > 0)
                {
                    DataRow rowToDelete = rowsToDelete[0];

                    // Delete the DataRow from the DataTable.
                    deviceDt.Rows.Remove(rowToDelete);

                    MessageBox.Show("Xóa thiết bị thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Xóa thiết bị không thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        void gnBtnSave_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;

            fModifyProduct f = (fModifyProduct)btn.Parent;

            // Find the row in the DataTable by the ID.
            DataRow[] rowsToUpdate = deviceDt.Select($"id = {id}");

            if (id == -1) return;

            if (rowsToUpdate.Length > 0)
            {
                DataRow rowToUpdate = rowsToUpdate[0];

                // Update the DataRow with the values from the input controls.
                rowToUpdate["name"] = f.txtBoxName.Text;
                if (int.Parse(f.txtBoxPrice.Text) > int.Parse(f.txtBoxHighPrice.Text))
                {
                    rowToUpdate["lowPrice"] = decimal.Parse(f.txtBoxHighPrice.Text); // Make sure to handle parsing errors
                    rowToUpdate["highPrice"] = decimal.Parse(f.txtBoxHighPrice.Text);
                }
                else
                {
                    rowToUpdate["lowPrice"] = decimal.Parse(f.txtBoxPrice.Text); // Make sure to handle parsing errors
                    rowToUpdate["highPrice"] = decimal.Parse(f.txtBoxHighPrice.Text);
                }
                rowToUpdate["monitor"] = f.txtBoxMonitor.Text;
                rowToUpdate["cpu"] = f.txtBoxCpu.Text;
                rowToUpdate["gpu"] = f.txtBoxGpu.Text;
                rowToUpdate["ram"] = f.txtBoxRam.Text;
                rowToUpdate["rom"] = f.txtBoxRom.Text;
                rowToUpdate["battery"] = f.txtBoxBattery.Text;
                rowToUpdate["camera"] = f.txtBoxCamera.Text;
                rowToUpdate["os"] = f.txtBoxOs.Text;
                rowToUpdate["imageSource"] = f.txtBoxImageSource.Text;
                rowToUpdate["remain"] = (int)f.numRemain.Value;
                rowToUpdate["idCategory"] = (int)f.cbBoxCategory.SelectedIndex + 1;
                rowToUpdate["brand"] = f.cbBoxBrand.Text;

                ptBoxImageSource.BackgroundImage = Bitmap.FromFile(defaultImageSource);
                MessageBox.Show("Cập nhật thiết bị thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thiết bị không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gnBtnAdd_Click(object sender, EventArgs e)
        {
            fAddProduct f = new fAddProduct();

            f.Show();
            f.deviceDt = deviceDt;
        }
    }
}
