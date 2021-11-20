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

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для WindowShoppingList.xaml
    /// </summary>
    public partial class WindowShoppingList : Window
    {
        public WindowShoppingList(Dictionary<int, DataRowView> shoppingList)
        {
            InitializeComponent();
            FillTable(shoppingList);
        }   
        private void FillTable(Dictionary<int, DataRowView> shoppingList)
        {
            //ShoppingListDataGrid.ItemsSource = shoppingList;    
        }
        private void ButtonToPayment_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonToReturn_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
