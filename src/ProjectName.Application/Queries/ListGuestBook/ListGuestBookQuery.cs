using System.Collections.Generic;
using MediatR;

namespace ProjectName.Application.Queries.ListProjectName
{
    public class ListProjectNameQuery : IRequest<List<ProjectNameDto>>
    {
    }
}
