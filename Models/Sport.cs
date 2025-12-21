namespace Shop_Lukashevich.Models
{
    public class Sport : Shop
    {
        public string Size { get; set; }

        public Sport()
        {
        }

        public Sport(string Name, int Price, string Size) : base(Name, Price)
        {
            this.Size = Size;
        }

        public Sport(int Id, string Name, int Price, string Size) : base(Id, Name, Price)
        {
            this.Size = Size;
        }
    }
}
