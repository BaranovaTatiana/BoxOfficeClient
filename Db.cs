using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class Db
    {
        private string _conStr;
        public SqlConnection SqlConnection;

        public Food FoodTable;

        public TypeProducts TypeTable;

        public ColorProducts ColorTable;


        public Db(string connectionString)
        {
            _conStr = connectionString;
            FoodTable = new Food(this);
            TypeTable = new TypeProducts(this);
            ColorTable = new ColorProducts(this);
        }   

        public void ConnectionToDb()
        {
           SqlConnection = new SqlConnection(_conStr);
           SqlConnection.Open();
        }

        public void DisconnectionToDb()
        {
            SqlConnection.Close();
        }
    }
}
