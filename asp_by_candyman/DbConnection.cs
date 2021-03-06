using System.Collections.Generic;
using System.Data;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace asp_candyman
{
    public class DbConnector
    {
        private readonly IOptions<MySqlOptions> MySqlConfig;

        public DbConnector(IOptions<MySqlOptions> config)
        {
            MySqlConfig = config;
        }
        internal IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(MySqlConfig.Value.ConnectionString);
            }
        }

        public List<Dictionary<string, object>> Query(string query)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using (IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = query;
                    dbConnection.Open();
                    var result = new List<Dictionary<string, object>>();
                    using(IDataReader datareader = command.ExecuteReader())
                    {
                        while(datareader.Read())
                        {
                            var dict = new Dictionary<string, object>();
                            for (int i = 0; i < datareader.FieldCount; i++)
                            {
                                dict.Add(datareader.GetName(i), datareader.GetValue(i));
                            }
                            result.Add(dict);
                        }
                        return result;
                    }
                }
            }
        }

        public void Execute(string query)
        {
            using(IDbConnection dbConnection = Connection)
            {
                using(IDbCommand command = dbConnection.CreateCommand())
                {
                    command.CommandText = query;
                    dbConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}