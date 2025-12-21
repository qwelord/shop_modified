namespace Shop_Lukashevich.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
        public int Discount { get; set; }

        public Shop()
        {
        }

        public Shop(string name, int price)
        {
            Name = name;
            Price = price;
            ImagePath = "";
            Discount = 0;
        }

        public Shop(int id, string name, int price, string imagePath, int discount)
        {
            Id = id;
            Name = name;
            Price = price;
            ImagePath = imagePath;
            Discount = discount;
        }

        public int GetDiscountedPrice()
        {
            return Price - (Price * Discount / 100);
        }
    }
}
