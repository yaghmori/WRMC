namespace WRMC.Core.Shared.Validators
{
    public interface IRoleValidator
    {
        Task<bool> CheckIfUniqueRoleName(string name, CancellationToken token);
    }
}
