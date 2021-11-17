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
        public string  NameOfNewItem
        {
            get { return TextBoxAdd.Text; }
        }

        

        private KindTable _kind;
        public WindowAddColourOrType(KindTable kind)
        {
            InitializeComponent();
            _kind = kind;
            switch (_kind)
            {
                case KindTable.Type:
                    LabelAdd.Content += " тип";
                    break;
                case KindTable.Color:
                    LabelAdd.Content += " цвет";
                    break;
            }
        }


        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxAdd.Text))
            {
                MessageBox.Show("Заполните поле");
                return;
            }

            switch (_kind)
            {
                case KindTable.Type:
                    DataBaseHandler.AddItemToColorOrType(TextBoxAdd.Text, "Types");
                    break;
                case KindTable.Color:
                    DataBaseHandler.AddItemToColorOrType(TextBoxAdd.Text, "Colors");
                    break;
            }
            Close();
        }
    }
}
