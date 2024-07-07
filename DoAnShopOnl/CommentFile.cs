using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    internal class CommentFile
    {
        public string userName;
        public string comment;
        public string deviceName;
        public string avaPath;
        public int gender;
        public string dateTime;
        public int starCount;

        public void SaveTxtFiles()
        {
            string directory = @"D:\Lap trinh C#\DoAnShopOnl\Comment";
            string filename = $"{deviceName}.txt"; //file name is email 
            string filepath = Path.Combine(directory, filename);
            string data = userName + "*" + comment + "*" + gender + "*" + dateTime + "*" + avaPath + "*" + starCount;


            try
            {
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.Write(data);
                    writer.WriteLine();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng ký!" + " " + ex);
            }
        }
    }
}
