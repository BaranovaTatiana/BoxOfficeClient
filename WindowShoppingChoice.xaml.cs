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
    /// Логика взаимодействия для WindowShoppingChoice.xaml
    /// </summary>
    public partial class WindowShoppingChoice : Window
    {
        //private Dictionary<int, RowFood> _shoppingList = new Dictionary<int, RowFood>();
       
        private List<RowFoodExtended> _shoppingList = new List<RowFoodExtended>();
        public WindowShoppingChoice()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
           InfoDataGrid.ItemsSource = App.MainDb.Food.GetAllRowsExtended();
        }
        private void ButtonFurther_OnClick(object sender, RoutedEventArgs e)
        {
            WindowShoppingList windowShopping = new WindowShoppingList(_shoppingList);
            windowShopping.Show();  
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if (InfoDataGrid != null && InfoDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите что хотите купить");
                return;
            }


            //if (InfoDataGrid != null)
            //{
            //    var rf = InfoDataGrid.SelectedItem as RowFoodExtended;

            //    if (ComboBoxCountProducts.SelectedItem == null) rf.Count = 1;
            //    else rf.Count = int.Parse(ComboBoxCountProducts.SelectionBoxItem.ToString());

            //    _shoppingList.Add(rf);
            //    MessageBox.Show("Продукт добавлен в корзину!");
            //    ComboBoxCountProducts.SelectedIndex = -1;
            //}
        }
            
        private void ButtonBasket_OnClick(object sender, RoutedEventArgs e)
        {
            WindowDeleteChoiceProducts delete = new WindowDeleteChoiceProducts(_shoppingList);
            delete.Show();

        }

        private void ButtonMinus_OnClick(object sender, RoutedEventArgs e)
        {
            //int.Parse(TextBlockCountProducts.Text.ToString()) -= 1;
        }

        private void ButtonPlus_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
