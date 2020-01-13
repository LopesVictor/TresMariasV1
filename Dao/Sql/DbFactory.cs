using MySql.Data.MySqlClient;

namespace Dao.Sql
{
    public class DbFactory
    {
        private string _connectionString { get; set; }

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public MySqlCommand CreateCommand()
        {
            return new MySqlCommand();
        }
    }
}
