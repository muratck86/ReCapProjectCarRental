using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //public class InMemoryCarDal : ICarDal
    //{
    //    List<Car> _cars;
    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car>
    //        {
    //            new Car { Id = 1, BrandID = 1, ColorId = 1, BodyType = Body.SUV, DailyPrice = 350, FuelType = Fuel.Diesel,
    //                GearType = Gear.Auto, ModelYear = 2019, WheelDrive = Wheel.fourwd }, //Tucson --On rent
    //            new Car { Id = 2, BrandID = 1, ColorId = 2, BodyType = Body.Sedan, DailyPrice = 180, FuelType = Fuel.Gas,
    //                GearType = Gear.Manual, ModelYear = 2020, WheelDrive = Wheel.frontwd }, //Tucson
    //            new Car { Id = 3, BrandID = 2, ColorId = 1, BodyType = Body.HB, DailyPrice = 170, FuelType = Fuel.Gas,
    //                GearType = Gear.Manual, ModelYear = 2021, WheelDrive = Wheel.frontwd }, //Corolla
    //            new Car { Id = 4, BrandID = 6, ColorId = 3, BodyType = Body.Sedan, DailyPrice = 850, FuelType = Fuel.Electric,
    //                GearType = Gear.Auto, ModelYear = 2018, WheelDrive = Wheel.fourwd }, //Model 3 --On rent
    //            new Car { Id = 5, BrandID = 7, ColorId = 4, BodyType = Body.SUV, DailyPrice = 320, FuelType = Fuel.Diesel,
    //                GearType = Gear.Auto, ModelYear = 2019, WheelDrive = Wheel.fourwd }, //Raw4
    //            new Car { Id = 6, BrandID = 3, ColorId = 2, BodyType = Body.Crossover, DailyPrice = 280, FuelType = Fuel.Gas,
    //                GearType = Gear.Auto, ModelYear = 2020, WheelDrive = Wheel.fourwd }, //Megane
    //            new Car { Id = 7, BrandID = 4, ColorId = 3, BodyType = Body.Sedan, DailyPrice = 200, FuelType = Fuel.Diesel,
    //                GearType = Gear.Auto, ModelYear = 2021, WheelDrive = Wheel.rearwd }, // Focus
    //            new Car { Id = 8, BrandID = 4, ColorId = 1, BodyType = Body.Sedan, DailyPrice = 210, FuelType = Fuel.Diesel,
    //                GearType = Gear.Manual, ModelYear = 2018, WheelDrive = Wheel.frontwd }, //Focus
    //            new Car { Id = 9, BrandID = 4, ColorId = 4, BodyType = Body.HB, DailyPrice = 175, FuelType = Fuel.Gas,
    //                GearType = Gear.Manual, ModelYear = 2019, WheelDrive = Wheel.frontwd }, //Focus
    //            new Car { Id = 10, BrandID = 5, ColorId = 1, BodyType = Body.Sedan, DailyPrice = 275, FuelType = Fuel.Diesel,
    //                GearType = Gear.Auto, ModelYear = 2020, WheelDrive = Wheel.rearwd } //AMG
    //        };
    //    }
    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public Car GetById(int id)
    //    {
    //        return _cars.SingleOrDefault(r => r.Id == id);
    //    }

    //    public bool Remove(Car car)
    //    {
    //        return _cars.Remove(car);
    //    }

    //    public bool Update(Car car)
    //    {
    //        Car carToUpdate = GetById(car.Id);
    //        if (carToUpdate != null)
    //        {
    //            carToUpdate.BrandID = car.BrandID;
    //            carToUpdate.ColorId = car.ColorId;
    //            carToUpdate.BodyType = car.BodyType;
    //            carToUpdate.DailyPrice = car.DailyPrice;
    //            carToUpdate.Description = car.Description;
    //            carToUpdate.FuelType = car.FuelType;
    //            carToUpdate.GearType = car.GearType;
    //            carToUpdate.ModelYear = car.ModelYear;
    //            carToUpdate.WheelDrive = car.WheelDrive;
    //            return true;
    //        }
    //        else return false;
    //    }

    //    /*Call IsAvailible method which returns true if the given car is availible for all cars*/
    //    public List<Car> GetAvailibleCars()
    //    {
    //        return _cars.Where(p => IsAvailible(p)).ToList();
    //    }

    //    /*
    //     * First, check if the given car is in the cars inventory.
    //     * Check if this car exists in the rent records and  if so, then check if these rent records contain an ActualReturnDate */
    //    public bool IsAvailible(Car car)
    //    {
    //        List<Brand> rents = (new InMemoryRentDal()).GetAll();
    //        if (_cars.Contains(car))
    //        {
    //            var containingRents = from rent in rents
    //                                         where rent.CarId == car.Id
    //                                         select rent;
    //                return (containingRents.Count() == 0 || containingRents.Any(d => d.ActualReturnDate == null));

    //        }
    //        return false;
    //    }

    //    public List<Car> GetByProp(int modelYear)
    //    {
    //        var result = from car in _cars
    //                     where car.ModelYear == modelYear
    //                     select car;
    //        return result.ToList();
    //    }

    //    public List<Car> GetByProp(string subStrOfBrand)
    //    {
    //        var result = from car in _cars
    //                     join brand in (new InMemoryBrandDal().GetAll()) on car.BrandID equals brand.Id
    //                     where brand.Name.Contains(subStrOfBrand) || brand.Model.Contains(subStrOfBrand)
    //                     select car;
    //        return result.ToList();
    //    }

    //    public List<Car> GetByProp(Color color)
    //    {
    //        InMemoryColorDal colors = new InMemoryColorDal();
    //        var result = from car in _cars
    //                     where car.ColorId == color.Id
    //                     select car;
    //        return result.ToList();
    //    }
    //}
}
