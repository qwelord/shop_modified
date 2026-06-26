using MySql.Data.MySqlClient;
using Shop.Data.Common;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.DataBase
{
    public class DBCategory : ICategorys
    {
        public IEnumerable<Categorys> AllCategorys
        {
            get
            {
                List<Categorys> categorys = new List<Categorys>();
                MySqlConnection mySqlConnection = Connection.MySqlOpen();
                MySqlDataReader categorysData = Connection.MySqlQuery("SELECT * FROM Shop.Categorys ORDER BY `Name`;", mySqlConnection);

                while (categorysData.Read())
                {
                    categorys.Add(new Categorys()
                    {
                        Id = categorysData.IsDBNull(0) ? -1 : categorysData.GetInt32(0),
                        Name = categorysData.IsDBNull(1) ? null : categorysData.GetString(1),
                        Description = categorysData.IsDBNull(2) ? null : categorysData.GetString(2)
                    });
                }

                Connection.MySqlClose(mySqlConnection);
                return categorys;
            }
        }
    }
}