using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        public Task<List<OperationClaim>> GetClaims(User user);
    }
}
