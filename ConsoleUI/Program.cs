using Business;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    public class Program
    {
        static BrandService brandService;
        static CarService carService;
        static RentService rentService;
        static ColorService colorService;
        static void Main(string[] args)
        {
            carService = new CarService(new InMemoryCarDal());
            rentService = new RentService(new InMemoryRentDal());
            brandService = new BrandService(new InMemoryBrandDal());
            colorService = new ColorService(new InMemoryColorDal());


            PrintList(carService.GetAll());
            PrintList(rentService.GetAll());
            PrintList(brandService.GetAll());
            PrintList(colorService.GetAll());

            carService.Add(new Car
            {
                Id = 15,
                BrandID = 4,
                BodyType = Body.Sedan,
                ColorId = 3,
                DailyPrice = 250,
                FuelType = Fuel.Diesel,
                GearType = Gear.Auto,
                ModelYear = 2019,
                WheelDrive = Wheel.fourwd
            });

            PrintList(new List<Car> { carService.GetById(15) });

        }

        public static void PrintList(List<Car> cars)
        {
            Console.WriteLine("\n...............Cars found in the list................");
            string carInfo = "";
            Brand brand;
            foreach (var t in cars)
            {
                brand = brandService.GetById(t.BrandID);
                carInfo = t.Id + " " + brand.Name + " " + brand.Model + " " + 
                    colorService.GetById(t.ColorId).Name+ " " + t.FuelType + " " + t.GearType + "gear Price: " + t.DailyPrice + "TL/day";
                Console.WriteLine(carInfo);
            }
        }

        public static void PrintList(List<Brand> brands)
        {
            Console.WriteLine("\n...............Brand and model names found in the list................");
            foreach (var b in brands) Console.WriteLine(b.Name + " " + b.Model);
        }

        public static void PrintList(List<Color> colors)
        {
            Console.WriteLine("\n...............Availible colors in the list................");
            foreach (var color in colors) Console.WriteLine(color.Name);
        }

        public static void PrintList(List<Rent> rents)
        {
            Console.WriteLine("\n...............Car rent information found in the list................");
            string rentInfo = "";
            Brand brand;
            Car car;
            foreach (var rent in rents)
            {
                car = carService.GetById(rent.CarId);
                brand = brandService.GetById(car.BrandID);
                rentInfo = rent.Id + " " + brand.Name + " " + brand.Model + 
                    " Rent date: " + rent.RentDate + " Return date " + 
                    (rent.ActualReturnDate == null ? rent.EstimatedReturnDate : rent.ActualReturnDate).Date;
                Console.WriteLine(rentInfo);
            }
        }

    }
}
