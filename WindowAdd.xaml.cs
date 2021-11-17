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
        //private DataTable _dtTypes = new DataTable("Types");
        //private DataTable _dtColors = new DataTable("Colors");

        private int _idType = 0;
        private int _idColor = 0;
        public WindowAdd()
        {
            InitializeComponent();
            FillColors();
            FillTypes();
            //InitializeColorsAndTypes();
        }

        private void FillColors()
        {
            foreach (DataRow row in DataBaseHandler.GetColorsOrTypes("Color", "Colors").Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    AddItemToComboBox(item.ToString(), ColorCombo);
                }
            }
            
        }
        private void FillTypes()
        {
            foreach (DataRow row in DataBaseHandler.GetColorsOrTypes("Type", "Types").Rows)
            {
                foreach (object item in row.ItemArray)
                {
                    AddItemToComboBox(item.ToString(), TypeCombo);
                }
            }
            
        }

        private void AddItemToComboBox(string newItem, ComboBox cb)
        {
            cb.Items.Add(newItem);
        }
        private void AddNewColorButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAddColourOrType newProduct = new WindowAddColourOrType(KindTable.Color);
            newProduct.ShowDialog();
            AddItemToComboBox(newProduct.NameOfNewItem, ColorCombo);
        }

        private void AddNewTypeButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowAddColourOrType newProduct = new WindowAddColourOrType(KindTable.Type);

            newProduct.ShowDialog();
            AddItemToComboBox(newProduct.NameOfNewItem, TypeCombo);
        }

        private void TypeCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _idType = TypeCombo.SelectedIndex+1;
        }

        private void ColorCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _idColor = ColorCombo.SelectedIndex + 1;
        }

        private void AddToDbButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (NewName.Text == "" || NewPrice.Text == "" || ColorCombo.SelectedValue == null ||
                TypeCombo.SelectedValue == null)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            //int price = Int32.Parse(NewPrice.Text);
            //string sqlExpression = "insert into Food values('" + NewName.Text + "', " + _idColor + ", " + price + ", " + _idType + ")";
            DataBaseHandler.AddItemToFood(NewName.Text, _idColor.ToString(), NewPrice.Text.ToString(), _idType.ToString());
        }
    }

}
