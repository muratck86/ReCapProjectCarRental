using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarService : ICarService
    {
        ICarDal _carDal;

        public CarService(ICarDal carRentDal)
        {
            _carDal = carRentDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public Car Get(Car car)
        {
            return _carDal.Get(c => c.Id == car.Id);
        }
        public Car GetById(int id)
        {
            return _carDal.Get (c => c.Id == id);
        }
        public void Remove(Car car)
        {
            _carDal.Delete(car);
        }

        public void Add(Car car)
        {
            if(car.DailyPrice > 0 && car.BodyType.Length >= 2)
                _carDal.Add(car);
            else
                Console.WriteLine("invalid property value...");
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }
        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandID == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<CarDetailDTO> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
