using Business.Concrete;
using Core.Entities.Concrete;
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
            Controller2();
            
          //  CustomerAdded();
          // RentalAdded();

        }

        private static void Controller()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            //  var result = carManager.GetId(1005);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + " " + car.BrandId + " " + car.ColourId + " " + car.DailyPrice + " " + car.Description_ + " " + car.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void Controller2()
        {
            CarBrandManager carBrandManager = new CarBrandManager(new EfCarBrandDal());
            var result = carBrandManager.GetAll();
            //  var result = carManager.GetId(1005);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id+" "+car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void Controller3()
        {
            CarBrandManager carBrandManager = new CarBrandManager(new EfCarBrandDal());
            var result = carBrandManager.GetAll();
            //  var result = carManager.GetId(1005);

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

                private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(new Rental { CarId = 1002, CustomerId = 3, RentDate = new DateTime(2021, 02, 15), ReturnDate = new DateTime(2021, 02, 18) });
            rentalManager.Add(new Rental { CarId = 1003, CustomerId = 4, RentDate = new DateTime(2021, 04, 01), ReturnDate = new DateTime(2021, 05, 01) });
            rentalManager.Add(new Rental { CarId = 2, CustomerId = 1, RentDate = new DateTime(2021, 04, 01), ReturnDate = new DateTime(2021, 04, 15) });
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            customerManager.Add(new Customer { UserId = 1, CustomerName = "Gülnisa" });
            customerManager.Add(new Customer { UserId = 2, CustomerName = "Ercan" }); ;
            customerManager.Add(new Customer { UserId = 4, CustomerName = "MuhammetHaşim" });
            customerManager.Add(new Customer { UserId = 3, CustomerName = "SemihSercan " });
        }
        // private static void UserAdded()
        //{
        //    UserManager userManager = new UserManager(new EfUserDal());
        //    userManager.Add(new User { FirstName = "Gülnisa", LastName = "Aslan", Email = "gulnisa@gulnisa.com", PassWord = "123456789" });
        //    userManager.Add(new User { FirstName = "Ercan", LastName = "Aslan", Email = "ercan@gulnisa.com", PassWord = "523456789" });
        //    userManager.Add(new User { FirstName = "Semih Sercan", LastName = "Aslan", Email = "semihsercan@gulnisa.com", PassWord = "123456789" });
        //    userManager.Add(new User { FirstName = "Muhammet Haşim", LastName = "Aslan", Email = "muhammet_hasim@gulnisa.com", PassWord = "123444789" });
        //    userManager.Add(new User { FirstName = "Gülten", LastName = "Aslan", Email = "gulten@gulnisa.com", PassWord = "153456789" });
        //}
    }
}
     



