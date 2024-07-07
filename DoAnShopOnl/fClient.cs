using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace DoAnShopOnl
{
    public partial class fClient : Form
    {
        public fClient()
        {
            InitializeComponent();
        }

        DataTable deviceDt = null;
        List<deviceUct> cart = new List<deviceUct>();

        //User info
        public User currentUser = null;

        public void Login(string displayName, string gmail, string phoneNumber)
        {
            DataTable accountDt = new DataTable();
            User user = new User();
            user.LoadData(displayName, gmail, phoneNumber);
            currentUser = user;

            accountDt = DataProvider.Instance.LoadAccountDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\account.txt");
            foreach(DataRow row in accountDt.Rows)
            {
                if (row["phone"].ToString() == user.phoneNumber)
                {
                    user.balance = long.Parse(row["balance"].ToString());
                }
            }
            lblWelcome.Visible = true;
            lblWelcome.Text = "Chào " + user.displayName + ",";
        }

        string ramFilter = null;
        string romFilter = null;
        int minPrice = 0;
        int maxPrice = 100000000;

        private void fClient_Load(object sender, EventArgs e)
        {
            DataProvider.Instance.cart.Clear();
            lblCartCount.Visible = false;

            deviceDt = new DataTable();
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(@"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt");
            LoadDevice(deviceDt, flowPnDevice);

            rBtnRam4.Click += new EventHandler(RadioButtonRamClick);
            rBtnRam8.Click += new EventHandler(RadioButtonRamClick);
            rBtnRam12.Click += new EventHandler(RadioButtonRamClick);
            rBtnRam16.Click += new EventHandler(RadioButtonRamClick);
            rBtnRam24.Click += new EventHandler(RadioButtonRamClick);
            rBtnRam36.Click += new EventHandler(RadioButtonRamClick);

            rBtnRom32.Click += new EventHandler(RadioButtonRomClick);
            rBtnRom64.Click += new EventHandler(RadioButtonRomClick);
            rBtnRom128.Click += new EventHandler(RadioButtonRomClick);
            rBtnRom256.Click += new EventHandler(RadioButtonRomClick);
            rBtnRom512.Click += new EventHandler(RadioButtonRomClick);
            rBtnRom1024.Click += new EventHandler(RadioButtonRomClick);

            btnApple.Click += new EventHandler(ButtonBrandClick);
            btnSamsung.Click += new EventHandler(ButtonBrandClick);
            btnLenovo.Click += new EventHandler(ButtonBrandClick);
            btnXiaomi.Click += new EventHandler(ButtonBrandClick);
            btnAcer.Click += new EventHandler(ButtonBrandClick);
            btnAsus.Click += new EventHandler(ButtonBrandClick);

            int minPrice = int.Parse(txtBoxMinPrice.Text);
            int maxPrice = int.Parse(txtBoxMaxPrice.Text);
            string max = maxPrice.ToString("N0", new CultureInfo("es-ES"));
            string min = minPrice.ToString("N0", new CultureInfo("es-ES"));
            lblPriceRange.Text = min + "đ - " + max + "đ";
        }

        void RadioButtonRamClick(object sender, EventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                ramFilter = clickedRadioButton.Tag.ToString();
            }
        }

        void RadioButtonRomClick(object sender, EventArgs e)
        {
            RadioButton clickedRadioButton = sender as RadioButton;
            if (clickedRadioButton != null)
            {
                romFilter = clickedRadioButton.Tag.ToString();
            }
        }

        void ButtonBrandClick(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if(button != null)
            {
                lblBrand.Text = button.Tag.ToString();
            }
        }

        void LoadDevice(DataTable dt, FlowLayoutPanel flowPn) //default load
        {
            flowPn.Controls.Clear();

            for (int i = 0; i < deviceDt.Rows.Count; i++)
            {
                deviceUct uct = new deviceUct();
                
                uct.LoadData((int)(dt.Rows[i]["id"]), (int)(dt.Rows[i]["idCategory"]),
                (string)(dt.Rows[i]["name"]),(int)(dt.Rows[i]["lowPrice"]), (int)(dt.Rows[i]["highPrice"]),
                (string)(dt.Rows[i]["monitor"]), (string)(dt.Rows[i]["cpu"]), 
                (string)(dt.Rows[i]["gpu"]), (string)(dt.Rows[i]["ram"]),
                (string)(dt.Rows[i]["rom"]), (string)(dt.Rows[i]["brand"]),
                (int)(dt.Rows[i]["battery"]), (string)(dt.Rows[i]["camera"]),
                (string)(dt.Rows[i]["os"]), (string)(dt.Rows[i]["imageSource"]),
                (int)(dt.Rows[i]["remain"]));

                uct.btnAddToCart.Click += new EventHandler(AddToCart);
                uct.btnBuyNow.Click += new EventHandler(BuyNow);

                if(uct.idCategory == Int32.Parse(lblCategory.Text))
                {
                    flowPn.Controls.Add(uct);
                }
            }
        }

        void LoadSearchDevice(DataRow dr, FlowLayoutPanel flowPn)
        {
            deviceUct uct = new deviceUct();

            uct.LoadData((int)(dr["id"]), (int)(dr["idCategory"]),
            (string)(dr["name"]), (int)(dr["lowPrice"]), (int)(dr["highPrice"]),
            (string)(dr["monitor"]), (string)(dr["cpu"]),
            (string)(dr["gpu"]), (string)(dr["ram"]),
            (string)(dr["rom"]), (string)(dr["brand"]),
            (int)(dr["battery"]), (string)(dr["camera"]),
            (string)(dr["os"]), (string)(dr["imageSource"]),
            (int)(dr["remain"]));

            uct.btnAddToCart.Click += new EventHandler(AddToCart);
            uct.btnBuyNow.Click += new EventHandler(BuyNow);

            flowPn.Controls.Add(uct);
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            lblCategory.Text = "1";
            LoadDevice(deviceDt,flowPnDevice);
        }

        private void btnLaptop_Click(object sender, EventArgs e)
        {
            lblCategory.Text = "2";
            LoadDevice(deviceDt, flowPnDevice);
        }

        private void btnIpad_Click(object sender, EventArgs e)
        {
            lblCategory.Text = "3";
            LoadDevice(deviceDt, flowPnDevice);
        }

        List<DataRow> dr = new List<DataRow>();
        private void txtBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                string searchText = txtBoxSearch.Text.Trim();

                flowPnDevice.Controls.Clear();

                dr.Clear();  // Clear the list before performing the search

                foreach (DataRow selectedRows in deviceDt.Select("name like  '" + searchText +
                    "%' OR brand LIKE '%" + searchText + "%'"))
                {
                    dr.Add(selectedRows);
                }

                if (dr.Count > 0)
                {
                    foreach (DataRow row in dr)
                    {
                        LoadSearchDevice(row, flowPnDevice);
                    }
                }

                txtBoxSearch.Text = "";
                txtBoxSearch.Text.Trim();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            flowPnDevice.Controls.Clear();

            dr.Clear();  // Clear the list before performing the search

            int minPrice = int.Parse(txtBoxMinPrice.Text);
            int maxPrice = int.Parse(txtBoxMaxPrice.Text);

            // Price
            string filterExpression = $"lowPrice >= {minPrice} AND lowPrice <= {maxPrice}";

            foreach (DataRow selectedRows in deviceDt.Select(filterExpression))
            {
                dr.Add(selectedRows);
            }
            // Category
            DataRow[] categoryFilteredRows = dr.ToArray().Select(r => r).Where(r => r["idCategory"].ToString() == lblCategory.Text).ToArray();

            dr.Clear();
            foreach (DataRow selectedRow in categoryFilteredRows)
            {
                dr.Add(selectedRow);
            }
            // Brand
            if (!string.IsNullOrEmpty(lblBrand.Text))
            {
                string brandFilterExpression = $"brand LIKE '%{lblBrand.Text}%'";
                DataRow[] brandFilteredRows = dr.ToArray().Select(r => r).Where(r => r["brand"].ToString().Contains(lblBrand.Text)).ToArray();

                dr.Clear();
                foreach (DataRow selectedRow in brandFilteredRows)
                {
                    dr.Add(selectedRow);
                }
            }
            // Ram
            if (!string.IsNullOrEmpty(ramFilter))
            {
                string ramFilterExpression = $"ram = '%{ramFilter}%'";
                DataRow[] ramFilteredRows = dr.ToArray().Select(r => r).Where(r => r["ram"].ToString() == ramFilter).ToArray();

                dr.Clear();
                foreach (DataRow selectedRow in ramFilteredRows)
                {
                    dr.Add(selectedRow);
                }
            }
            // Rom
            if (!string.IsNullOrEmpty(romFilter))
            {
                string romFilterExpression = $"rom = '%{romFilter}%'";
                DataRow[] romFilteredRows = dr.ToArray().Select(r => r).Where(r => r["rom"].ToString() == romFilter).ToArray();

                // Clear the original list and add the ROM filtered results
                dr.Clear();
                foreach (DataRow selectedRow in romFilteredRows)
                {
                    dr.Add(selectedRow);
                }
            }

            if (dr.Count > 0)
            {
                foreach (DataRow row in dr)
                {
                    LoadSearchDevice(row, flowPnDevice);
                }
            }
            lblBrand.Text = "";
        }

        void ChangePriceRange()
        {
            int minPrice = int.Parse(txtBoxMinPrice.Text);
            int maxPrice = int.Parse(txtBoxMaxPrice.Text);
            string max = maxPrice.ToString("N0", new CultureInfo("es-ES"));
            string min = minPrice.ToString("N0", new CultureInfo("es-ES"));
            lblPriceRange.Text = min + "đ - " + max + "đ";
        }

        private void txtBoxMinPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key is not a valid input, prevent it from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtBoxMaxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // If the key is not a valid input, prevent it from being entered into the TextBox
                e.Handled = true;
            }
        }

        private void txtBoxMinPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtBoxMaxPrice.Text == "")
            {
                txtBoxMinPrice.Text = "0";
            }
            else if (Int64.Parse(txtBoxMaxPrice.Text) < Int64.Parse(txtBoxMinPrice.Text))
            {
                txtBoxMinPrice.Text = txtBoxMaxPrice.Text;
            }
            ChangePriceRange();
        }

        private void txtBoxMaxPrice_TextChanged(object sender, EventArgs e)
        {
            int maxPrice = 200000000;
            if (txtBoxMaxPrice.Text == "")
            {
                txtBoxMaxPrice.Text = "0";
            }
            else if (Int64.Parse(txtBoxMaxPrice.Text) > maxPrice)
            {
                txtBoxMaxPrice.Text = maxPrice.ToString();
            }
            else if(int.Parse(txtBoxMaxPrice.Text) < int.Parse(txtBoxMinPrice.Text))
            {
                txtBoxMaxPrice.Text = txtBoxMinPrice.Text;
            }
            ChangePriceRange();
        }

        public List<cartItemUct> itemCart = new List<cartItemUct>();    

        void AddToCart(object sender, EventArgs e)
        {
            bool deviceExistInCart = false;

            deviceUct deviceUct = (deviceUct)((Button)sender).Parent;

            foreach (deviceUct device in cart)
            {
                if (deviceUct.id == device.id && deviceUct.name == device.name)
                {
                    deviceExistInCart = true;
                    break;
                }
                else if (deviceUct.id != device.id || deviceUct.name != device.name)
                {
                    deviceExistInCart = false;
                }
            }

            if (deviceExistInCart)
            {
                foreach (deviceUct device in cart)
                {
                    if (deviceUct.id == device.id && deviceUct.name == device.name)
                    {
                        //device.quantity++;
                        //deviceUct.quantity = device.quantity;

                        MessageBox.Show("Sản phẩm này đã có trong giỏ hàng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    }
                }
            }

            if (deviceUct.quantity < 1 && !deviceExistInCart)
            {
                deviceUct.quantity = 1;
                cart.Add(deviceUct);
            }

            DataProvider.Instance.cart = this.cart;

            lblCount.Text = "(" + DataProvider.Instance.cart.Count + ")";
        }

        void BuyNow(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            deviceUct uct = (deviceUct)button.Parent;

            fBuyNow f = new fBuyNow();
            f.LoadData(uct);


            this.Hide();
            f.ShowDialog();
            this.Show();
        }


        private void cartBtn_Click(object sender, EventArgs e)
        {
            fCart f = new fCart();
            if(currentUser != null)
            {
                f.user = this.currentUser;
                f.isLogin = true;
            }

            this.Hide();
            f.ShowDialog();
            this.Show();
        }


        private void loginRegisterBtn_Click(object sender, EventArgs e)
        {
            fLogin f = new fLogin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnFindBill_Click(object sender, EventArgs e)
        {
            fFindReport f = new fFindReport();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
