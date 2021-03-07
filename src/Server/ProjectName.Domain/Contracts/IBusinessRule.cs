namespace ProjectName.Domain.Contracts
{
    public interface IBusinessRule
    {
        string Message { get; }

        bool IsBroken();
    }
}
