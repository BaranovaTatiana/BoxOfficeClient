using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using DataBaseContact;

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для WindowShoppingList.xaml
    /// </summary>
    public partial class WindowShoppingList : Window
    {
        private List<RowFoodExtended> _shoppingList = new List<RowFoodExtended>();
        public WindowShoppingList(List<RowFoodExtended> shoppingList)
        {
            InitializeComponent();
            _shoppingList = shoppingList;
            FillShoppingList();
        }

        private void FillShoppingList()
        {
            foreach (var rowFoodExtended in _shoppingList)
            {
                ShoppingList.Text +='\n' + rowFoodExtended.ToString();
            }
            PriceAllChoiceProducts();
        }

        private void PriceAllChoiceProducts()
        {
            double price = 0;
            foreach (var rowFoodExtended in _shoppingList)
            {
                price += rowFoodExtended.Price * rowFoodExtended.Count;
            }
            AllPrice.Text += price;
        }
        private void ButtonToPayment_OnClick(object sender, RoutedEventArgs e)
        {
            _shoppingList.Clear();
            MessageBox.Show("Оплата проведена успешно!");
            Close();
        }
        private void ButtonToReturn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
