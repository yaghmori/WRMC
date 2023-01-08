using WRMC.Core.Shared.Validators;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Validators
{
    public class RoleRemoteValidator : IRoleValidator  
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleRemoteValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<bool> CheckIfUniqueRoleName(string name, CancellationToken token)
        {
            return await _unitOfWork.Roles.AnyAsync(x => x.Name.Equals(name));
        }
    }

}
