using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Shop_Lukashevich.Classes.Common;
using Shop_Lukashevich.Interfaces;

namespace Shop_Lukashevich.Models
{
    public class ShopContext : Shop, IContext
    {
        public List<object> All()
        {
            List<object> allItems = new List<object>();
            using (MySqlConnection connection = DBConnect.Connection())
            {
                MySqlDataReader reader = DBConnect.Query("SELECT i.*, c.Name as CategoryName FROM Items i JOIN Categorys c ON i.IdCategory = c.Id", connection);
                while (reader.Read())
                {
                    int id = reader.GetInt32("Id");
                    string name = reader.GetString("Name");
                    int price = reader.GetInt32("Price");
                    string path = reader.IsDBNull(reader.GetOrdinal("ImagePath")) ? "" : reader.GetString("ImagePath");
                    int discount = reader.GetInt32("Discount");
                    string category = reader.GetString("CategoryName");
                    string characteristic = reader.GetString("Characteristic");

                    if (category == "Children")
                        allItems.Add(new Children(id, name, price, path, discount, int.Parse(characteristic)));
                    else if (category == "Sport")
                        allItems.Add(new Sport(id, name, price, path, discount, characteristic));
                    else if (category == "Electronics")
                    {
                        var parts = characteristic.Split(',');
                        allItems.Add(new Electronics(id, name, price, path, discount, int.Parse(parts[0]), int.Parse(parts[1])));
                    }
                    else
                        allItems.Add(new Shop(id, name, price, path, discount));
                }
            }
            return allItems;
        }

        public void Delete() { }
        public void Save(bool Update = false) { }
    }
}