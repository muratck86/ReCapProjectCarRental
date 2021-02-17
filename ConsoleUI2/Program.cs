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
            ICustomerService customerService =
                new CustomerService(new EfCustomerDal());
            IUserService userService = new UserService(new EfUserDal());

            //var brands = new EfBrandDal();
            //Console.WriteLine(brands.Get(p => p.Id == 325) == null ? "No record" : "Found");

            //RentDetailsDtoTest(rentService);
            //CarDetailsDtoTest(carService);            //OK.
            //BrandServiceTest(brandService);           //OK.
            //CarServiceTest(carService);               //OK.
            //ColorServiceTest(colorService);           //OK.
            //CustomerServiceTest(customerService);     //OK.
            //RentServiceTest(rentService);             //OK.
            //UserListTest(userService);                //OK.
            //AddNewUserTest(userService);              //OK.
            //AddNewCustomer(customerService);
            //AddNewRentTest(rentService);                //OK.
            DeleteRentTest(rentService);
            //RemoveUserTest(userService);



        }
        
        static User exUser = new User()
        {
            FirstName = "Abbas",
            LastName = "Sağlam",
            Email = "abbasaga@gmail.com",
            Password = "abbasaga123"
        };
        static Rent exRent = new Rent()
        {
            CarId = 106,
            RentDate = new DateTime(2025, 12, 16),
            CustomerId = 409,
            EstReturnDate = new DateTime(2025, 1, 25)
        };

        private static void AddNewUserTest(IUserService userService)
        {
            Console.WriteLine(userService.Add(exUser).Message);
        }

        private static void RemoveUserTest(IUserService userService)
        {
            Console.WriteLine(userService.Remove(exUser).Message);
        }
        private static void UserListTest(IUserService userService)
        {
            Console.WriteLine("\nUsers int the database.........");
            int counter = 0;
            foreach (var user in userService.GetAll().Data)
            {
                Console.WriteLine(++counter + "\t" + user.Id + " " + user.FirstName + " " + user.LastName);
            }
            if (counter != 21)
                Console.WriteLine("---------------------ERROR------Must be 21 cars in the list-------------");
        }

        private static void RentDetailsDtoTest(IRentService rentService)
        {
            var rentDetails = rentService.GetAllNotReturned(DateTime.Now);
            foreach (var rent in rentDetails.Data)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", rent.Id, rent.UserName, rent.CarDetails,
                                    rent.RentDate, rent.EstReturnDate, rent.ActReturnDate);
            }
            Console.WriteLine("Total of {0} cars in the list", rentDetails.Data.Count);
        }

        private static void CarDetailsDtoTest(ICarService carService)
        {
            //GetCarDetails...
            Console.WriteLine("\nCars (CarDetailDto) In the database");
            int counter = 0;
            foreach (var car in carService.GetCarDetails().Data)
            {
                Console.WriteLine(++counter + "\t{0} {1} {2} {3} {4} {5} {6}--------{7}TL/day",
                    car.Id,
                    car.BrandName,
                    car.ModelName,
                    car.FuelType,
                    car.ColorName,
                    car.Metalic == true ? "Metalic" : "",
                    car.ModelYear,
                    car.DailyPrice);
            }
            if (counter != 16)
                Console.WriteLine("---------------------ERROR------Must be 16 cars in the list-------------");
        }

        private static void AddNewRentTest(IRentService rentService)
        {
            //Add new rent......
            var result = rentService.Add(exRent);
            Console.WriteLine(result.Message);
        }
        private static void DeleteRentTest(IRentService rentService)
        {
            Console.WriteLine(rentService.Remove(exRent).Message);
        }

        private static void RentServiceTest(IRentService rentService)
        {
            //Rents
            int counter = 0;
            Console.WriteLine("\nRent entries............................");
            foreach (var rent in rentService.GetAll().Data)
            {
                Console.WriteLine(++counter + "\t" + rent.CarId + " " + rent.CustomerId + " " +
                    rent.RentDate + " " + rent.EstReturnDate + " " + rent.ActReturnDate);
            }
            if (counter != 23)
                Console.WriteLine("---------------------ERROR------Must be 23 rents in the list-------------");
        }

        private static void CustomerServiceTest(ICustomerService customerService)
        {
            //Customers
            int counter = 0;
            Console.WriteLine("Customer List.............................");
            foreach (var customer in customerService.GetAll().Data)
            {
                Console.WriteLine(++counter + "\t" + customer.Id + " " + customer.CompanyName);
            }
            if (counter != 5)
                Console.WriteLine("---------------------ERROR------Must be 5 customers in the list-------------");
        }

        private static void ColorServiceTest(IColorService colorService)
        {
            //Colors
            int counter = 0;
            Console.WriteLine("Availible colors........................");
            foreach (var color in colorService.GetAll().Data)
            {
                Console.WriteLine(++counter + "\t" + color.Id + " " + color.Name + " " + (color.Metalic == true ? "Metalic" : ""));
            }
            if (counter != 7)
                Console.WriteLine("---------------------ERROR------Must be 7 colors in the list-------------");
        }

        private static void CarServiceTest(ICarService carService)
        {
            //Cars
            int counter = 0;
            Console.WriteLine("Car Inventory.............");
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine(++counter + "\t" + car.Id + " " + car.BodyType);
            }
            if (counter != 16)
                Console.WriteLine("---------------------ERROR------Must be 16 cars in the list-------------");
        }

        private static void BrandServiceTest(IBrandService brandService)
        {
            int counter = 0;
            //Brands
            Console.WriteLine("\nCar Brands In the database");
            var brands = brandService.GetAll();
            Console.WriteLine(brands.Message);
            foreach (var brand in brands.Data)
            {
                Console.WriteLine(++counter + "\t" + brand.Name + " " + brand.Model);
            }

            if(counter != 12)
                Console.WriteLine("---------------------ERROR------Must be 12 brands in the list-------------");
        }
    }
}
