using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fForgotPassword : Form
    {
        public fForgotPassword()
        {
            InitializeComponent();
        }

        string sent = "Thành công! Vui lòng kiểm tra Email của bạn";
        string info = "Thông tin";

        private void btnGetPassword_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage();
            mail.From = new System.Net.Mail.MailAddress("21521900@gm.uit.edu.vn");
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(mail.From.Address, "janr mvln ibfg pkdd");
            smtp.Host = "smtp.gmail.com";


            string password = null;
            string email = null;
            string username = null;

            string txtFile = @"D:\Lap trinh C#\DoAnShopOnl\account.txt";

            // Read all lines from the file
            string[] lines = File.ReadAllLines(txtFile);

            foreach (string line in lines)
            {
                // Split the line by ":" to separate the key and value
                string[] parts = line.Split('*');

                email = parts[4].Trim();
                

                if (email == txtBoxEmail.Text)
                {
                    username = parts[2].Trim();
                    password = parts[3].Trim();
                    break;
                }
            }

            if (password != null && username != null)
            {
                mail.To.Add(new MailAddress(txtBoxEmail.Text)); //txt_Mail.Text
                mail.IsBodyHtml = true;
                mail.Subject = "Password"; //Password
                mail.Body = "Tài khoản: " + username + "<br>" + "Mật khẩu: " + password;
                smtp.Send(mail);
                MessageBox.Show(sent, info, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản đã đăng ký với email " + txtBoxEmail.Text);
            }


        }

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
