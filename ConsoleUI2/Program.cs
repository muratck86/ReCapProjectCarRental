using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntitFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI2
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService(new EfCarDal());
            IBrandService brandService = new BrandService(new EfBrandDal());
            IRentService rentService = new RentService(new EfRentDal());
            IColorService colorService = new ColorService(new EfColorDal());
            IRealCustomerService realCustomerService =
                new RealCustomerService(new EfCustomerDal());
            ILegalCustomerService legalCustomerService =
                new LegalCustomerService(new EfLegalCustomerDal());

            
            //RentDetailsDtoTest(rentService);
            //CarDetailsDtoTest(carService);
            //BrandServiceTest(brandService);
            //CarServiceTest(carService);
            //ColorServiceTest(colorService);
            //CustomerServiceTest(realCustomerService, legalCustomerService);
            //RentServiceTest(rentService);
            //AddNewRentTest(rentService);
            //RentServiceTest(rentService);
            //RentServiceTest(rentService);


        }

        private static void RentDetailsDtoTest(IRentService rentService)
        {
            var rentDetails = rentService.GetAllNotReturned(DateTime.Now);
            foreach (var rent in rentDetails.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", rent.Id, rent.Customer, rent.CarDetails,
                                    rent.RentDate, rent.EstReturnDate, rent.ActReturnDate);
            }
            Console.WriteLine("Total of {0} cars in the list", rentDetails.Data.Count);
        }

        private static void CarDetailsDtoTest(ICarService carService)
        {
            //GetCarDetails...
            foreach (var car in carService.GetCarDetails().Data)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}--------{7}TL/day",
                    car.Id,
                    car.BrandName,
                    car.ModelName,
                    car.FuelType,
                    car.ColorName,
                    car.Metalic == true ? "Metalic" : "",
                    car.ModelYear,
                    car.DailyPrice);
            }
            Console.WriteLine("Total of {0} cars in the list", carService.GetCarDetails().Data.Count);
        }

        private static void AddNewRentTest(IRentService rentService)
        {
            //Add new rent......
            rentService.Add(new Rent()
            {
                CarId = 106,
                RentDate = new DateTime(2020, 12, 16),
                CustomerId = 109,
                EstReturnDate = new DateTime(202, 1, 25)
            });
        }

        private static void RentServiceTest(IRentService rentService)
        {
            //Rents
            Console.WriteLine("Rent entries.....................................");
            foreach (var rent in rentService.GetAll().Data)
            {
                Console.WriteLine(rent.CarId + " " + rent.CustomerId + " " +
                    rent.RentDate + " " + rent.EstReturnDate + " " + rent.ActReturnDate);
            }
        }

        private static void CustomerServiceTest(IRealCustomerService realCustomerService, ILegalCustomerService legalCustomerService)
        {
            //Customers
            Console.WriteLine("Customer List.....................................");
            foreach (var customer in realCustomerService.GetAll().Data)
            {
                Console.WriteLine(customer.Id + " " + customer.FirstName + " " + customer.LastName);
            }
            foreach (var customer in legalCustomerService.GetAll().Data)
            {
                Console.WriteLine(customer.Id + " " + customer.CompanyName);
            }
        }

        private static void ColorServiceTest(IColorService colorService)
        {
            //Colors
            Console.WriteLine("Availible colors.....................................");
            foreach (var color in colorService.GetAll().Data)
            {
                Console.WriteLine(color.Id + " " + color.Name + " " + (color.Metalic == true ? "Metalic" : ""));
            }
        }

        private static void CarServiceTest(ICarService carService)
        {
            //Cars
            Console.WriteLine("Car Inventory.....................................");
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine(car.Id + " " + car.BodyType);
            }
        }

        private static void BrandServiceTest(IBrandService brandService)
        {
            //Brands
            Console.WriteLine("Car Brands In the database.................................");
            var brands = brandService.GetAll();
            Console.WriteLine(brands.Message);
            foreach (var brand in brands.Data)
            {
                Console.WriteLine(brand.Name + " " + brand.Model);
            }

        }
    }
}
