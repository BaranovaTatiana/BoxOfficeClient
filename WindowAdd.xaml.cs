using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private DataTable _dtTypes = new DataTable("Types");
        private DataTable _dtColors = new DataTable("Colors");

        private int _idType = 0;
        private int _idColor = 0;
        public WindowAdd()
        {
            InitializeComponent();
            InitializeColorsAndTypes();
        }

        private void InitializeColorsAndTypes()
        {
            string sqlExpression1 = "select Type from Types";
            string sqlExpression2 = "select Color from Colors";
           
            using (SqlConnection connection = new SqlConnection(App.ConnectionString))
            {
                connection.Open();

                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);
                command1.ExecuteNonQuery();

                SqlDataAdapter dataAdp1 = new SqlDataAdapter(command1);
                //DataTable dtTypes = new DataTable("Types"); // В скобках указываем название таблицы

                dataAdp1.Fill(_dtTypes);
                foreach (DataRow row in _dtTypes.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        TypeCombo.Items.Add(item);
                    }
                    
                }

                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                command2.ExecuteNonQuery();

                SqlDataAdapter dataAdp2 = new SqlDataAdapter(command2);
                //DataTable dtColors = new DataTable("Colors"); // В скобках указываем название таблицы

                dataAdp2.Fill(_dtColors);
                foreach (DataRow row in _dtColors.Rows)
                {
                    foreach (object item in row.ItemArray)
                    {
                        ColorCombo.Items.Add(item);
                    }
                }

                connection.Close();
            }
         
        }
        private void AddToDbButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NewName.Text == "" || NewPrice.Text == "" || ColorCombo.SelectedValue == null ||
                TypeCombo.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            string name = NewName.Text;
            int price = Int32.Parse(NewPrice.Text);
            
            string sqlExpression1 = "insert into Food values('"+ NewName.Text+"', "+ _idColor+", "+ price+", "+ _idType+")";
            using (SqlConnection connection = new SqlConnection(App.ConnectionString))
            {
                connection.Open();

                SqlCommand command1 = new SqlCommand(sqlExpression1, connection);


                command1.ExecuteNonQuery();
                connection.Close();
            }
            Close();
        }

        private void AddNewColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void AddNewTypeButton_OnClick(object sender, RoutedEventArgs e)
        {
           
        }

        private void TypeCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _idType = TypeCombo.SelectedIndex+1;
        }

        private void ColorCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _idColor = ColorCombo.SelectedIndex + 1;
        }
    }
}
