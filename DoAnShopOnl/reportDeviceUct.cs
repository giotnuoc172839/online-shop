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
    public partial class reportDeviceUct : UserControl
    {
        public reportDeviceUct()
        {
            InitializeComponent();
        }

        string name;
        int price;
        int rowPrice;
        int quantity;
        string imageSource;

        public void LoadData(string name, int price, int rowPrice, int quantity, string imageSource)
        {
            this.name = name;
            this.price = price;
            this.rowPrice = rowPrice;
            this.quantity = quantity;
            this.imageSource = imageSource;
            
            lblName.Text = name;
            lblPrice.Text = price.ToString("N0", new CultureInfo("es-ES")) + "đ";
            lblTotal.Text = "Tổng: " + rowPrice.ToString("N0", new CultureInfo("es-ES")) + "đ";
            lblQuantity.Text = "Số lượng: " + quantity.ToString();
            ptBoxImage.BackgroundImage = Bitmap.FromFile(imageSource);
        }
    }
}
