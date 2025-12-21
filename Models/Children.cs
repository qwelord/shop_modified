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

        public Children(int Id, string Name, int Price, int Age) : base(Id, Name, Price)
        {
            this.Age = Age;
        }
    }
}
