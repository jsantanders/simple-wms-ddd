using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;

namespace ProjectName.Application.Queries.ListProjectName
{
    public class ListProjectNameQueryHandler : IRequestHandler<ListProjectNameQuery, List<ProjectNameDto>>
    {
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public ListProjectNameQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<List<ProjectNameDto>> Handle(ListProjectNameQuery request, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            var result = await connection.QueryAsync<ProjectNameDto>(
                "SELECT id, name FROM [dbo].[ProjectName]");
            
            return result.ToList();
        }
    }
}
