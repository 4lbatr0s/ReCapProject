using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities;
using System;

namespace Console_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var allCars = carManager.GetAll();
            foreach(var car in allCars)
            {
                Console.WriteLine(car.Description);
            }
            carManager.Add(new Car { BrandId = 5, ColorId = "#FAB", Id = 8, Description = "Toyota Supra", DailyPrice = 2329452, ModelYear = 2021 });
            Console.WriteLine(carManager.GetById(8).Description);
        }
    }
}
