using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnShopOnl
{
    public class Device
    {
        public int id;
        public string name;
        public int idCategory;
        public int price;
        public string monitor;
        public string cpu;
        public string ram;
        public string rom;
        public string brand;
        public int battery;
        public string gpu;
        public int camera;
        public string os;
        public string imageSource;
        public int remain;

        public Device(int id, string name, int price, string monitor, string cpu, string gpu, string ram, string rom, string brand, int battery, int camera, string os, string imageSource, int idCategory, int remain)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.monitor = monitor;
            this.cpu = cpu;
            this.gpu = gpu;
            this.ram = ram;
            this.rom = rom;
            this.brand = brand;
            this.battery = battery;
            this.camera = camera;
            this.os = os;
            this.imageSource = imageSource;
            this.idCategory = idCategory;
            this.remain = remain;
        }
    }
}
