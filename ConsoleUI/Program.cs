using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal()); //A car manager created with a db instance.
            carManager.GetAll();
            Car toyotaSupra = new Car {BrandId = 4,ColorId="#CKC",Id = 8, Description = "Toyota Supra", ModelYear = 2018, DailyPrice = 200123};
            carManager.Add(toyotaSupra);
            carManager.GetById(8);
        }
    }
}
