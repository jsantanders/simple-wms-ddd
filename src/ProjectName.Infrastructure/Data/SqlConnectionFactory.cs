using System;
using System.Data;
using Microsoft.Data.SqlClient;
using ProjectName.Application.Common;

namespace ProjectName.Infrastructure.Data
{
    public class SqlConnectionFactory : ISqlConnectionFactory, IDisposable
    {

        private readonly string connectionString;
        private IDbConnection connection;

        public SqlConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (this.connection == null || this.connection.State != ConnectionState.Open)
            {
                this.connection = new SqlConnection(this.connectionString);
                this.connection.Open();
            }

            return this.connection;
        }

        public IDbConnection CreateNewConnection()
        {
            this.connection = new SqlConnection(this.connectionString);
            this.connection.Open();
            
            return this.connection;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        public void Dispose()
        {
            if (this.connection != null && this.connection.State == ConnectionState.Open)
            {
                this.connection.Dispose();
            }
        }
    }
}
