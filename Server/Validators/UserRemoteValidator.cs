using WRMC.Core.Shared.Validators;
using WRMC.Infrastructure.UnitOfWork;

namespace WRMC.Server.Validators
{
    public class UserRemoteValidator : IUserValidator
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRemoteValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<bool> CheckIfUniqueEmail(string email, CancellationToken token)
        {
            return  await _unitOfWork.Users.AnyAsync(x=>x.Email.Equals(email));

        }
    }

}
