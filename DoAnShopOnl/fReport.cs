using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;
using ZXing;
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.ReportingServices.Interfaces;
using static QRCoder.PayloadGenerator;
using System.Net.Mail;
using System.Net;
using System.Net.Mail;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Drawing.Printing;

namespace DoAnShopOnl
{
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
        }


        public void LoadReport(DataTable billDt, DataTable billInfoDt, string reportFileName, string mail)
        {
            int id = Convert.ToInt32(billDt.Rows[0]["id"]);

            string qrText = Convert.ToString(id);

            reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource source = new ReportDataSource("billInfoDs", billInfoDt);
            reportViewer1.LocalReport.DataSources.Add(source);

            ReportDataSource source2 = new ReportDataSource("billDs", billDt);
            reportViewer1.LocalReport.DataSources.Add(source2);

            reportViewer1.LocalReport.ReportPath = @"D:\Lap trinh C#\DoAnShopOnl\DoAnShopOnl\HoaDon.rdlc";
            reportViewer1.RefreshReport();


            string directory = @"D:\Lap trinh C#\DoAnShopOnl\Report";
            string savePath = Path.Combine(directory, reportFileName + ".pdf");

            // Render the report as PDF using LocalReport
            byte[] bytes = reportViewer1.LocalReport.Render("PDF");

            // Save the rendered bytes to a file using PdfSharp
            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            //QR Code
            if (string.IsNullOrEmpty(qrText))
            {
                MessageBox.Show("Please enter text to generate QR code.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
                using (QRCode qrCode = new QRCode(qrCodeData))
                {
                    Bitmap qrCodeImage = qrCode.GetGraphic(20);

                    string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\QRCode";
                    string filePath = Path.Combine(directoryPath, id + ".png");

                    // Ensure the directory exists
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);
                    }

                    // Save the QR code image
                    qrCodeImage.Save(filePath);
                }
            }

            SendBillThroughMail(mail, savePath, @"D:\Lap trinh C#\DoAnShopOnl\QRCode\" + id + ".png");
        }

        void SendBillThroughMail(string email, string pdfBillPath, string QRPath)
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
            mail.Subject = "Cám ơn vì đã mua hàng!";
            mail.Body = "Cảm ơn bạn đã mua hàng tại Phong Vũ. Hóa đơn chi tiết và mã QR được đính kèm bên dưới";

            // Add the image as an attachment
            if (File.Exists(pdfBillPath))
            {
                Attachment attachment = new Attachment(pdfBillPath);
                mail.Attachments.Add(attachment);

                Attachment attachmentQR = new Attachment(QRPath);
                mail.Attachments.Add(attachmentQR);
            }
            else
            {
                MessageBox.Show("The image file does not exist.");
                return;
            }

            try
            {
                smtp.Send(mail);
                MessageBox.Show("Vui lòng kiểm tra e-mail !", "E-mail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email: " + ex.Message);
            }
        }

        void GenerateQR()
        {

        }

        private void fReport_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            
        }
        

        public void SaveReportAsPdf(string phoneNumber)
        {
            string directory = @"D:\Lap trinh C#\DoAnShopOnl\Report";
            string savePath = Path.Combine(directory, phoneNumber +".pdf");

            reportViewer1.LocalReport.DataSources.Clear();
            //ReportDataSource source = new ReportDataSource("DataSet1", staffDt);
            reportViewer1.LocalReport.ReportPath = @"D:\Lap trinh C#\DoAnShopOnl\DoAnShopOnl\Report1.rdlc";
            //reportViewer1.LocalReport.DataSources.Add(source);
            reportViewer1.RefreshReport();

            // Render the report as PDF using LocalReport
            byte[] bytes = reportViewer1.LocalReport.Render("PDF");

            // Save the rendered bytes to a file using PdfSharp
            using (FileStream fs = new FileStream(savePath, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            MessageBox.Show("Report saved as PDF successfully!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

