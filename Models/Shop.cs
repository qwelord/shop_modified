namespace Shop_Lukashevich.Classes
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Shop()
        {
        }

        public Shop(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public Shop(int id, string name, int price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
