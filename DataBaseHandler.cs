using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BoxOffice
{
    public static class DataHandler
    {
        private static string _connectionString = "Data Source=r00tER-FullPc;Initial Catalog=DBwithCSharp;Integrated Security=True";

        public static DataTable GetAllItems()
        {
            string sqlExpression = "select Food.ID, Name, Types.Type, Colors.Color, Price " +
                                   "from Food inner join Types " +
                                   "on Food.Type = Types.ID inner join Colors " +
                                   "on Food.Color = Colors.ID";
            return GetTableFromDb(sqlExpression);
        }
        public static DataTable GetColorsOrTypes(string items, string table)
        {
            string sqlExpression = "select " + items + " from " + table + "";
            return GetTableFromDb(sqlExpression);
        }   
        public static void AddItemToFood(string newName, int idColor, double price, int idType)
        {
            AddItemToFood(newName, idColor, price, idType);
        }
        public static void AddItemToFood(string newName, string idColor, string price, string idType)
        {
            string sqlExpression = "insert into Food values('" + newName + "', " + idColor + ", " + price + ", " + idType + ")";
            RequestToDb(sqlExpression);
        }
        public static void AddItemToColorOrType(string nameItem, string nameTable)
        {
            string sqlExpression = "insert into " + nameTable + " values ('" + nameItem + "')";
            RequestToDb(sqlExpression);
        }

        public static void DeleteItemFromFood(int idItem)
        {
            string sqlExpression = "DELETE FROM Food WHERE id = " + idItem + ""; 
            RequestToDb(sqlExpression);
        }


        private static void RequestToDb(string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(sqlExpression, connection);

                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private static DataTable GetTableFromDb(string sqlExpression)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Table"); // В скобках указываем название таблицы
                dataAdp.Fill(dt);

                connection.Close();
                return dt;
            }
        }
    }
}
