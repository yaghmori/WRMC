namespace WRMC.Core.Shared.Validators
{
    public interface IUserValidator
    {
        Task<bool> CheckIfUniqueEmail(string email, CancellationToken token);
    }
}
