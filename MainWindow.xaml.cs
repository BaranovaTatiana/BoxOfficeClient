using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void ButtonToStorehouse_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonHelp_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonBye_OnClick(object sender, RoutedEventArgs e)
        {
            WindowShoppingChoice windowShopping = new WindowShoppingChoice();
            windowShopping.Show();
        }
    }
}
