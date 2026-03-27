using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Shop_Lukashevich.Models;

namespace Shop.Data.Common
{
    public class DbSeeder
    {
        public static void SeedData()
        {
            List<object> mockData = new List<object>
            {
                new Children("Конструктор", 1500, 6),
                new Sport("Мяч футбольный", 2000, "5"),
                new Electronics("Электросамокат", 25000, 10000, 25)
            };

            using (MySqlConnection conn = Connection.MySqlOpen())
            {
                foreach (var item in mockData)
                {
                    int categoryId = 1;
                    string characteristic = "";

                    if (item is Children c)
                    {
                        categoryId = 1;
                        characteristic = c.Age.ToString();
                    }
                    else if (item is Sport s)
                    {
                        categoryId = 2;
                        characteristic = s.Size;
                    }
                    else if (item is Electronics e)
                    {
                        categoryId = 3;
                        characteristic = $"{e.BatteryCapacity},{e.Speed}";
                    }

                    Shop shopItem = (Shop)item;
                    string query = "INSERT INTO Items (IdCategory, Name, Price, ImagePath, Discount, Characteristic) " +
                                   "VALUES (@cat, @name, @price, @path, @disc, @char)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cat", categoryId);
                    cmd.Parameters.AddWithValue("@name", shopItem.Name);
                    cmd.Parameters.AddWithValue("@price", shopItem.Price);
                    cmd.Parameters.AddWithValue("@path", shopItem.ImagePath ?? "");
                    cmd.Parameters.AddWithValue("@disc", shopItem.Discount);
                    cmd.Parameters.AddWithValue("@char", characteristic);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}