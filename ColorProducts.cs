using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class ColorProducts
    {
        private Db _db;

        private SqlConnection _connection
        {
            get { return _db.SqlConnection; }
        }

        public ColorProducts(Db db)
        {
            _db=db;
        }
        public List<RowColor> GetAllRows()
        {
            string sqlExpression = "select * from colors";
            return GetRowColors(sqlExpression);
        }
       
        
        public RowColor GetRow(int id)
        {
            string sqlExpression = "select name from colors where id = " + id + "";
            return GetRowColors(sqlExpression)[0];
        }
        public void DeleteRow(int id)
        {
            string sqlExpression = "DELETE FROM Food colors id = " + id + "";
            RequestToDb(sqlExpression);
        }
        public void InsertRow(RowColor rc)
        {
            string sqlExpression = "insert into colors values('" + rc.Name + "')";
            RequestToDb(sqlExpression);
        }
        private void RequestToDb(string sqlExpression) // запрос к базе данных
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();
        }
        private List<RowColor> GetRowColors(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            dataAdp.Fill(dt);
            return dt.Select().Select(r => new RowColor(int.Parse(r[0].ToString()), r[1].ToString())).ToList();
        }
    }
}
