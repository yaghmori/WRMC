namespace WRMC.Core.Shared.Validators
{
    public interface ITenantValidator
    {
        Task<bool> CheckIfUniqueTenantName(string name, CancellationToken token);
    }
}
