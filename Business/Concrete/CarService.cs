using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        IColorService _colorService;
        IBrandService _brandService;

        public CarService(ICarDal carRentDal, IColorService colorService, IBrandService brandService)
        {
            _carDal = carRentDal;
            _colorService = colorService;
            _brandService = brandService;
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

        [ValidationAspect(typeof(CarValidator))]
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

        [ValidationAspect(typeof(CarValidator))]
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
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            var result = _colorService.GetByName(colorName);
            List<CarDetailDto> carlist = new List<CarDetailDto>();
            foreach (Color color in result.Data)
            {
                carlist.AddRange(_carDal.GetCarDetails(c => c.ColorId == color.Id));
            }
            return new SuccessDataResult<List<CarDetailDto>>(carlist);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            var result = _brandService.GetByName(brandName);
            List<CarDetailDto> carList = new List<CarDetailDto>();
            foreach (Brand brand in result.Data)
            {
                carList.AddRange(_carDal.GetCarDetails(c => c.BrandID == brand.Id));
            }
            return new SuccessDataResult<List<CarDetailDto>>(carList);
        }
    }
}
