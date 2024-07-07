using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fRegister : Form
    {
        public fRegister()
        {
            InitializeComponent();
        }

        DataTable accountDt = new DataTable();

        string accountFilePath = @"D:\Lap trinh C#\DoAnShopOnl\account.txt";


        private void fRegister_Load(object sender, EventArgs e)
        {
            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(accountFilePath);

            lblInvalidEmail.Hide();
            lblInvalidNumber.Hide();
            lblInvalidPassword.Hide();
            lblInvalidRepassword.Hide();
            lblInvalidName.Hide();
            lblInvalidUsername.Hide();

        }
        string sent = "Đăng ký thành công !";
        string info = "Thông tin";
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = txtBoxName.Text;
            string email = txtBoxEmail.Text;
            string password = txtBoxPassword.Text;
            string rePassword = txtBoxRepassword.Text;
            string phoneNumber = txtBoxPhoneNumber.Text;
            string username = txtBoxUsername.Text;

            bool isSignUpSuccessfully = true;

            //error input case
            if (!IsValidEmail(email))
            {
                lblInvalidEmail.Show();
            }
            else lblInvalidEmail.Hide();

            if (!IsValidPhoneNumber(phoneNumber))
            {
                lblInvalidNumber.Show();
            }
            else lblInvalidNumber.Hide();

            if (!IsValidPassword(password))
            {
                lblInvalidPassword.Show();
            }
            else lblInvalidPassword.Hide();

            if (!IsValidName(name))
            {
                lblInvalidName.Show();
            }
            else lblInvalidName.Hide();

            if (!IsValidRepassword(rePassword))
            {
                lblInvalidRepassword.Show();
            }
            else lblInvalidRepassword.Hide();

            if (!IsValidUsername(username))
            {
                lblInvalidUsername.Show();
            }
            else lblInvalidUsername.Hide();

            //sign up successfully
            if (IsValidEmail(email) && IsValidName(name) && IsValidPassword(password)
                && IsValidPhoneNumber(phoneNumber) && IsValidRepassword(rePassword) 
                && IsValidUsername(username))
            {
                foreach(DataRow row in accountDt.Rows)
                {
                    if (row["userName"].ToString() == username || row["gmail"].ToString() == email ||
                        row["phone"].ToString() == phoneNumber)
                    {
                        isSignUpSuccessfully = false;
                        break;
                    }
                    
                }

                if(isSignUpSuccessfully)
                {
                    using (StreamWriter writer = new StreamWriter(accountFilePath, true))
                    {
                        writer.Write("1");
                        writer.Write('*');
                        writer.Write(name);
                        writer.Write('*');
                        writer.Write(username);
                        writer.Write('*');
                        writer.Write(password);
                        writer.Write('*');
                        writer.Write(email);
                        writer.Write('*');
                        writer.Write(phoneNumber);
                        writer.Write('*');
                        writer.Write(0);
                        writer.Write('*');
                        writer.Write(100000000);
                        writer.Write('*');

                        writer.WriteLine(); // Move to the next line
                    }
                    accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(accountFilePath);

                    MessageBox.Show(sent, info, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        public bool IsValidPassword(string password)
        {
            string pattern = @"^[^\s]{1,20}$"; // Matches strings with no spaces and length up to 20 characters
            return Regex.IsMatch(password, pattern);
        }

        public bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(txtBoxName.Text);
        }

        public bool IsValidRepassword(string rePassword)
        {
            if (txtBoxPassword.Text == rePassword)
            {
                return true;
            }
            else return false;
        }

        public bool IsValidUsername(string username)
        {
            string pattern = @"^[^\s]{1,20}$"; // Matches strings with no spaces and length up to 20 characters
            return Regex.IsMatch(username, pattern);
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
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
