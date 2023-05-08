using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string Sql, U parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(Sql, parameters);
                return data.ToList();
            }
        }

        public async Task<string> SaveData<T>(string Sql, T parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var obj = await connection.ExecuteAsync(Sql, parameters);

                if (obj > 0)
                {
                    Console.WriteLine("Query executed successfully and updated {0} rows.", obj);
                    return "Updated";
                }
                else
                {
                    Console.WriteLine("Query did not update any rows.");
                    return "Try Again";
                }
            }
        }
    }
}
