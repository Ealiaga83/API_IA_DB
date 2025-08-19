using MySql.Data.MySqlClient;
using Npgsql;

namespace API_IA_DB.Conexion
{
    public class Mysql
    {
        private readonly string connectionString;

        public Mysql()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            connectionString = config.GetConnectionString("MySql");
        }

        public MySqlConnection AbrirConexion()
        {
            var connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CerrarConexion(MySqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }


    public class PostgreSql
    {
        private readonly string connectionString;

        //public PostgreSql()
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(AppContext.BaseDirectory)
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .Build();

        //    connectionString = config.GetConnectionString("PostgreSql");
        //}

        public PostgreSql()
        {
            var envConnection = Environment.GetEnvironmentVariable("DATABASE_URL");

            if (!string.IsNullOrEmpty(envConnection))
            {
                var uri = new Uri(envConnection);
                var userInfo = uri.UserInfo.Split(':');

                connectionString = $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";
            }
            else
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(AppContext.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                connectionString = config.GetConnectionString("PostgreSql");
            }
        }

        public NpgsqlConnection AbrirConexion()
        {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public void CerrarConexion(NpgsqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}
