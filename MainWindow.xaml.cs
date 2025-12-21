using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shop_Lukashevich
{
    public partial class MainWindow : Window
    {
        List<object> AllItems = new Models.ShopContext().All();

        public MainWindow()
        {
            InitializeComponent();
            CreateUI();
        }

        public void CreateUI()
        {
            foreach (object Item in AllItems)
            {
                parent.Children.Add(new Elements.Item(Item));
            }
        }

        public List<object> SearchByAnyCharacteristic(string keyword)
        {
            keyword = keyword.ToLower();

            return AllItems.Where(item =>
            {
                if (item is Models.Shop shop &&
                    (shop.Name.ToLower().Contains(keyword) ||
                     shop.Price.ToString().Contains(keyword)))
                    return true;

                if (item is Models.Children child &&
                    child.Age.ToString().Contains(keyword))
                    return true;

                if (item is Models.Sport sport &&
                    sport.Size.ToLower().Contains(keyword))
                    return true;

                if (item is Models.Electronics electronics &&
                    (electronics.BatteryCapacity.ToString().Contains(keyword) ||
                     electronics.Speed.ToString().Contains(keyword)))
                    return true;

                return false;
            }).ToList();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string keyword = tb_Search.Text.Trim();
            var results = SearchByAnyCharacteristic(keyword);
            parent.Children.Clear();
            foreach (var item in results)
            {
                parent.Children.Add(new Elements.Item(item));
            }

            if (results.Count == 0)
            {
                MessageBox.Show("Ничего не найдено");
            }
        }
    }
}
