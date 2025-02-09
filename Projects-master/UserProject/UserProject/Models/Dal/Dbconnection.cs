using System.Data.SqlClient;
namespace UserProject.Models.Dal
{
    public class Dbconnection
    {
        public SqlConnection connection()
        {
            return new SqlConnection(ConnectionString);

        }
        public string ConnectionString
        {
            get
            {
                string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=restaurantDb;Integrated Security=True;Connect Timeout=30";
                return conn;
            }
        }
    }
}
