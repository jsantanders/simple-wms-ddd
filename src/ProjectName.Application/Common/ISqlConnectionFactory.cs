using System.Data;

namespace ProjectName.Application.Common
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();

        IDbConnection CreateNewConnection();

        string GetConnectionString();
    }
}
