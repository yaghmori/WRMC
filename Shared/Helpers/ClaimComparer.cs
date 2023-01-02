using System.Security.Claims;

namespace WRMC.Core.Shared.Helpers
{
    public class ClaimComparer : IEqualityComparer<Claim>
    {
        public bool Equals(Claim x, Claim y)
        {
            if (string.Equals(x.Type, y.Type, StringComparison.OrdinalIgnoreCase) && string.Equals(x.Value,y.Value,StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Claim obj)
        {
            
            return (obj.Type + obj.Value).GetHashCode();
        }

    }


}
