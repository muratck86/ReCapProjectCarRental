using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarRentalDal<Car>
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandID = 1, ColorId = 1, BodyType = Body.SUV, DailyPrice = 350, FuelType = Fuel.Diesel,
                    GearType = Gear.Auto, ModelYear = 2019, WheelDrive = Wheel.fourwd },
                new Car { Id = 2, BrandID = 1, ColorId = 2, BodyType = Body.Sedan, DailyPrice = 180, FuelType = Fuel.Gas,
                    GearType = Gear.Manual, ModelYear = 2020, WheelDrive = Wheel.frontwd },
                new Car { Id = 3, BrandID = 2, ColorId = 1, BodyType = Body.HB, DailyPrice = 170, FuelType = Fuel.Gas,
                    GearType = Gear.Manual, ModelYear = 2021, WheelDrive = Wheel.frontwd },
                new Car { Id = 4, BrandID = 6, ColorId = 3, BodyType = Body.Sedan, DailyPrice = 850, FuelType = Fuel.Electric,
                    GearType = Gear.Auto, ModelYear = 2018, WheelDrive = Wheel.fourwd },
                new Car { Id = 5, BrandID = 7, ColorId = 4, BodyType = Body.SUV, DailyPrice = 320, FuelType = Fuel.Diesel,
                    GearType = Gear.Auto, ModelYear = 2019, WheelDrive = Wheel.fourwd },
                new Car { Id = 6, BrandID = 3, ColorId = 2, BodyType = Body.Crossover, DailyPrice = 280, FuelType = Fuel.Gas,
                    GearType = Gear.Auto, ModelYear = 2020, WheelDrive = Wheel.fourwd },
                new Car { Id = 7, BrandID = 4, ColorId = 3, BodyType = Body.Sedan, DailyPrice = 200, FuelType = Fuel.Diesel,
                    GearType = Gear.Auto, ModelYear = 2021, WheelDrive = Wheel.rearwd },
                new Car { Id = 8, BrandID = 4, ColorId = 1, BodyType = Body.Sedan, DailyPrice = 210, FuelType = Fuel.Diesel,
                    GearType = Gear.Manual, ModelYear = 2018, WheelDrive = Wheel.frontwd },
                new Car { Id = 9, BrandID = 4, ColorId = 4, BodyType = Body.HB, DailyPrice = 175, FuelType = Fuel.Gas,
                    GearType = Gear.Manual, ModelYear = 2019, WheelDrive = Wheel.frontwd },
                new Car { Id = 10, BrandID = 5, ColorId = 1, BodyType = Body.Sedan, DailyPrice = 275, FuelType = Fuel.Diesel,
                    GearType = Gear.Auto, ModelYear = 2020, WheelDrive = Wheel.rearwd }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(r => r.Id == id);
        }

        public bool Remove(Car car)
        {
            return _cars.Remove(car);
        }

        public bool Update(Car car)
        {
            Car carToUpdate = GetById(car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.BrandID = car.BrandID;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.BodyType = car.BodyType;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
                carToUpdate.FuelType = car.FuelType;
                carToUpdate.GearType = car.GearType;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.WheelDrive = car.WheelDrive;
                return true;
            }
            else return false;
        }
    }
}
