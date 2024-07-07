using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class fBuyNow : Form
    {
        public fBuyNow()
        {
            InitializeComponent();
        }

        private void ptReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        cartItemUct cartItemUct;
        DataTable deviceDt = new DataTable();
        public deviceUct uct;

        private void fBuyNow_Load(object sender, EventArgs e)
        {
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt");

            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("gmail", typeof(string));
            dt.Columns.Add("phoneNumber", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("totalPrice", typeof(int));
            dt.Columns.Add("billDetail", typeof(string));
            dt.Columns.Add("dateTime", typeof(string));
            dt.Columns.Add("isPaid", typeof(int));
        }

        int totalPrice;

        public void LoadData(deviceUct deviceUct)
        {
            cartItemUct cartItemUct = new cartItemUct();

            cartItemUct.LoadData(deviceUct);
            cartItemUct.lblAllHighPrice.Visible = false;
            cartItemUct.label1.Visible = false;
            cartItemUct.numQuantity.Visible = false;
            cartItemUct.ptBoxTrash.Visible = false;

            cartItemUct.lblAllPrice.Location = new System.Drawing.Point(140, 70);
            totalPrice = deviceUct.lowPrice;
            cartItemUct.lblAllPrice.Text = totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
            lblTotalMoney.Text = "Tổng tiền: " + totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";


            this.uct = deviceUct;
            flowPnCart.Controls.Add(cartItemUct);
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

        int GetBillId()
        {
            int fileCount;

            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string[] fileArray = Directory.GetFiles(directoryPath, "*.txt");

            List<string> files = fileArray.ToList();

            fileCount = files.Count;

            return fileCount;
        }

        DataTable dt = new DataTable();

        private void btnPay_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString();

            string address = txtBoxAddress.Text;

            List<cartItemUct> notEnoughAmountList = new List<cartItemUct>();

            string billInfoFileName = SanitizeFileName(txtBoxPhoneNumber.Text + " " + date);


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
                                    rowInfo["quantity"] = 1;
                                    rowInfo["rowPrice"] = u.price;
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
    }
}
