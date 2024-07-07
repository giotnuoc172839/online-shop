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
    public partial class imageAttach : UserControl
    {
        public imageAttach()
        {
            InitializeComponent();
        }

        public void LoadImage(string fileName)
        {
            ptBoxImage.BackgroundImage = Bitmap.FromFile(fileName);
        }

    }
}
