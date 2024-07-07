using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    public partial class fTest : Form
    {
        public fTest()
        {
            InitializeComponent();
        }

        DataTable deviceDt;
        string devicePath = @"D:\Lap trinh C#\DoAnShopOnl\deviceList.txt";
        string imagePath = @"D:\Lap trinh C#\DoAnShopOnl\Images";

        private void fTest_Load(object sender, EventArgs e)
        {
            
        }

        void CreateFile()
        {
            deviceDt = DataProvider.Instance.LoadDeviceDataTableFromTextFile(devicePath);

            foreach (DataRow row in deviceDt.Rows)
            {
                string imageFileName = row["name"].ToString();
                string filePath = Path.Combine(imagePath, imageFileName + ".txt");

                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        // Close the file stream to release the file handle
                    }
                }
            }
        }
    }
}
