using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace SocialNetworks.DAL.Repositories
{
    public class BaseRepositories
    {
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection(@"Data Source = C:\\Users\\user\\Desktop\\Date Base\\social_network_bd.db; Version = 3");
        }
    }
}
