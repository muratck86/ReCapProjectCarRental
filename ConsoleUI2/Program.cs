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
                new RealCustomerService(new EfRealCustomerDal());
            ILegalCustomerService legalCustomerService =
                new LegalCustomerService(new EfLegalCustomerDal());

            //Not retuned overdue rent
            //var liste = rentService.GetAllNotReturned(DateTime.Now);
            //Console.WriteLine("Car Plate  Rent Date\tEstReturn Date");
            //var dt = new DateTime(2020, 12, 10);
            //foreach (var rent in rentService.GetAllNotReturned(DateTime.Now))
            //{
            //    Console.WriteLine(
            //        carService.GetById(rent.CarId).Plate + "\t"
            //        + rent.RentDate + "\t"
            //        + rent.EstReturnDate);
            //}


            //Brands
            //Console.WriteLine("Brands.....................................");
            //foreach (var brand in brandService.GetAll())
            //{
            //    Console.WriteLine(brand.Name + " "+ brand.Model);
            //}

            //Cars
            //Console.WriteLine("Car Inventory.....................................");
            //foreach (var car in carService.GetAll())
            //{
            //    Console.WriteLine(car.Id + " " + car.BodyType);
            //}

            //Colors
            //Console.WriteLine("Availible colors.....................................");
            //foreach (var color in colorService.GetAll())
            //{
            //    Console.WriteLine(color.Id + " " + color.Name +" " + (color.Metalic == true ? "Metalic" : ""));
            //}

            //Customers
            //Console.WriteLine("Customer List.....................................");
            //foreach (var customer in realCustomerService.GetAll())
            //{
            //    Console.WriteLine(customer.Id + " " + customer.FirstName + " " + customer.LastName);
            //}

            //foreach (var customer in legalCustomerService.GetAll())
            //{
            //    Console.WriteLine(customer.Id + " " + customer.CompanyName);
            //}

            //Rents
            //Console.WriteLine("Rent entries.....................................");
            //Console.WriteLine(rentService.GetAll().Count);
            //foreach (var rent in rentService.GetAll())
            //{
            //    Console.WriteLine(rent.CarId + " " + rent.CustomerId + " " +
            //        rent.RentDate + " " + rent.EstReturnDate + " " + rent.ActReturnDate);
            //}

            rentService.Add(new Rent()
            {
                CarId = 106,
                RentDate = new DateTime(2020, 12, 16),
                CustomerId = 109,
                EstReturnDate = new DateTime(202, 1, 25)
            });



        }
    }
}
