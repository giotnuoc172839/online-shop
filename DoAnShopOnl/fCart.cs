using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fCart : Form
    {
        public fCart()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        DataTable cartDt = new DataTable();
        long totalPrice;
        public User user;
        public bool isLogin = false;
        DataTable accountDt = new DataTable();
        DataTable deviceDt = new DataTable();

        string accountFilePath = @"D:\Lap trinh C#\DoAnShopOnl\account.txt";
        string deviceFilePath = @"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt";

        private void fCart_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("gmail", typeof(string));
            dt.Columns.Add("phoneNumber", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("totalPrice", typeof(long));
            dt.Columns.Add("billDetail", typeof(string));
            dt.Columns.Add("dateTime", typeof(string));
            dt.Columns.Add("isPaid", typeof(string));

            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(accountFilePath);
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(deviceFilePath);

            lblTotalMoney.Text = "Tổng tiền: 0đ";

            lblCart.Text = "Có " + DataProvider.Instance.cart.Count.ToString() + " sản phẩm trong giỏ hàng"; 

            if (DataProvider.Instance.cart.Count > 0)
            {
                foreach(deviceUct item in DataProvider.Instance.cart)
                {
                    cartItemUct u = new cartItemUct();  

                    flowPnCart.Controls.Add(u);

                    u.LoadData(item);

                    u.numQuantity.ValueChanged += new EventHandler(numQuantityValueChange);
                    u.ptBoxTrash.Click += new EventHandler(trashBinPictureBoxClick);

                    totalPrice += u.allPrice;
                    
                }
                lblTotalMoney.Text = "Tổng tiền: " + totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
            }

            if (isLogin)
            {
                lblCurrentBalance.Visible = true;
                btnPay.Text = "THANH TOÁN";

                txtBoxEmail.ReadOnly = true;
                txtBoxPhoneNumber.ReadOnly = true;
                txtBoxName.ReadOnly = true;

                txtBoxEmail.Text = user.gmail;
                txtBoxPhoneNumber.Text = user.phoneNumber;
                txtBoxName.Text = user.displayName;

                lblCurrentBalance.Text = "Số dư: " + user.balance.ToString("N0", new CultureInfo("es-ES")) + "đ";
            }
            else
            {
                lblCurrentBalance.Visible = false;
                btnPay.Text = "ĐẶT HÀNG";

                txtBoxEmail.ReadOnly = false;
                txtBoxPhoneNumber.ReadOnly = false;
            }
        }

        void numQuantityValueChange(object sender, EventArgs e)
        {
            totalPrice = 0;

            NumericUpDown numQuantity = sender as NumericUpDown;

            cartItemUct u = (cartItemUct)numQuantity.Parent;
            FlowLayoutPanel flowPn = (FlowLayoutPanel)u.Parent;

            u.quantity = int.Parse(numQuantity.Value.ToString());

            u.allPrice = (long)u.quantity * (long)u.price;

            u.allHighPrice = (long)u.quantity * (long) u.highPrice;

            u.lblAllPrice.Text = u.allPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            u.lblAllHighPrice.Text = u.allHighPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            if(u.quantity <= 0)
            {
                foreach (deviceUct cartU in DataProvider.Instance.cart)
                {
                    if (u.id.ToString() == cartU.id.ToString())
                    {
                        cartU.quantity = 0;
                        DataProvider.Instance.cart.Remove(cartU);
                        break;
                    }
                    
                }

                u.Dispose();
            }

            //Load total price
            totalPrice = 0;
            foreach (cartItemUct item in flowPn.Controls)
            {
                totalPrice += item.allPrice;
            }
            lblTotalMoney.Text = "Tổng tiền: " + totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
        }

        void trashBinPictureBoxClick(object sender, EventArgs e)
        {
            PictureBox ptBoxTrash = sender as PictureBox;

            cartItemUct u = (cartItemUct)ptBoxTrash.Parent;

            NumericUpDown numQuantity = (NumericUpDown)(u.numQuantity);

            FlowLayoutPanel flowPn = (FlowLayoutPanel)u.Parent;

            u.quantity = 0;

            u.allPrice = (long)u.quantity * (long)u.price;

            u.allHighPrice = (long)u.quantity * (long)u.highPrice;

            u.lblAllPrice.Text = u.allPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            u.lblAllHighPrice.Text = u.allHighPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

            if (u.quantity == 0)
            {
                foreach (deviceUct cartU in DataProvider.Instance.cart)
                {
                    if (u.id.ToString() == cartU.id.ToString())
                    {
                        cartU.quantity = 0;
                        DataProvider.Instance.cart.Remove(cartU);
                        break;
                    }

                }
                u.Dispose();
            }

            //Load total price
            totalPrice = 0;
            foreach (cartItemUct item in flowPn.Controls)
            {
                totalPrice += item.allPrice;
            }
            lblTotalMoney.Text = "Tổng tiền: " + (totalPrice.ToString("N0", new CultureInfo("es-ES"))) + "đ";
            lblCart.Text = "Có " + DataProvider.Instance.cart.Count.ToString() + " sản phẩm trong giỏ hàng";
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();

            string address = txtBoxAddress.Text;

            List<cartItemUct> notEnoughAmountList = new List<cartItemUct>();

            string billInfoFileName = SanitizeFileName(txtBoxPhoneNumber.Text + " " + date);

            if (!isLogin && totalPrice > 0)
            {
                if (IsValidEmail(txtBoxEmail.Text) && IsValidPhoneNumber(txtBoxPhoneNumber.Text)
                    && !string.IsNullOrEmpty(txtBoxName.Text) && !string.IsNullOrEmpty(address))
                {
                    DataTable billInfoDt = new DataTable();
                    billInfoDt.Columns.Add("id", typeof(int));
                    billInfoDt.Columns.Add("idCategory", typeof(int));
                    billInfoDt.Columns.Add("deviceName", typeof(string));
                    billInfoDt.Columns.Add("price", typeof(int));
                    billInfoDt.Columns.Add("quantity", typeof(int));
                    billInfoDt.Columns.Add("rowPrice", typeof(long));

                    if (flowPnCart.Controls.Count > 0)
                    {
                        int i = 0;
                        foreach (cartItemUct u in flowPnCart.Controls)
                        {
                            //Minus remain device in deviceList
                            foreach (DataRow deviceListRow in deviceDt.Rows)
                            {
                                //Check if the device has enough amount
                                if (u.id == int.Parse(deviceListRow["id"].ToString()) && u.name == deviceListRow["name"].ToString())
                                {
                                    if (int.Parse(deviceListRow["remain"].ToString()) >= u.quantity)
                                    {
                                        DataRow rowInfo = billInfoDt.NewRow();
                                        rowInfo["id"] = i;
                                        rowInfo["idCategory"] = u.idCategory;
                                        rowInfo["deviceName"] = u.name;
                                        rowInfo["price"] = u.price;
                                        rowInfo["quantity"] = u.quantity;
                                        rowInfo["rowPrice"] = u.allPrice;
                                        i++;
                                        billInfoDt.Rows.Add(rowInfo);

                                        //Update remain
                                        int oldAmount = int.Parse(deviceListRow["remain"].ToString());
                                        int newAmount = oldAmount - u.quantity;
                                        deviceListRow["remain"] = newAmount;
                                        break;
                                    }
                                    else
                                    {
                                        notEnoughAmountList.Add(u);
                                        break;
                                    }

                                }
                            }

                        }
                        if (notEnoughAmountList.Count > 0)
                        {
                            string alert = "";
                            foreach (var item in notEnoughAmountList)
                            {
                                alert += "Sản phẩm " + item.name + " không đủ số lượng !\n";
                            }
                            MessageBox.Show(alert, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataProvider.Instance.SaveBillInfoDataTableToTextFile(billInfoDt, billInfoFileName);

                            DataRow row = dt.NewRow();
                            row["id"] = GetBillId();
                            row["displayName"] = txtBoxName.Text;
                            row["gmail"] = txtBoxEmail.Text;
                            row["phoneNumber"] = txtBoxPhoneNumber.Text;
                            row["address"] = address;
                            row["totalPrice"] = totalPrice;
                            row["billDetail"] = @"D:\Lap trinh C#\DoAnShopOnl\BillInfo\" + billInfoFileName + ".txt";
                            row["dateTime"] = date;
                            row["isPaid"] = 0;
                            dt.Rows.Add(row);
                            DataProvider.Instance.SaveBillDataTableToTextFile(dt, txtBoxPhoneNumber.Text);

                            MessageBox.Show("Đặt hàng thành công !", "Đặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            fReport f = new fReport();
                            f.LoadReport(dt, billInfoDt, billInfoFileName, txtBoxEmail.Text);

                            dt.Clear();
                            
                        }

                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin và đúng định dạng !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (isLogin && totalPrice > 0 && !string.IsNullOrEmpty(address))
            {
                if (user.balance > totalPrice)
                {
                    DataTable billInfoDt = new DataTable();
                    billInfoDt.Columns.Add("id", typeof(int));
                    billInfoDt.Columns.Add("idCategory", typeof(int));
                    billInfoDt.Columns.Add("deviceName", typeof(string));
                    billInfoDt.Columns.Add("price", typeof(int));
                    billInfoDt.Columns.Add("quantity", typeof(int));
                    billInfoDt.Columns.Add("rowPrice", typeof(long));

                    if (flowPnCart.Controls.Count > 0)
                    {
                        int i = 0;
                        foreach (cartItemUct u in flowPnCart.Controls)
                        {
                            //Minus remain device in deviceList
                            foreach (DataRow deviceListRow in deviceDt.Rows)
                            {
                                if (u.id == int.Parse(deviceListRow["id"].ToString()) && u.name == deviceListRow["name"].ToString())
                                {
                                    if (int.Parse(deviceListRow["remain"].ToString()) >= u.quantity)
                                    {
                                        DataRow rowInfo = billInfoDt.NewRow();
                                        rowInfo["id"] = i;
                                        rowInfo["idCategory"] = u.idCategory;
                                        rowInfo["deviceName"] = u.name;
                                        rowInfo["price"] = u.price;
                                        rowInfo["quantity"] = u.quantity;
                                        rowInfo["rowPrice"] = u.allPrice;
                                        i++;
                                        billInfoDt.Rows.Add(rowInfo);

                                        //Update remain
                                        int oldAmount = int.Parse(deviceListRow["remain"].ToString());
                                        int newAmount = oldAmount - u.quantity;
                                        deviceListRow["remain"] = newAmount;
                                    }
                                    else
                                    {
                                        notEnoughAmountList.Add(u);
                                        break;
                                    }

                                }
                            }


                        }
                        if (notEnoughAmountList.Count > 0)
                        {
                            string alert = "";
                            foreach (var item in notEnoughAmountList)
                            {
                                alert += "Sản phẩm " + item.name + " không đủ số lượng !\n";
                            }
                            MessageBox.Show(alert, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DataProvider.Instance.SaveBillInfoDataTableToTextFile(billInfoDt, billInfoFileName);

                            DataRow row = dt.NewRow();
                            row["id"] = GetBillId();
                            row["displayName"] = user.displayName;
                            row["gmail"] = user.gmail;
                            row["phoneNumber"] = user.phoneNumber;
                            row["address"] = address;
                            row["totalPrice"] = totalPrice;
                            row["billDetail"] = "D:\\Lap trinh C#\\DoAnShopOnl\\BillInfo\\" + billInfoFileName + ".txt";
                            row["dateTime"] = date;
                            row["isPaid"] = 1;
                            dt.Rows.Add(row);

                            DataProvider.Instance.SaveBillDataTableToTextFile(dt, user.phoneNumber);

                            
                            user.balance -= totalPrice;
                            lblCurrentBalance.Text = "Số dư: " + user.balance.ToString("N0", new CultureInfo("es-ES")) + "đ";

                            MessageBox.Show("Thanh toán thành công !", "Thanh toán", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            fReport f = new fReport();
                            f.LoadReport(dt, billInfoDt, billInfoFileName, txtBoxEmail.Text);

                            dt.Clear();

                            foreach (DataRow accountRow in accountDt.Rows)
                            {
                                if (accountRow["phone"].ToString() == user.phoneNumber.ToString())
                                {
                                    accountRow["balance"] = user.balance;
                                    DataProvider.Instance.SaveDataTableToTextFile(accountDt, @"D:\Lap trinh C#\DoAnShopOnl\account.txt");
                                }
                            }
                            DataProvider.Instance.SaveDataTableToTextFile(deviceDt, deviceFilePath);
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Số dư không đủ !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Vui lòng điền địa chỉ !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        int GetBillId()
        {
            int fileCount;

            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string[] fileArray = Directory.GetFiles(directoryPath, "*.txt");

            List<string> files = fileArray.ToList();

            fileCount = files.Count;

            return fileCount;
        }

        string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\d{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public List<cartItemUct> list = new List<cartItemUct>();

        private void fCart_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach(cartItemUct item in flowPnCart.Controls)
            {
                list.Add(item);
            }

            //Update cart in DataProvider
            foreach(cartItemUct item in list)
            {
                foreach (deviceUct cartU in DataProvider.Instance.cart)
                {
                    if (item.id.ToString() == cartU.id.ToString())
                    {
                        cartU.quantity = item.quantity;
                    }
                }
            }
        }

        private void txtBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxPhoneNumber.Text.Length > 10)
            {
                // Truncate the text to 10 characters
                txtBoxPhoneNumber.Text = txtBoxPhoneNumber.Text.Substring(0, 10);

                // Set the cursor to the end of the text
                txtBoxPhoneNumber.SelectionStart = txtBoxPhoneNumber.Text.Length;
            }
        }

        private void txtBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit and is not a control key like backspace
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Disallow the character
            }
        }

        private void ptReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
