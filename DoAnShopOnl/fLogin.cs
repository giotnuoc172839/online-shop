using DoAnShopOnl.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        DataTable accountDt = new DataTable();

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = userNameTxtbox.Text.Trim();
            string password = passwordTxtbox.Text.Trim();

            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\account.txt");

            foreach (DataRow row in accountDt.Rows)
            {
                if (username == row["userName"].ToString() && password == row["password"].ToString())
                {
                    if (int.Parse(row["type"].ToString()) == 1)
                    {
                        formAdmin f = new formAdmin();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();

                        break;
                    }
                    else if (int.Parse(row["type"].ToString()) == 0)
                    {
                        fClient f = new fClient();

                        f.Login(row["displayName"].ToString(), row["gmail"].ToString(),row["phone"].ToString());

                        f.gnBtnLogin.Visible = false;
                        f.pnLogin.Visible = false;


                        this.Hide();
                        f.ShowDialog();
                        this.Show();

                        break;
                    }
                    
                }
            }
            
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\account.txt");
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            fRegister f = new fRegister();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void lblForgotPass_Click(object sender, EventArgs e)
        {
            fForgotPassword forgot = new fForgotPassword();
            forgot.Show();
        }

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtbox.PasswordChar = checkBox1.Checked ? '\0' : '*';
        }

        private void label3_Click(object sender, EventArgs e)
        {
            fRegister f = new fRegister();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
