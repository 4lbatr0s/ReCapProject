using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encyption
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey  CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //takes SecurityKey value from appsettings, convert it to a byte array, produce a Symmetric Security Key by using byte array.
        }
    }
}
