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

namespace Shop_Lukashevich.Elements
{
    public partial class Item : UserControl
    {
        public Item(object ItemData)
        {
            InitializeComponent();
            Models.Shop ShopData = ItemData as Models.Shop;
            tb_Name.Content = ShopData.Name;
            tb_Price.Content = "Цена: " + ShopData.Price;

            if (!string.IsNullOrEmpty(ShopData.ImagePath))
            {
                img_Item.Source = new BitmapImage(new Uri(ShopData.ImagePath));
            }
            else
            {
                img_Item.Source = new BitmapImage(new Uri("/Shop_Lukashevich;component/Images/ic_item.png", UriKind.Relative));
            }

            if (ShopData.Discount > 0)
            {
                tb_DiscountedPrice.Content = $"Скидка: {ShopData.Discount}% | Цена: {ShopData.GetDiscountedPrice()}";
            }
            else
            {
                tb_DiscountedPrice.Content = "Скидка: Нет";
            }

            if (ItemData is Models.Children)
            {
                Models.Children ChildrenData = ItemData as Models.Children;
                tb_Characteristic.Content = "Возраст: " + ChildrenData.Age;
            }
            if (ItemData is Models.Sport)
            {
                Models.Sport SportData = ItemData as Models.Sport;
                tb_Characteristic.Content = "Размер: " + SportData.Size;
            }
            if (ItemData is Models.Electronics)
            {
                Models.Electronics electronicsData = ItemData as Models.Electronics;
                tb_Characteristic.Content = $"Батарея: {electronicsData.BatteryCapacity} мАч, Скорость: {electronicsData.Speed} км/ч";
            }
        }
    }
}
