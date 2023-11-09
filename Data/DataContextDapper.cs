using System.Data;
using Dapper;
using hello.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace hello.Data
{
    public class DataContextDapper
    {
        // private IConfiguration _config;
        private string _connectionString;
        // public DataContextDapper(IConfiguration config)
        // {
        //     // _config = config;
        //     _connectionString = config.GetConnectionString("DefaultConnection");
        // }

        public DataContextDapper(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            // ?? throw new InvalidOperationException("Default connection string not found in configuration");

        }


        public IEnumerable<T> LoadData<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sql);

        }
        public T LoadDataSingle<T>(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sql);

        }
        public bool ExecuteSql(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql) > 0;

        }
        public int ExecuteSqlWithRowCount(string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Execute(sql);

        }




    }
}
