using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
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
            return new SuccessDataResult < List < Rent >>(_rentDal.GetAll());
        }

        public IDataResult<Rent> GetById(int id)
        {
            return new SuccessDataResult<Rent>(_rentDal.Get(r => r.Id == id));
        }
        public IResult Remove(Rent rent)
        {
            _rentDal.Delete(rent);
            return new SuccessResult(Messages.RentDeleted);
        }

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
            return new SuccessDataResult<Rent>(_rentDal.Get(r => r.Id == rent.Id));
        }

        public IResult Update(Rent rent)
        {
            _rentDal.Update(rent);
            return new SuccessResult(Messages.RentUpdated);
        }

        public IDataResult<List<RentDetailDto>> GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetails(filter));
        }
        public IDataResult<List<RentDetailDto>> GetRentDetailsOfLegal(Expression<Func<Rent, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetailsOfLegal(filter));
        }
        public IDataResult<List<RentDetailDto>> GetRentDetailsOfReal(Expression<Func<Rent, bool>> filter = null)
        {
            return new SuccessDataResult<List<RentDetailDto>>(_rentDal.GetRentDetailsOfReal(filter));
        }
    }
}
