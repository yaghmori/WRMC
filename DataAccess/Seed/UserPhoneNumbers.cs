using WRMC.Core.Shared.Constant;
using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        public static List<UserPhoneNumber> UserPhoneNumbers = new List<UserPhoneNumber> {
            new UserPhoneNumber { Id=Guid.NewGuid(), PhoneNumberType=Domain.Enums.PhoneNumberTypeEnum.Mobile, PhoneNumber="2345124454", Description="This is my main mobile", IsDefault=true,Order=1 },
            new UserPhoneNumber { Id=Guid.NewGuid(), PhoneNumberType=Domain.Enums.PhoneNumberTypeEnum.Fax, PhoneNumber="5234525867", Description="Bussines Fax", IsDefault=false,Order=2 },
            new UserPhoneNumber { Id=Guid.NewGuid(), PhoneNumberType=Domain.Enums.PhoneNumberTypeEnum.Emergency, PhoneNumber="8834551820", Description="Emergency Contact (my father)", IsDefault=false,Order=3 },
        };
    }
}

