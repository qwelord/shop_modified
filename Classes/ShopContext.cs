using Shop_Lukashevich.Classes.Common;
using Shop_Lukashevich.Interfaces;
using Shop_Lukashevich.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;

namespace Shop_Lukashevich.Classes
{
    public class ShopContext : Shop, IContext
    {
        public ShopContext()
        {
        }

        public ShopContext(int Id, string Name, int Price) : base(Id, Name, Price)
        {
        }

        public List<object> All()
        {
            List<object> allShop = new List<object>();

            OleDbConnection connection = Common.DBConnect.Connection();
            OleDbDataReader shopData = Common.DBConnect.Query("SELECT * FROM [Товар]", connection);

            while (shopData.Read())
            {
                ShopContext newShop = new ShopContext(
                    shopData.GetInt32(0),
                    shopData.GetString(1),
                    shopData.GetInt32(2)
                );
                allShop.Add(newShop);
            }

            Common.DBConnect.CloseConnection(connection);

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
