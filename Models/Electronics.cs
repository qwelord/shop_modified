namespace Shop_Lukashevich.Models
{
    public class Electronics : Shop
    {
        public int BatteryCapacity { get; set; }
        public int Speed { get; set; }

        public Electronics()
        {
        }

        public Electronics(string name, int price, int batteryCapacity, int speed) : base(name, price)
        {
            BatteryCapacity = batteryCapacity;
            Speed = speed;
        }

        public Electronics(int id, string name, int price, int batteryCapacity, int speed) : base(id, name, price)
        {
            BatteryCapacity = batteryCapacity;
            Speed = speed;
        }
    }
}
