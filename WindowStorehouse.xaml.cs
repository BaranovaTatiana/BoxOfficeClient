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
    /// Логика взаимодействия для WindowStorehouse.xaml
    /// </summary>
    public partial class WindowStorehouse : Window
    {
        public WindowStorehouse()
        {
            InitializeComponent();
            FillTable();
        }
        private void FillTable()
        {
            InfoDataGrid.ItemsSource = DataBaseHandler.GetAllItems().DefaultView;
        }
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAdd newProduct = new WindowAdd();
            newProduct.Show();
        }
        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteItemFromMainTable();
        }

        public void DeleteItemFromMainTable()
        {
            var selectedItem = (DataRowView)InfoDataGrid.SelectedItem;
            //var gg = (DataView)InfoDataGrid.ItemsSource;
            //gg.Table.Rows.Remove(selectedItem.Row);
            var idItem = selectedItem[0];

            DataBaseHandler.DeleteItemFromFood(Int32.Parse(idItem.ToString()));

            selectedItem.Delete();

            MessageBox.Show("Продукт удален!");
        }

        private void InfoDataGrid_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteItemFromMainTable();
            }
        }
    }
}
