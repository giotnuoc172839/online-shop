using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;

namespace DoAnShopOnl
{
    public partial class fFindReport : Form
    {
        public fFindReport()
        {
            InitializeComponent();
        }

        DataTable billInfoDt;
        DataTable billDt;
        DataTable deviceDt;

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int totalPrice;
        int isPaid;


        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            if(qrId < 0)
            {
                MessageBox.Show("Vui lòng tải QR lên để tra cứu" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int billId = qrId;

                foreach (DataRow row in billDt.Rows)
                {
                    if (Convert.ToInt32(row["id"]) == billId)
                    {
                        txtBoxName.Text = row["displayName"].ToString();
                        txtBoxEmail.Text = row["gmail"].ToString();
                        txtBoxDate.Text = row["dateTime"].ToString();
                        txtBoxPhone.Text = row["phoneNumber"].ToString();
                        isPaid = Convert.ToInt32(row["isPaid"]);
                        totalPrice = Convert.ToInt32(row["totalPrice"]);


                        if (isPaid == 1)
                        {
                            txtBoxStatus.Text = "Đã thanh toán";
                        }
                        else
                        {
                            txtBoxStatus.Text = "Chưa thanh toán";
                        }
                        txtBoxTotalBill.Text = totalPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";

                        string billInfoPath = row["billDetail"].ToString();
                        billInfoDt = DataProvider.Instance.LoadBillInfoDataTableFromTextFile(billInfoPath);

                        break;
                    }
                }

                LoadBillInfo();
                
            }
        }

        string imagePath;

        private void fFindReport_Load(object sender, EventArgs e)
        {
            billDt = DataProvider.Instance.LoadAllBillDataTableFromTextFile();
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt");

        }

        void LoadBillInfo()
        {
            flowPnReport.Controls.Clear();

            foreach(DataRow row in billInfoDt.Rows)
            {
                reportDeviceUct u = new reportDeviceUct();
                string name = row["deviceName"].ToString();
                
                u.LoadData(row["deviceName"].ToString(), Convert.ToInt32(row["price"]),
                    Convert.ToInt32(row["totalPrice"]), Convert.ToInt32(row["quantity"]), GetImage(name));

                flowPnReport.Controls.Add(u);
            }
        }

        string GetImage(string name)
        {
            foreach(DataRow row in deviceDt.Rows)
            {
                if (row["name"].ToString() == name)
                {
                    return row["imageSource"].ToString();
                }
            }
            return "";
        }

        int qrId = -1;

        private void gnBtnUploadQR_Click(object sender, EventArgs e)
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
                        ptBoxQR.BackgroundImage = Bitmap.FromFile(selectedFile);


                        var barcodeReader = new BarcodeReader();
                        using (var bitmap = (Bitmap)Image.FromFile(selectedFile))
                        {
                            var result = barcodeReader.Decode(bitmap);
                            if(result != null)
                            {
                                // Ensure the text is a valid integer
                                if (int.TryParse(result.Text, out int qrCodeId))
                                {
                                    qrId = qrCodeId;
                                }
                                else
                                {
                                    MessageBox.Show("The QR code does not contain a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                qrId = -1;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while trying to load the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
