using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal //an interface is not public by default by it's functions are.
     {
        //this is where we do CRUD+ operations on the database. 

        List<Car> GetAll();
        Car GetById(int carId);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);


    }
}
