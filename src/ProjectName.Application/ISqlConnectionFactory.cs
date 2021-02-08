using System.Data;

namespace ProjectName.Application
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
