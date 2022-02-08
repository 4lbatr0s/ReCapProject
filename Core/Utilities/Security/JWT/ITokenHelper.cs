using Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //return type AccessToken, includes: Token itself, Expiration date.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); //for what user with what operation claims, I'll be creating this token.
    }
}
