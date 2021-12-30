using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Dto;
using System;
using System.Reflection;

namespace Console_UI
{
    class Program
    {
        //testler GetAll, GetById, Insert, Update, Delete.
        static void Main(string[] args)
        {
            //CAR TESTS
            //BRAND TESTS
            //COLOR TETST
            //DTO TESTS
            //CarTestGetAll();
            //CarTestGeyByBrandId();
            //CarTestCreate();
            //CarTestUpdate();
            //CarDeleteTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name:{0}, Brand Name:{1}, Color Name:{2}, Daily Price:{3}\n", item.Description, item.BrandName, item.ColorName, item.DailyPrice);
            }

            
           

        }

        private static void CarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var opel = carManager.GetById(2);//Opel
            carManager.Delete(opel);
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description); //opel deleted.
            }
        }

        private static void CarTestUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car mitsubushi_updated = new Car
            {
                BrandId = 2,
                CarId = 10,
                ColorId = 4,
                DailyPrice = 323123,
                Description = "Mitsubushi Evo Updated",
                ModelYear = 2021

            };
            carManager.Update(mitsubushi_updated);

            var mitsubushi = carManager.GetById(10);

            foreach (PropertyInfo prop in mitsubushi.GetType().GetProperties())
            {
                Console.WriteLine($"{prop.Name}: {prop.GetValue(mitsubushi, null)}");
            }
        }

        private static void CarTestCreate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car mitsubushi = new Car
            {
                BrandId = 2,
                CarId = 10,
                ColorId = 3,
                DailyPrice = 123123,
                Description = "Mitsubushi Evo",
                ModelYear = 1998
            };
            carManager.Add(mitsubushi);
            CarTestGetAll();
        }

        private static void CarTestGeyByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(item.Description + " " + item.BrandId);
            }
        }

        private static void CarTestGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }
        }
    }
}
