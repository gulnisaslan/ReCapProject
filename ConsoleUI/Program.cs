using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //  InMemoryDal();
            //DailyPriceFilter();
            // AddedCar();

            //GetIdFilter();
            //CarManager carManager = new CarManager(new EfCarDal());

            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description + " " + car.DailyPrice + " " + car.BrandId);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
         



        }

        //private static void AddedCar()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    carManager.Add(new Car { BrandId = 2006, ColourId = 1003, DailyPrice = 290, Description = "Manuel Benzinli", ModelYear = 2016 });
        //}

        //private static void DailyPriceFilter()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetDailyPrice(50.200))
        //    {
        //        Console.WriteLine(car.DailyPrice);
        //    }


        //private static void InMemoryDal()
        //{
        //    CarManager carManager = new CarManager(new InMemoryCarDal());

        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine(car.Description);
        //    }
        //    Console.WriteLine("Hello World!");
        //}
        //private static void GetIdFilter()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetId(1005))
        //    {
        //        Console.WriteLine(car.Description);
        //    }
        //}
    }
}

