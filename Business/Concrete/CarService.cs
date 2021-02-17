using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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


        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }
        public IDataResult<Car> Get(Car car)
        {
            return GetById(car.Id);
        }
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }
        public IResult Remove(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IResult Add(Car car)
        {
            if (car.DailyPrice <= 0)
                return new ErrorResult(Messages.NoFreeCarRent);
            else if (car.BodyType.Length <= 2)
                return new ErrorResult(Messages.InvalidBodyName);
            else
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
        }
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandID == brandId));
        }
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails());
        }

    }
}
