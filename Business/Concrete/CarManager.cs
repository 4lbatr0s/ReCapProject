using Business.Abstract;
using Entities;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        InMemoryCarDal _inMemoryCarDal; // this one is an instance of our Database.
        public CarManager(InMemoryCarDal inMemoryCarDal) //Dependency Injection, injection of services.
        {
            _inMemoryCarDal = inMemoryCarDal;
        }
        public void Add(Car car)
        {
            _inMemoryCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _inMemoryCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _inMemoryCarDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _inMemoryCarDal.GetById(carId);
        }

        public void Update(Car car)
        {
            _inMemoryCarDal.Update(car);
        }
    }
}
