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
    /// Логика взаимодействия для WindowShoppingChoice.xaml
    /// </summary>
    public partial class WindowShoppingChoice : Window
    {
        private Dictionary<int, DataRowView> _shoppingList = new Dictionary<int, DataRowView>();
       

        public WindowShoppingChoice()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            InfoDataGrid.ItemsSource = DataBaseHandler.GetAllItems().DefaultView;
        }
        private void ButttonFurther_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            if ((DataRowView) InfoDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите что хотите купить");
                return;
            }

            int count = Int32.Parse(ComboBoxCountProducts.SelectionBoxItem.ToString());
            _shoppingList.Add(count, (DataRowView)InfoDataGrid.SelectedItem);
        }

        private void ButtonDelete_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
