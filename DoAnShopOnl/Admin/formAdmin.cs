using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DoAnShopOnl.Admin
{
    public partial class formAdmin : Form
    {
        public formAdmin()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

        }

        fDashboard dashboard;
        fProduct product;
        fAccount account;
        fBill bill;
        fHome home;

        DataTable deviceDt = new DataTable();

        string deviceFilePath = @"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt";

        private void ptBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            dashboard = null;
        }

        private void Product_FormClosed(object sender, FormClosedEventArgs e)
        {
            product = null;
        }

        private void Account_FormClosed(object sender, FormClosedEventArgs e)
        {
            account = null;
        }

        private void Bill_FormClosed(object sender, FormClosedEventArgs e)
        {
            bill = null;
        }

        private void pnDashboard_Click(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new fDashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }

            foreach(Panel pn in panel1.Controls)
            {
                pn.BackColor = Color.Gray;
            }
            pnDashboard.BackColor = Color.Firebrick;
        }

        private void pnProduct_Click(object sender, EventArgs e)
        {
            if (product == null)
            {
                product = new fProduct();
                product.FormClosed += Product_FormClosed;
                product.MdiParent = this;
                product.Show();
            }
            else
            {
                product.Activate();
            }

            foreach (Panel pn in panel1.Controls)
            {
                pn.BackColor = Color.Gray;
            }
            pnProduct.BackColor = Color.Firebrick;
        }

        private void pnAccount_Click(object sender, EventArgs e)
        {
            if (account == null)
            {
                account = new fAccount();
                account.FormClosed += Account_FormClosed;
                account.MdiParent = this;
                account.Show();
            }
            else
            {
                account.Activate();
            }

            foreach (Panel pn in panel1.Controls)
            {
                pn.BackColor = Color.Gray;
            }
            pnAccount.BackColor = Color.Firebrick;
        }

        private void pnBill_Click(object sender, EventArgs e)
        {
            if (bill == null)
            {
                bill = new fBill();
                bill.FormClosed += Bill_FormClosed;
                bill.MdiParent = this;
                bill.Show();
            }
            else
            {
                bill.Activate();
            }

            foreach (Panel pn in panel1.Controls)
            {
                pn.BackColor = Color.Gray;
            }
            pnBill.BackColor = Color.Firebrick;
        }

        private void formAdmin_Load(object sender, EventArgs e)
        {
            if (dashboard == null)
            {
                dashboard = new fDashboard();
                dashboard.FormClosed += Dashboard_FormClosed;
                dashboard.MdiParent = this;
                dashboard.Show();
            }
            else
            {
                dashboard.Activate();
            }

            foreach (Panel pn in panel1.Controls)
            {
                pn.BackColor = Color.Gray;
            }
            pnDashboard.BackColor = Color.Firebrick;
        }

        private void formAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(product != null)
            {
                DataProvider.Instance.SaveDataTableToTextFile(product.deviceDt, deviceFilePath);
            }
        }
    }
}
