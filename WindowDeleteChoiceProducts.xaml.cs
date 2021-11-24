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
using System.Windows.Shapes;
using DataBaseContact;

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для WindowDeleteChoiceProducts.xaml
    /// </summary>
    public partial class WindowDeleteChoiceProducts : Window
    {
        private List<RowFoodExtended> _shoppingList = new List<RowFoodExtended>();
        public WindowDeleteChoiceProducts(List<RowFoodExtended> shoppingList)
        {
            InitializeComponent();
            _shoppingList = shoppingList;
            FillTable();


        }
        private void FillTable()
        {
            if (_shoppingList == null) MessageBox.Show("Список покупок пуст");
            else DataGridChoiceProducts.ItemsSource = _shoppingList;
        }
        private void ButtonReturn_OnClick(object sender, RoutedEventArgs e)
        { 
            Close();
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
           var rf = DataGridChoiceProducts.SelectedItem as RowFoodExtended;
           _shoppingList.Remove(rf);
           MessageBox.Show("Продукт удален из списка");
        }

        private void ButtonPay_OnClick(object sender, RoutedEventArgs e)
        {
            WindowShoppingList pay = new WindowShoppingList(_shoppingList);
            pay.Show();
            Close();
        }
    }
}
