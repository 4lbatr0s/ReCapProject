using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{

    public interface ICarDal:IEntityRepository<Car> //an interface is not public by default by it's functions are.
     {
        //this is where we do CRUD+ operations on the database. 

    }
}
