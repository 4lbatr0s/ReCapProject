using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = "#FFF", ModelYear = 1992, Description = "Wolkswagen Transporter", DailyPrice = 123245},
                new Car {Id = 2, BrandId = 1, ColorId = "#AFF", ModelYear = 1993, Description = "Renault Clio", DailyPrice = 133245},
                new Car {Id = 3, BrandId = 2, ColorId = "#FBF", ModelYear = 1994, Description = "Citroen C4", DailyPrice = 143245},
                new Car {Id = 4, BrandId = 2, ColorId = "#FFS", ModelYear = 1995, Description = "Mitsibushi Evo", DailyPrice = 223245},
                new Car {Id = 5, BrandId = 3, ColorId = "#FF0", ModelYear = 1996, Description = "Dacia Duster", DailyPrice = 323245},
                new Car {Id = 5, BrandId = 3, ColorId = "#F0F", ModelYear = 1997, Description = "Mercedes C108", DailyPrice = 423245},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id); //finds from id then changes values except the Id.
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
