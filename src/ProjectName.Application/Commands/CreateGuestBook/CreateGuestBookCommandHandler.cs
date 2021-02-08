using System;
using System.Threading;
using System.Threading.Tasks;
using ProjectName.Domain.Contracts;
using ProjectName.Domain.Entities;
using MediatR;

namespace ProjectName.Application.Commands.CreateProjectName
{
    public class CreateProjectNameCommandHandler : IRequestHandler<CreateProjectNameCommand, Guid>
    {
        private readonly IRepository repository;

        public CreateProjectNameCommandHandler(IRepository repository)
        {
            this.repository = repository;
        }
        
        public async Task<Guid> Handle(CreateProjectNameCommand request, CancellationToken cancellationToken)
        {
            var ProjectNameDict = ProjectNameDict.Create(request.Name);
            var result = await repository.Create(ProjectNameDict);

            return result.Id;
        }
    }
}
