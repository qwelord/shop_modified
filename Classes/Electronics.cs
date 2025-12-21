using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_Lukashevich.Classes
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int Speed { get; set; }
        public Electronics(string name, int price, int batteryCapacity, int speed) : base(name, price)
        {
            BatteryCapacity = batteryCapacity;
            Speed = speed;
        }
    }
}
