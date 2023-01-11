using WRMC.Infrastructure.Domain.Entities;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        public static List<UserAddress> UserAddress = new List<UserAddress> {
            new UserAddress { Id=Guid.NewGuid(), Type=Domain.Enums.AddressTypeEnum.Home, Address="SGT Miranda McAnderson\r\n6543 N 9th Street\r\nAPO, AA 33608-1234", RegionId=null,ZipCode="251742310", IsDefault=true ,Order=1 },//25527
            new UserAddress { Id=Guid.NewGuid(), Type=Domain.Enums.AddressTypeEnum.Work, Address="Suzy Queue\r\n4455 Landing Lange, APT 4\r\nLouisville, KY 40018-1234", RegionId=null,ZipCode="241542123", IsDefault=false,Order=2 },//18793
            new UserAddress { Id=Guid.NewGuid(), Type=Domain.Enums.AddressTypeEnum.Others, Address="Robert Robertson, 1234 NW Bobcat Lane, St. Robert, MO 65584-5678", RegionId=null,ZipCode="351745121", IsDefault=false ,Order=3 },//26340
        };
    }
}

