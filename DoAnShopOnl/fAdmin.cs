using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
        }

        DataTable deviceDt = new DataTable();
        DataTable accountDt = new DataTable();
        DataTable brandDt = new DataTable();
        DataTable categoryDt = new DataTable();
        DataTable billDt = new DataTable();

        string accountFilePath = @"D:\Lap trinh C#\DoAnShopOnl\account.txt";
        string deviceFilePath = @"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt";
        string brandFilePath = @"D:\Lap trinh C#\DoAnShopOnl\brand.txt";
        string categoryFilePath = @"D:\Lap trinh C#\DoAnShopOnl\category.txt";
        string billFolderPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
        string defaultImageSource = @"D:\Lap trinh C#\FirstApp\FirstApp\image.png";

        string brand;
        int id = -1;
        int idBrand = -1;
        int idStaff = -1;

        private void fAdmin_Load(object sender, EventArgs e)
        {
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(deviceFilePath);
            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(accountFilePath);
            brandDt = DataProvider.Instance.LoadBrandDataTableFromTextFile(brandFilePath);
            categoryDt = DataProvider.Instance.LoadCategoryDataTableFromTextFile(categoryFilePath);
            billDt = DataProvider.Instance.LoadAllBillDataTableFromTextFile();

            Font font = new Font("Arial", 10);

            dtgvBill.Font = font;
            dtgvAccount.Font = font;
            dtgvBillInfo.Font = font;
            dtgvBrand.Font = font;
            dtgvDevice.Font = font;

            LoadDtgvDevice();
            LoadDtgvAccount();
            LoadDtgvBill();
            LoadDtgvBrand();

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

        void LoadDtgvAccount()
        {
            dtgvAccount.DataSource = accountDt;
            dtgvAccount.Columns["id"].HeaderText = "Mã số";
            dtgvAccount.Columns["displayName"].HeaderText = "Tên";
            dtgvAccount.Columns["userName"].HeaderText = "Tên tài khoản";
            dtgvAccount.Columns["password"].HeaderText = "Mật khẩu";
            dtgvAccount.Columns["phone"].HeaderText = "Số điện thoại";
            dtgvAccount.Columns["type"].HeaderText = "Loại tài khoản";
            dtgvAccount.Columns["balance"].HeaderText = "Số dư";
        }
        
        void LoadDtgvBill()
        {
            dtgvBill.DataSource = billDt;
            dtgvBill.Columns["id"].HeaderText = "Mã số";
            dtgvBill.Columns["displayName"].HeaderText = "Tên";
            dtgvBill.Columns["gmail"].HeaderText = "Gmail";
            dtgvBill.Columns["phoneNumber"].HeaderText = "Số điện thoại";
            dtgvBill.Columns["address"].HeaderText = "Địa chỉ";
            dtgvBill.Columns["totalPrice"].HeaderText = "Tổng tiền";
            dtgvBill.Columns["billDetail"].HeaderText = "Chi tiết hóa đơn";
            dtgvBill.Columns["billDetail"].Visible = false;
            dtgvBill.Columns["dateTime"].HeaderText = "Thời gian mua hàng";
            dtgvBill.Columns["isPaid"].HeaderText = "Đã thanh toán";
        }

        void LoadDtgvBillInfo(DataTable dt)
        {
            dtgvBillInfo.DataSource = dt;
            dtgvBillInfo.Columns["id"].HeaderText = "Mã số";
            dtgvBillInfo.Columns["deviceName"].HeaderText = "Tên thiết bị";
            dtgvBillInfo.Columns["quantity"].HeaderText = "SL";
            dtgvBillInfo.Columns["price"].HeaderText = "Đơn giá";
            dtgvBillInfo.Columns["totalPrice"].HeaderText = "Thành tiền";
        }

        void LoadDtgvBrand()
        {
            dtgvBrand.DataSource = brandDt;
            dtgvBrand.Columns["idBrand"].HeaderText = "Mã số hãng";
            dtgvBrand.Columns["brand"].HeaderText = "Tên hãng";

        }

        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DataProvider.Instance.SaveDataTableToTextFile(deviceDt, deviceFilePath);
            //DataProvider.Instance.SaveDataTableToTextFile(accountDt, accountFilePath);
            //DataProvider.Instance.SaveDataTableToTextFile(brandDt, brandFilePath);
            
            //DataProvider.Instance.SaveDataTableToTextFile(categoryDt, categoryFilePath);
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

        void OnlyPhoneNumberTextBoxPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            if (textbox != null)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    // If the key is not a valid input, prevent it from being entered into the TextBox
                    e.Handled = true;
                }
                else if (!char.IsControl(e.KeyChar) && textbox.Text.Length >= 10)
                {
                    // If the length is greater than 10, prevent further input
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
                && !string.IsNullOrEmpty(txtBoxBattery.Text) && !string.IsNullOrEmpty(txtBoxImageSource.Text))
            {
                DataRow newRow = deviceDt.NewRow();
                newRow["name"] = txtBoxName.Text;
                newRow["price"] = decimal.Parse(txtBoxPrice.Text); // Make sure to handle parsing errors
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

                MessageBox.Show("Thêm thiết bị mới thành công !","Thành công",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                rowToUpdate["price"] = decimal.Parse(txtBoxPrice.Text); // Make sure to handle parsing errors
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

        private void dtgvBrand_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;
            DataGridViewRow row = dtgvBrand.Rows[rowId];

            txtBoxBrand.Text = row.Cells[1].Value.ToString();
            idBrand = (int)row.Cells[0].Value;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (idBrand == -1) return;

            if (!string.IsNullOrEmpty(txtBoxBrand.Text))
            {
                DataRow newRow = brandDt.NewRow();

                newRow["brand"] = txtBoxBrand.Text;
                newRow["idBrand"] = brandDt.Rows.Count;

                brandDt.Rows.Add(newRow);

                dtgvBrand.DataSource = null;
                LoadDtgvBrand();

                MessageBox.Show("Thêm hãng mới thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Thêm hãng mới không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnModifyBrand_Click(object sender, EventArgs e)
        {
            if (idBrand == -1) return;
            // Find the row in the DataTable by the ID.
            DataRow[] rowsToUpdate = brandDt.Select($"idBrand = {idBrand}");

            if (rowsToUpdate.Length > 0)
            {
                DataRow rowToUpdate = rowsToUpdate[0];

                // Update the DataRow with the values from the input controls.
                rowToUpdate["brand"] = txtBoxBrand.Text;

                // Optionally, refresh the DataGridView to reflect the modified row.
                dtgvBrand.DataSource = null;
                LoadDtgvBrand();
            }
        }

        private void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            if (idBrand == -1) return;
            // Find the row in the DataTable by the ID.
            DataRow[] rowsToDelete = brandDt.Select($"idBrand = {idBrand}");

            if (rowsToDelete.Length > 0)
            {
                DataRow rowToDelete = rowsToDelete[0];

                // Delete the DataRow from the DataTable.
                brandDt.Rows.Remove(rowToDelete);

                // Optionally, refresh the DataGridView to reflect the deleted row.
                dtgvBrand.DataSource = null;
                LoadDtgvBrand();
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

        
        private void dtgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            DataGridViewRow row = dtgvBill.Rows[rowId];

            string billInfoPath = row.Cells[6].Value.ToString();

            DataTable billInfo = new DataTable();

            billInfo = DataProvider.Instance.LoadBillInfoDataTableFromTextFile(billInfoPath);

            LoadDtgvBillInfo(billInfo);

            txtBoxBillId.Text = row.Cells[0].Value.ToString();
            txtBoxBillName.Text = row.Cells[1].Value.ToString();
            txtBoxBillEmail.Text = row.Cells[2].Value.ToString();
            txtBoxBillPhoneNumber.Text = row.Cells[3].Value.ToString();
            txtBoxBillAddress.Text = row.Cells[4].Value.ToString();

            int totalPrice = Convert.ToInt32(row.Cells[5].Value);
            txtBoxBillTotalPrice.Text = totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            txtBoxBillDate.Text = row.Cells[7].Value.ToString();

            int billIsPaid = Convert.ToInt32(row.Cells[8].Value);
            comboBoxIsPaid.SelectedIndex = billIsPaid;

            listViewBill.Clear();

            listViewBill.View = View.Details;
            listViewBill.FullRowSelect = true;
            listViewBill.GridLines = true;

            listViewBill.Columns.Add("ID");
            listViewBill.Columns.Add("Tên thiết bị");
            listViewBill.Columns.Add("Đơn giá");
            listViewBill.Columns.Add("SL");
            listViewBill.Columns.Add("Thành tiền");

            int totalListViewWidth = listViewBill.ClientSize.Width;

            // Set the widths for each column based on the percentage
            listViewBill.Columns[0].Width = (int)(totalListViewWidth * 0.1); // Column1
            listViewBill.Columns[1].Width = (int)(totalListViewWidth * 0.5); // Column2
            listViewBill.Columns[2].Width = (int)(totalListViewWidth * 0.15); // Column3
            listViewBill.Columns[3].Width = (int)(totalListViewWidth * 0.1); // Column4
            listViewBill.Columns[4].Width = (int)(totalListViewWidth * 0.15); // Column5

            foreach (DataRow billInfoRow in billInfo.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(billInfoRow[0].ToString());
                for (int i = 1; i < billInfo.Columns.Count; i++)
                {
                    listViewItem.SubItems.Add(billInfoRow[i].ToString());
                }
                listViewBill.Items.Add(listViewItem);
            }
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtBoxBillPhoneNumber.Text;

            int billId = int.Parse(txtBoxBillId.Text);

            if(string.IsNullOrEmpty(phoneNumber)) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("gmail", typeof(string));
            dt.Columns.Add("phoneNumber", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("totalPrice", typeof(long));
            dt.Columns.Add("billDetail", typeof(string));
            dt.Columns.Add("dateTime", typeof(string));
            dt.Columns.Add("isPaid", typeof(int));

            foreach (DataRow row in billDt.Rows)
            {
                if (row["phoneNumber"].ToString() == phoneNumber && int.Parse(row["id"].ToString()) == billId)
                {
                    DataRow dtRow = dt.NewRow();
                    dtRow["id"] = row["id"];
                    dtRow["displayName"] = row["displayName"];
                    dtRow["gmail"] = row["gmail"];
                    dtRow["phoneNumber"] = row["phoneNumber"];
                    dtRow["address"] = row["address"];
                    dtRow["totalPrice"] = row["totalPrice"];
                    dtRow["billDetail"] = row["billDetail"];
                    dtRow["dateTime"] = row["dateTime"];
                    dtRow["isPaid"] = comboBoxIsPaid.SelectedIndex;
                    dt.Rows.Add(dtRow);
                }
                else if(row["phoneNumber"].ToString() == phoneNumber && int.Parse(row["id"].ToString()) != billId)
                {
                    DataRow dtRow = dt.NewRow();
                    dtRow["id"] = row["id"];
                    dtRow["displayName"] = row["displayName"];
                    dtRow["gmail"] = row["gmail"];
                    dtRow["phoneNumber"] = row["phoneNumber"];
                    dtRow["address"] = row["address"];
                    dtRow["totalPrice"] = row["totalPrice"];
                    dtRow["billDetail"] = row["billDetail"];
                    dtRow["dateTime"] = row["dateTime"];
                    dtRow["isPaid"] = row["isPaid"];
                    dt.Rows.Add(dtRow);
                }
            }

            DataProvider.Instance.OverrideBillDataTableToTextFile(dt, phoneNumber);

            billDt = DataProvider.Instance.LoadAllBillDataTableFromTextFile();
            LoadDtgvBill();
        }

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            DataGridViewRow row = dtgvAccount.Rows[rowId];

            txtBoxAccountId.Text = row.Cells[0].Value.ToString();
            txtBoxAccountName.Text = row.Cells[1].Value.ToString();
            txtBoxUsername.Text = row.Cells[2].Value.ToString();
            txtBoxPassword.Text = row.Cells[3].Value.ToString();
            txtBoxEmail.Text = row.Cells[4].Value.ToString();
            txtBoxPhoneNumber.Text = row.Cells[5].Value.ToString();

            int accountType = int.Parse(row.Cells[6].Value.ToString());

            txtBoxAccountBalance.Text = row.Cells[7].Value.ToString();

            if(accountType == 1){
                txtBoxAccountType.Text = "Admin";
            }
            else 
            {
                txtBoxAccountType.Text = "Thường";
            }
        }

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
