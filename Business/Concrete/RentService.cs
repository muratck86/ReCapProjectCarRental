using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentService : IRentService
    {
        IRentDal _rentDal;
        public RentService(IRentDal carRentDal)
        {
            _rentDal = carRentDal;
        }

        public IDataResult<List<Rent>> GetAll()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll());
        }

        public IDataResult<Rent> GetById(int id)
        {
            var rent = _rentDal.Get(b => b.Id == id);
            if (rent == null)
                return new ErrorDataResult<Rent>(Messages.NoSuchRent);
            return new SuccessDataResult<Rent>(_rentDal.Get(r => r.Id == id));
        }

        public IResult Remove(Rent rent)
        {
            try
            {
                var rentToDel = _rentDal.Get(r => r.CarId == rent.CarId &&
                    r.CustomerId == rent.CustomerId &&
                    r.RentDate == rent.RentDate && r.EstReturnDate == rent.EstReturnDate);
                _rentDal.Delete(rentToDel);
                return new SuccessResult(Messages.RentDeleted);
            } catch (Exception e)
            {
                return new ErrorResult(e.InnerException == null ? e.Message : e.InnerException.Message);
            }
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Add(Rent rent)
        {
            _rentDal.Add(rent);
            return new SuccessResult(Messages.RentAdded);
        }

        public IDataResult<List<RentDetailDto>> GetAllNotReturned(DateTime lateReturnFromDate)
        {
            //return _rentDal.GetAll(r => r.EstReturnDate < lateReturnFromDate && r.ActReturnDate == null);
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(r =>
            r.EstReturnDate < lateReturnFromDate && r.ActReturnDate == null));
        }

        public IDataResult<Rent> Get(Rent rent)
        {
            return GetById(rent.Id);
        }

        [ValidationAspect(typeof(RentValidator))]
        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(filter));
        }

        [PerformanceAspect(1)]
        public IDataResult<List<Rent>> GetAllCurrentRents()
        {
            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll(r => r.ActReturnDate == null));
        }

        public IDataResult<List<Rent>> GetAllAvailibleCars()
        {

            return new SuccessDataResult<List<Rent>>(_rentDal.GetAll(r => r.ActReturnDate != null));

        }
    }
}
