using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoAnShopOnl
{
    internal class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => instance = value;
        }

        private DataProvider()
        {

        }

        public List<deviceUct> cart = new List<deviceUct>();



        public DataTable LoadAllBillDataTableFromTextFile()
        {
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

            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                // Read each line from the text file
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line by '*'
                    string[] parts = line.Split('*');

                    // Parse the data and add a new row to the DataTable
                    DataRow row = dt.NewRow();

                    row["id"] = parts[0];
                    row["displayName"] = parts[1];
                    row["gmail"] = parts[2];
                    row["phoneNumber"] = parts[3];
                    row["address"] = parts[4];
                    row["totalPrice"] = long.Parse(parts[5]);
                    row["billDetail"] = parts[6];
                    row["dateTime"] = parts[7];
                    row["isPaid"] = int.Parse(parts[8]);

                    dt.Rows.Add(row);
                    
                }
            }

            return dt;
        }

        public DataTable LoadAllBillDataTableFromTextFileDateTime()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("gmail", typeof(string));
            dt.Columns.Add("phoneNumber", typeof(string));
            dt.Columns.Add("address", typeof(string));
            dt.Columns.Add("totalPrice", typeof(long));
            dt.Columns.Add("billDetail", typeof(string));
            dt.Columns.Add("dateTime", typeof(DateTime));
            dt.Columns.Add("isPaid", typeof(int));

            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                // Read each line from the text file
                string[] lines = File.ReadAllLines(file);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line by '*'
                    string[] parts = line.Split('*');

                    // Parse the data and add a new row to the DataTable
                    DataRow row = dt.NewRow();

                    string dateTimePart = parts[7];
                    // Define the expected format of the date and time string
                    string format = "dd/MM/yyyy h:mm:ss tt";

                    // Parse the extracted string into a DateTime object
                    DateTime parsedDateTime = DateTime.ParseExact(dateTimePart, format, CultureInfo.CurrentCulture);

                    string dateOnlyStr = parsedDateTime.ToShortDateString();

                    string newFormat = "dd/MM/yyyy";

                    DateTime NewParsedDateTime = DateTime.ParseExact(dateOnlyStr, newFormat, CultureInfo.CurrentCulture);

                    row["id"] = parts[0];
                    row["displayName"] = parts[1];
                    row["gmail"] = parts[2];
                    row["phoneNumber"] = parts[3];
                    row["address"] = parts[4];
                    row["totalPrice"] = long.Parse(parts[5]);
                    row["billDetail"] = parts[6];
                    row["dateTime"] = NewParsedDateTime;
                    row["isPaid"] = int.Parse(parts[8]);

                    dt.Rows.Add(row);

                }
            }

            return dt;
        }


        public DataTable LoadAllBillInfoDataTableFromTextFile()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("deviceName", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("quantity", typeof(int));
            dt.Columns.Add("totalPrice", typeof(long));
            dt.Columns.Add("dateTime", typeof(DateTime));

            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\BillInfo";
            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                // Read each line from the text file
                string[] lines = File.ReadAllLines(file);

                //Proccess bill dateTime from bill txt file
                string fileName = Path.GetFileNameWithoutExtension(file);

                // Extract the date and time part from the string
                string dateTimePart = fileName.Substring(fileName.IndexOf(' ') + 1);

                // Define the expected format of the date and time string
                string format = "dd_MM_yyyy h_mm_ss tt";

                // Parse the extracted string into a DateTime object
                DateTime parsedDateTime = DateTime.ParseExact(dateTimePart, format, CultureInfo.CurrentCulture);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    // Split the line by '*'
                    string[] parts = line.Split('*');

                    // Parse the data and add a new row to the DataTable
                    DataRow row = dt.NewRow();

                    int idCategory = int.Parse(parts[1]);

                    string category;

                    switch (idCategory)
                    {
                        case 1:
                            category = "Phone";
                            break;

                        case 2:
                            category = "Laptop";
                            break;
                        case 3:
                            category = "Ipad";
                            break;
                        default:
                            category = "Unknown";
                            break;
                    }

                    row["id"] = int.Parse(parts[0]);
                    row["category"] = category;
                    row["deviceName"] = parts[2];
                    row["price"] = int.Parse(parts[3]);
                    row["quantity"] = int.Parse(parts[4]);
                    row["totalPrice"] = long.Parse(parts[5]);
                    row["dateTime"] = parsedDateTime;

                    dt.Rows.Add(row);

                }
            }

            // Sort DataTable by dateTime column in ascending order
            DataView dv = dt.DefaultView;
            dv.Sort = "dateTime ASC";
            DataTable sortedDT = dv.ToTable();

            return sortedDT;
        }

        public DataTable LoadDeviceDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("idCategory", typeof(int)); //1:phone, 2:laptop, 3:ipad
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("lowPrice", typeof(int));
            dt.Columns.Add("highPrice", typeof(int));
            dt.Columns.Add("monitor", typeof(string));
            dt.Columns.Add("cpu", typeof(string));
            dt.Columns.Add("gpu", typeof(string));
            dt.Columns.Add("ram", typeof(string));
            dt.Columns.Add("rom", typeof(string));
            dt.Columns.Add("brand", typeof(string));
            dt.Columns.Add("battery", typeof(int));
            dt.Columns.Add("camera", typeof(string));
            dt.Columns.Add("os", typeof(string));
            dt.Columns.Add("imageSource", typeof(string));
            dt.Columns.Add("remain", typeof(int));

            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["id"] = int.Parse(parts[0]);
                row["idCategory"] = int.Parse(parts[1]);
                row["name"] = parts[2];
                row["lowPrice"] = int.Parse(parts[3]);
                row["highPrice"] = int.Parse(parts[4]);
                row["monitor"] = parts[5];
                row["cpu"] = parts[6];
                row["gpu"] = parts[7];
                row["ram"] = int.Parse(parts[8]);
                row["rom"] = int.Parse(parts[9]);
                row["brand"] = parts[10];
                row["battery"] = int.Parse(parts[11]);
                row["camera"] = parts[12];
                row["os"] = parts[13];
                row["imageSource"] = parts[14];
                row["remain"] = int.Parse(parts[15]);

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable LoadAccountDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("displayName", typeof(string));
            dt.Columns.Add("userName", typeof(string));
            dt.Columns.Add("password", typeof(string));
            dt.Columns.Add("gmail", typeof(string));
            dt.Columns.Add("phone", typeof(string));
            dt.Columns.Add("type", typeof(int)); //1: admin, 0: client
            dt.Columns.Add("balance", typeof(long));


            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["id"] = int.Parse(parts[0]);
                row["displayName"] = parts[1];
                row["userName"] = parts[2];
                row["password"] = parts[3];
                row["gmail"] = parts[4];
                row["phone"] = parts[5];
                row["type"] = int.Parse(parts[6]);
                row["balance"] = long.Parse(parts[7]);

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable LoadCategoryDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idCategory", typeof(int));
            dt.Columns.Add("category", typeof(string));

            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["idCategory"] = int.Parse(parts[0]);
                row["category"] = parts[1];

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable LoadBrandDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idBrand", typeof(int));
            dt.Columns.Add("brand", typeof(string));

            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["idBrand"] = int.Parse(parts[0]);
                row["brand"] = parts[1]; 

                dt.Rows.Add(row);
            }
            return dt;
        }

        public DataTable LoadStaffDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("idStaff", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("phoneNumber", typeof(string));

            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');

                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["idStaff"] = int.Parse(parts[0]);
                row["name"] = parts[1];
                row["phoneNumber"] = parts[2];

                dt.Rows.Add(row);
            }
            return dt;
        }


        public DataTable LoadBillInfoDataTableFromTextFile(string filePath)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            //dt.Columns.Add("idCategory", typeof(int));
            dt.Columns.Add("deviceName", typeof(string));
            dt.Columns.Add("price", typeof(int));
            dt.Columns.Add("quantity", typeof(int));
            dt.Columns.Add("totalPrice", typeof(long));


            // Read each line from the text file
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                // Split the line by '*'
                string[] parts = line.Split('*');


                // Parse the data and add a new row to the DataTable
                DataRow row = dt.NewRow();

                row["id"] = int.Parse(parts[0]);
                //row["idCategory"] = int.Parse(parts[1]);
                row["deviceName"] = parts[2];
                row["price"] = int.Parse(parts[3]);
                row["quantity"] = int.Parse(parts[4]);
                row["totalPrice"] = long.Parse(parts[5]);

                dt.Rows.Add(row);
            }
            return dt;
        }

        public void SaveDataTableToTextFile(DataTable dt,string filePath)
        {
            int id = 0;
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Write data rows
                foreach (DataRow row in dt.Rows)
                {
                    writer.Write(id);
                    writer.Write('*');
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        writer.Write(row[i]);
                        writer.Write('*'); // Use tab as delimiter
                    }
                    id++;
                    writer.WriteLine(); // Move to the next line
                }
                
            }
        }

        public void SaveBillDataTableToTextFile(DataTable dt, string fileName)
        {
            
            // Ensure the directory exists
            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string filePath = Path.Combine(directoryPath, fileName + ".txt");

            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    // Close the file stream to release the file handle
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Write data rows
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        writer.Write(row[i]);
                        writer.Write('*'); // Use tab as delimiter
                    }
                    writer.WriteLine(); // Move to the next line
                }
            }
        }

        public void OverrideBillDataTableToTextFile(DataTable dt, string fileName)
        {

            // Ensure the directory exists
            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\Bill";
            string filePath = Path.Combine(directoryPath, fileName + ".txt");

            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    // Close the file stream to release the file handle
                }
            }
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Write data rows
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        writer.Write(row[i]);
                        writer.Write('*'); // Use tab as delimiter
                    }
                    writer.WriteLine(); // Move to the next line
                }
            }
        }

        public void SaveBillInfoDataTableToTextFile(DataTable dt, string fileName)
        {
            // Ensure the directory exists
            string directoryPath = @"D:\Lap trinh C#\DoAnShopOnl\BillInfo";

            string filePath = Path.Combine(directoryPath, fileName + ".txt");

            // Ensure the file is created if it doesn't exist
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    // Close the file stream to release the file handle
                }
            }

            // Write data to the file
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                // Write data rows
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        writer.Write(row[i]);
                        if (i < dt.Columns.Count - 1)
                        {
                            writer.Write('*'); // Use asterisk as delimiter
                        }
                    }
                    writer.WriteLine(); // Move to the next line
                }
            }
        }

    }
}
