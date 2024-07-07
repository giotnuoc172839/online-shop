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
    public partial class commentUct : UserControl
    {
        public commentUct()
        {
            InitializeComponent();
        }

        public string userName;
        public string comment;
        public string avaPath;
        public int gender;
        public string dateTime;
        public int starCount;
        public PictureBox[] stars;

        public void LoadData(string userName, string comment, int gender, string dateTime, string avaPath, int starCount)
        {
            this.userName = userName;
            this.comment = comment;
            this.avaPath = avaPath;
            this.gender = gender;
            this.dateTime = dateTime;
            this.starCount = starCount;

            if (gender == 0)
            {
                lblGender.Text = "Nữ";
            }
            else
            {
                lblGender.Text = "Nam";
            }

            lblName.Text = userName;
            lblComment.Text = comment;
            lblDateTime.Text = dateTime;
            pbAva.BackgroundImage = Bitmap.FromFile(avaPath);

            stars = new PictureBox[] { pb1, pb2, pb3, pb4, pb5 };

            for (int i = 0; i < starCount; i++)
            {
                if (i < starCount)
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_on; // Set on/star_on image for previous stars
                }
                else
                {
                    stars[i].BackgroundImage = global::DoAnShopOnl.Properties.Resources.star_off; // Set off/star_off image for subsequent stars
                }
            }
        }
    }
}
