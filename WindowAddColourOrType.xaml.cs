using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для WindowAddColourOrType.xaml
    /// </summary>
    public partial class WindowAddColourOrType : Window
    {
        public WindowAddColourOrType()
        {
            InitializeComponent();
        }

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            string sqlExpression1 = "insert into Food values(@name, @_idColor, @price, @_idType)";
            using (SqlConnection connection = new SqlConnection(App.ConnectionString))
            {
                connection.Open();

                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);

                //command1.Parameters.AddWithValue("@name", NewName.Text);
                //command1.Parameters.AddWithValue("@_idColor", _idColor);
                //command1.Parameters.AddWithValue("@price", price);
                //command1.Parameters.AddWithValue("@_idType", _idType);

                command1.ExecuteNonQuery();
                connection.Close();
            }
            Close();



        }
    }
}
