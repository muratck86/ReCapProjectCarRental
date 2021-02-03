using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarService : IVehicleRentalService<Car>
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
            return _carDal.GetById (id);
        }
        public bool Remove(Car car)
        {
            return _carDal.Remove(car);
        }

        public void Add(Car car)
        {
            _carDal.Add(car);
        }

        public List<Car> GetAvailibleCars()
        {
            return _carDal.GetAvailibleCars();
        }

        public bool IsAvailible(Car car)
        {
            return _carDal.IsAvailible(car);
        }

        public List<Car> GetByProp(Color color)
        {
            return _carDal.GetByProp(color);
        }

        public List<Car> GetByProp(string partOfBrandName)
        {
            return _carDal.GetByProp(partOfBrandName);
        }

        public List<Car> GetByProp(int modelYear)
        {
            return _carDal.GetByProp(modelYear);
        }

    }
}
