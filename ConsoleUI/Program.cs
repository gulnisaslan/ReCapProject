using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //  InMemoryDal();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetDailyPrice(50.200))
            {

            }
        }

        private static void InMemoryDal()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
