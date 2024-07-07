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
    public partial class fAccount : Form
    {
        public fAccount()
        {
            InitializeComponent();
        }

        DataTable accountDt = new DataTable();

        string accountFilePath = @"D:\Lap trinh C#\DoAnShopOnl\account.txt";

        private void fAccount_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(accountFilePath);

            Font font = new Font("Arial", 15);

            dtgvAccount.Font = font;
            //LoadDtgvAccount();
            LoadData();
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

        private void dtgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            DataGridViewRow row = dtgvAccount.Rows[rowId];

            txtBoxAccountName.Text = row.Cells[1].Value.ToString();
            txtBoxUsername.Text = row.Cells[2].Value.ToString();
            txtBoxPassword.Text = row.Cells[3].Value.ToString();
            txtBoxEmail.Text = row.Cells[4].Value.ToString();
            txtBoxPhoneNumber.Text = row.Cells[5].Value.ToString();

            int accountType = int.Parse(row.Cells[6].Value.ToString());

            txtBoxAccountBalance.Text = row.Cells[7].Value.ToString();

            if (accountType == 1)
            {
                txtBoxAccountType.Text = "Admin";
            }
            else
            {
                txtBoxAccountType.Text = "Thường";
            }
        }

        void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvuserName);
            lb.Items.Add(dgvpass);
            lb.Items.Add(dgvmail);
            lb.Items.Add(dgvphone);
            lb.Items.Add(dgvtype);
            lb.Items.Add(dgvbalance);
            
            for(int i = 0; i < lb.Items.Count; i++)
            {
                string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                guna2DataGridView1.Columns[colNam1].DataPropertyName = accountDt.Columns[i].ToString();
            }

            guna2DataGridView1.DataSource = accountDt;
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            DataGridViewRow row = guna2DataGridView1.Rows[rowId];

            txtBoxAccountName.Text = row.Cells[3].Value.ToString();
            txtBoxUsername.Text = row.Cells[4].Value.ToString();
            txtBoxPassword.Text = row.Cells[5].Value.ToString();
            txtBoxEmail.Text = row.Cells[6].Value.ToString();
            txtBoxPhoneNumber.Text = row.Cells[7].Value.ToString();

            int accountType = Convert.ToInt32(row.Cells[8].Value);

            txtBoxAccountBalance.Text = row.Cells[9].Value.ToString();

            if (accountType == 1)
            {
                txtBoxAccountType.Text = "Admin";
            }
            else
            {
                txtBoxAccountType.Text = "Thường";
            }
        }
    }
}
