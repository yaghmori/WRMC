using System.Security.Claims;
using System.Text.Json;
using WRMC.Core.Shared.Constants;

namespace WRMC.Core.Shared.Helpers
{
    public static class JwtParser
    {

        private static byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        public static IEnumerable<Claim> GetClaimsFromJwt(string jwt)
        {
            var claims = new List<Claim>();
            var payload = jwt.Split('.')[1];
            var jsonBytes = ParseBase64WithoutPadding(payload);
            var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes);

            if (keyValuePairs != null)
            {                
                //Roles
                keyValuePairs.TryGetValue(AppClaimTypes.Role, out var roles);
                if (roles != null)
                {
                    if (roles.ToString().Trim().StartsWith("["))
                    {
                        var parsedRoles = JsonSerializer.Deserialize<string[]>(roles.ToString());

                        claims.AddRange(parsedRoles.Select(role => new Claim(AppClaimTypes.Role, role)));
                    }
                    else
                    {
                        claims.Add(new Claim(AppClaimTypes.Role, roles.ToString()));
                    }

                    keyValuePairs.Remove(AppClaimTypes.Role);
                }

                //Permissions
                keyValuePairs.TryGetValue(AppClaimTypes.Permission, out var permissions);
                if (permissions != null)
                {
                    if (permissions.ToString().Trim().StartsWith("["))
                    {
                        var parsedPermissions = JsonSerializer.Deserialize<string[]>(permissions.ToString());
                        claims.AddRange(parsedPermissions.Select(permission => new Claim(AppClaimTypes.Permission, permission)));
                    }
                    else
                    {
                        claims.Add(new Claim(AppClaimTypes.Permission, permissions.ToString()));
                    }
                    keyValuePairs.Remove(AppClaimTypes.Permission);
                }

                //Tenants
                keyValuePairs.TryGetValue(AppClaimTypes.Tenant, out var tenants);
                if (tenants != null)
                {
                    if (tenants.ToString().Trim().StartsWith("["))
                    {
                        var parsedtenants = JsonSerializer.Deserialize<string[]>(tenants.ToString());
                        claims.AddRange(parsedtenants.Select(tenant => new Claim(AppClaimTypes.Tenant, tenant)));
                    }
                    else
                    {
                        claims.Add(new Claim(AppClaimTypes.Tenant, tenants.ToString()));
                    }
                    keyValuePairs.Remove(AppClaimTypes.Tenant);
                }


                claims.AddRange(keyValuePairs.Select(kvp => new Claim(kvp.Key, kvp.Value.ToString())));
            }
            return claims;
        }


    }
}

