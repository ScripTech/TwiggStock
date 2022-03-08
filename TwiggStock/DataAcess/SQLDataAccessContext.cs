using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace TwiggStock.DataAcess
{
    public class SQLDataAccessContext
    {
        public static string GetConnectionStringConf(string ConnectionName = "SQLConnectionString")
        {
            // Build connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";   // update me on prodution env
            builder.UserID = "sa";              // update me on prodution env
            builder.Password = "81BLIizMukwL";      // update me prodution env
            builder.InitialCatalog = "kz_twigg_stock";

            return builder.ConnectionString;
        }

        public static async Task<List<T>> QueryData<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionStringConf()))
            {
                var response = await conn.QueryAsync<T>(sql, parameters);

                return response.ToList();
            }
        }


        public static async Task StoreData<T>(string sql, T parameters)
        {
            using (IDbConnection conn = new SqlConnection(GetConnectionStringConf()))
            {
                await conn.ExecuteAsync(sql, parameters);
            }
        }
    }
}
