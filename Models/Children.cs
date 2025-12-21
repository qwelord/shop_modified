namespace Shop_Lukashevich.Models
{
    public class Children : Shop
    {
        public int Age { get; set; }

        public Children()
        {
        }

        public Children(string Name, int Price, int Age) : base(Name, Price)
        {
            this.Age = Age;
        }

        public Children(int Id, string Name, int Price, string ImagePath, int Discount, int Age) : base(Id, Name, Price, ImagePath, Discount)
        {
            this.Age = Age;
        }
    }
}
