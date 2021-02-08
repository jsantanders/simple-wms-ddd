using System;
using System.Data;
using ProjectName.Application;
using Microsoft.Data.SqlClient;

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

        public void Dispose()
        {
            if (this.connection != null && this.connection.State == ConnectionState.Open)
            {
                this.connection.Dispose();
            }
        }
    }
}
