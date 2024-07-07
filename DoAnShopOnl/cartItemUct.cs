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

namespace DoAnShopOnl
{
    public partial class cartItemUct : UserControl
    {
        public cartItemUct()
        {
            InitializeComponent();
        }

        public int id;
        public int idCategory;
        public string imageSource;
        public string name;
        public int price;
        public int highPrice;
        public int quantity = 0;
        public long allPrice;
        public long allHighPrice;

        public void LoadData(deviceUct u)
        {
            this.id = u.id;
            this.idCategory = u.idCategory;
            this.imageSource = u.imageSource;
            this.name = u.name;
            this.price = u.price;
            this.highPrice = u.highPrice;
            this.quantity = u.quantity;

            if(price == highPrice)
            {
                lblAllHighPrice.Visible = false;
            }
            else
            {
                lblAllHighPrice.Visible = true;
            }

            if (quantity > 100)
            {
                quantity = 100;
            }

            numQuantity.Value = (decimal)quantity;

            allPrice = (long)quantity * (long)price;
            allHighPrice = (long)quantity * (long)highPrice;

            ptBoxImage.BackgroundImage = Bitmap.FromFile(this.imageSource);
            lblDeviceName.Text = this.name;
            lblOnePrice.Text = this.price.ToString("N0", new CultureInfo("es-ES")) + "đ";
            lblAllPrice.Text = allPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
            lblAllHighPrice.Text = allHighPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            /*quantity = int.Parse(numQuantity.Value.ToString());

            allPrice = quantity * price;

            lblAllPrice.Text = allPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";*/
        }
    }
}
