using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class Food
    {
        private Db _db;
        private SqlConnection _connection
        {
            get { return _db.SqlConnection; }
        }

        public Food(Db db)
        {
            _db = db;
        }

        public List<RowFoodExtended> GetAllRowsExtended() //расширенный (возвращает таблицу совмещенную с другими, полная словесная информация о продуктах )
        {
            string sqlExpression = "select Food.ID, Name, Types.Type, Colors.Color, Price " +
                                   "from Food inner join Types " +
                                   "on Food.Type = Types.ID inner join Colors " +
                                   "on Food.Color = Colors.ID";
            return GetRowFoodsExtended(sqlExpression);
        }
        public List<RowFood> GetAllRows() //возращает таблицу в первозданном виде как в базе данных
        {
            string sqlExpression = "select * from food";
            return GetRowFoods(sqlExpression);
        }

        public RowFood GetRow(int id)
        {
            string sqlExpression = "select name from food where id = " + id + "";
            return GetRowFoods(sqlExpression)[0];
        }
        public void DeleteRow(int id)
        {
            string sqlExpression = "DELETE FROM Food WHERE id = " + id + ""; 
            RequestToDb(sqlExpression);
        }
        public void InsertRow(RowFood rf)
        {
            string sqlExpression = "insert into Food values('" + rf.Name + "', " + rf.ColorId + ", " + rf.Price + ", " +
                                   rf.TypeId + ")";
            RequestToDb(sqlExpression);
        }
        private void RequestToDb(string sqlExpression) // запрос к базе данных
        {
             SqlCommand command = new SqlCommand(sqlExpression, _connection);
             command.ExecuteNonQuery();
        }
        private List<RowFoodExtended> GetRowFoodsExtended(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); 
            
            dataAdp.Fill(dt);
            return dt.Select().Select(r => new RowFoodExtended(int.Parse(r[0].ToString()), r[1].ToString(), r[2].ToString(),
                r[3].ToString(), double.Parse(r[4].ToString()))).ToList();

        }
        private List<RowFood> GetRowFoods(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable(); 
            
            dataAdp.Fill(dt);
            return dt.Select().Select(r => new RowFood(int.Parse(r[0].ToString()), r[1].ToString(), int.Parse(r[2].ToString()),
                int.Parse(r[3].ToString()), double.Parse(r[4].ToString()))).ToList();
        }
    }
}   
            