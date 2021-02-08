using MediatR;
using ProjectName.Domain.Entities;
using System;

namespace ProjectName.Application.Commands.CreateProjectName
{
    public class CreateProjectNameCommand : IRequest<Guid>
    {
        public CreateProjectNameCommand(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
