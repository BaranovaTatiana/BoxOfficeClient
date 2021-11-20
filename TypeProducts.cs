using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxOffice
{
    public class TypeProducts
    {
        private Db _db;

        private SqlConnection _connection
        {
            get { return _db.SqlConnection; }
        }
        public TypeProducts(Db db)
        {
            _db=db;
        }
        public List<RowType> GetAllRows()
        {
            string sqlExpression = "select * from types";
            return GetRowTypes(sqlExpression);
        }
        
        public RowType GetRow(int id)
        {
            string sqlExpression = "select name from types where id = " + id + "";
            return GetRowTypes(sqlExpression)[0];
        }
        public void DeleteRow(int id)
        {
            string sqlExpression = "DELETE FROM types WHERE id = " + id + "";
            RequestToDb(sqlExpression);
        }
        public void InsertRow(RowType rowType)
        {
            string sqlExpression = "insert into types values('" + rowType.Name + "')";
            RequestToDb(sqlExpression);
        }
        private void RequestToDb(string sqlExpression) // запрос к базе данных
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();
        }
        private List<RowType> GetRowTypes(string sqlExpression)
        {
            SqlCommand command = new SqlCommand(sqlExpression, _connection);
            command.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            dataAdp.Fill(dt);
            return dt.Select().Select(r => new RowType(int.Parse(r[0].ToString()), r[1].ToString())).ToList();
        }

    }
}
