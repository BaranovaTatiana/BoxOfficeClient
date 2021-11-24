using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using DataBaseContact;

namespace BoxOffice
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string _connectionString = "Data Source=r00tER-FullPc;Initial Catalog=DBwithCSharp;Integrated Security=True";
        public static Db MainDb = new Db(_connectionString);
    }
}
