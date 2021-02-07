using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
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

        public Car GetById(int id)
        {
            return _carDal.Get (p => p.Id == id);
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

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandID == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
