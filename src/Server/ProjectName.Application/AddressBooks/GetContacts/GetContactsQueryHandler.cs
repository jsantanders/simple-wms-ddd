using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using ProjectName.Application.SeedWork;
using ProjectName.Application.SeedWork.Queries;
using ProjectName.Domain.Contracts;

namespace ProjectName.Application.AddressBooks.GetContacts
{
    internal class GetContactsQueryHandler : IQueryHandler<GetContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IExecutionContextAccessor contextExecutionAccessor;
        private readonly ISqlConnectionFactory sqlConnectionFactory;

        public GetContactsQueryHandler(
            IExecutionContextAccessor contextExecutionAccessor,
            ISqlConnectionFactory sqlConnectionFactory)
        {
            this.contextExecutionAccessor = contextExecutionAccessor;
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public Task<IEnumerable<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var connection = sqlConnectionFactory.GetOpenConnection();

            string sql = "SELECT         " +
                         "id,            " +
                         "FirstName,     " +
                         "MiddleName,    " +
                         "LastName,      " +
                         "Country,       " +
                         "State,         " +
                         "City,          " +
                         "AddressLine1,  " +
                         "AddressLine2,  " +
                         "CompanyName,   " +
                         "CompanyTitle,  " +
                         "EmailType,     " +
                         "EmailValue,    " +
                         "TelephoneType, " +
                         "PhoneNumber,   " +
                         "LabelName,     " +
                         "LabelColor     " +
                         "FROM [dbo].[ContactView] " +
                         "WHERE [userId] = @userId";

            var contacts = connection.QueryAsync<ContactDto>(sql, new { userId = contextExecutionAccessor.UserId });

            return contacts;
        }
    }
}
