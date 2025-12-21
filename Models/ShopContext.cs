using System.Collections.Generic;
using System.Data.OleDb;
using Shop_Lukashevich.Classes.Common;
using Shop_Lukashevich.Interfaces;

namespace Shop_Lukashevich.Models
{
    public class ShopContext : Shop, IContext
    {
        public ShopContext()
        {
        }

        public ShopContext(int Id, string Name, int Price, string ImagePath, int Discount) : base(Id, Name, Price, ImagePath, Discount)
        {
        }

        public List<object> All()
        {
            List<object> allShop = new List<object>();

            OleDbConnection connection = DBConnect.Connection();
            OleDbDataReader shopData = DBConnect.Query("SELECT * FROM [Товар]", connection);

            while (shopData.Read())
            {
                ShopContext newShop = new ShopContext(
                    shopData.GetInt32(0),
                    shopData.GetString(1),
                    shopData.GetInt32(2),
                    shopData.GetString(3),
                    shopData.GetInt32(4)
                );
                allShop.Add(newShop);
            }

            DBConnect.CloseConnection(connection);

            return allShop;
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Save(bool Update = false)
        {
            throw new System.NotImplementedException();
        }
    }
}
