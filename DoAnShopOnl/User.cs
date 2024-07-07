using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnShopOnl
{
    public class User
    {
        public string displayName;
        public string gmail;
        public string phoneNumber;
        public DateTime dateTime;
        public long balance;

        public void LoadData(string displayName, string gmail, string phoneNumber)
        {
            this.displayName = displayName;
            this.gmail = gmail;
            this.phoneNumber = phoneNumber;
        }
    }
}
