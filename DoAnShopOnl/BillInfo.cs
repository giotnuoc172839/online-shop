using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class BillInfo : Form
    {
        public DataTable dt;
        public BillInfo()
        {
            InitializeComponent();
        }

        private void BillInfo_Load(object sender, EventArgs e)
        {
            dtgvBillInfo.DataSource = dt;
            dtgvBillInfo.Columns["id"].HeaderText = "Mã số";
            dtgvBillInfo.Columns["deviceName"].HeaderText = "Tên thiết bị";
            dtgvBillInfo.Columns["quantity"].HeaderText = "Số lượng";
            dtgvBillInfo.Columns["price"].HeaderText = "Đơn giá";
            dtgvBillInfo.Columns["totalPrice"].HeaderText = "Tổng giá";
        }
    }
}
