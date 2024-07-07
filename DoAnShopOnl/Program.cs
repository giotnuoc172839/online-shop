using DoAnShopOnl.Admin;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnShopOnl
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Set application-wide culture to Vietnamese (Vietnam)
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("vi-VN");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("vi-VN");
            Application.Run(new fClient());
        }
    }
}
