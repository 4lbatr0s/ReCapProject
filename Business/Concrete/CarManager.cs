using Business.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            try
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    _carDal.Add(car);
                }
                else
                {
                    Console.WriteLine("One or more conditions don't match, try again with correct values.");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }


        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            //here, we create our filters to send EfCarDal functions, hence to the IEntityRepository Generic Repository Pattern.
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(string colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }

    public class BrandManager:IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand Brand)
        {
            throw new NotImplementedException();
        }

        public void Delete(Brand Brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            throw new NotImplementedException();
        }

        public Brand GetByCountry(string countrName)
        {
            throw new NotImplementedException();
        }

        public Brand GetById(int BrandId)
        {
            throw new NotImplementedException();
        }

        public void Update(Brand Brand)
        {
            throw new NotImplementedException();
        }
    }
}
