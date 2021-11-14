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
            ShowMainTable();
        }

        private void ShowMainTable()
        {
            string sqlExpression = "select Food.ID, Name, Types.Type, Colors.Color, Price " +
                                   "from Food inner join Types " +
                                   "on Food.Type = Types.ID inner join Colors " +
                                   "on Food.Color = Colors.ID";
            using (SqlConnection connection = new SqlConnection(App.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Food"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);

                InfoDataGrid.ItemsSource = dt.DefaultView; // Сам вывод 

                connection.Close();
            }
        }
        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAdd newProduct = new WindowAdd();
            newProduct.Show();
        }
        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
