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
        ICarRentalDal<Car> _carDal;

        public CarService(ICarRentalDal<Car> carRentDal)
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

    }
}
