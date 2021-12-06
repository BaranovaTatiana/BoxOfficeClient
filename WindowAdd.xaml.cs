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
using DataBaseContact;

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        private int _idType =0;
        private int _idColor =0;
        public WindowAdd()
        {
            InitializeComponent();
            FillColors();
            FillTypes();
            //InitializeColorsAndTypes();
        }

        private void FillColors()
        {
            foreach (RowColor row in App.MainDb.Colors.GetAllRows())
            {
                AddItemToComboBox(row.Name, ColorCombo);
            }
            
        }
        private void FillTypes()
        {
            foreach (var rowType in App.MainDb.Types.GetAllRows())
            {
                AddItemToComboBox(rowType.Name, TypeCombo);
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
            // _idType = TypeCombo.SelectedIndex+1;

            if(App.MainDb.Types.GetAllRows().Contains(ColorCombo.SelectedItem)) _idColor = 1;
            
            foreach (var rowType in App.MainDb.Types.GetAllRows())
            {
                if (ColorCombo.SelectedItem.Equals(rowType.Name)) _idColor = rowType.Id;
            }
        }
        
        private void ColorCombo_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_idColor = ColorCombo.SelectedIndex + 1;
            foreach (var rowColor in App.MainDb.Colors.GetAllRows())
            {
                if (ColorCombo.SelectedItem.Equals(rowColor.Name)) _idColor = rowColor.Id;
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
            App.MainDb.Food.InsertRow(NewName.Text, _idType, _idColor, double.Parse(NewPrice.Text));

            MessageBox.Show("Продукт добавлен на базу");
            Close();
        }
    }

}
