using System.Threading.Tasks;
using ProjectName.Application.SeedWork.Commands;
using ProjectName.Application.SeedWork.Queries;

namespace ProjectName.Application.SeedWork
{
    public interface IExecutor
    {
        Task<TResult> ExecuteCommandAsync<TResult>(ICommand<TResult> command);

        Task ExecuteCommandAsync(ICommand command);

        Task<TResult> ExecuteQueryAsync<TResult>(IQuery<TResult> query);
    }
}
