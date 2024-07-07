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

namespace DoAnShopOnl.Admin
{
    public partial class fBill : Form
    {
        public fBill()
        {
            InitializeComponent();
        }

        DataTable billDt = new DataTable();

        string billFolderPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";

        private void fBill_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            billDt = DataProvider.Instance.LoadAllBillDataTableFromTextFile();

            Font font = new Font("Arial", 10);

            //LoadDtgvBill();
            LoadData();
            
        }

        void LoadData()
        {
            ListBox lb = new ListBox();
            lb.Items.Add(dgvid);
            lb.Items.Add(dgvname);
            lb.Items.Add(dgvmail);
            lb.Items.Add(dgvphone);
            lb.Items.Add(dgvaddress);
            lb.Items.Add(dgvtotalPrice);
            lb.Items.Add(dgvbillInfo);
            lb.Items.Add(dgvisPaid);

            for (int i = 0; i < lb.Items.Count; i++)
            {
                string colNam1 = ((DataGridViewColumn)lb.Items[i]).Name;
                gnDgvBill.Columns[colNam1].DataPropertyName = billDt.Columns[i].ToString();
            }
            gnDgvBill.DataSource = billDt;
        }


        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtBoxBillPhoneNumber.Text;

            int billId = int.Parse(txtBoxBillId.Text);

            if (string.IsNullOrEmpty(phoneNumber)) return;

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
                else if (row["phoneNumber"].ToString() == phoneNumber && int.Parse(row["id"].ToString()) != billId)
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
            LoadData();
        }

        private void fBill_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void gnDgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowId = e.RowIndex;

            DataGridViewRow row = gnDgvBill.Rows[rowId];

            string billInfoPath = row.Cells[6].Value.ToString();
            DataTable billInfo = new DataTable();

            billInfo = DataProvider.Instance.LoadBillInfoDataTableFromTextFile(billInfoPath);

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
    }
}
