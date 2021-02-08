using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
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
        public List<Rent> GetAll()
        {
            return _rentDal.GetAll();
        }

        public Rent GetById(int id)
        {
            return _rentDal.Get(r => r.Id == id);
        }
        public void Remove(Rent rent)
        {
            _rentDal.Delete(rent);
        }

        public void Add(Rent rent)
        {
            _rentDal.Add(rent);
        }

        public List<RentDetailDto> GetAllNotReturned(DateTime lateReturnFromDate)
        {
            //return _rentDal.GetAll(r => r.EstReturnDate < lateReturnFromDate && r.ActReturnDate == null);
            return _rentDal.GetRentDetails(r => r.EstReturnDate < lateReturnFromDate && r.ActReturnDate == null);
        }

        public Rent Get(Rent rent)
        {
            return _rentDal.Get(r => r.Id == rent.Id);
        }

        public void Update(Rent rent)
        {
            _rentDal.Update(rent);
        }

        public List<RentDetailDto> GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            return _rentDal.GetRentDetails(filter);
        }
        public List<RentDetailDto> GetRentDetailsOfLegal(Expression<Func<Rent, bool>> filter = null)
        {
            return _rentDal.GetRentDetailsOfLegal(filter);
        }
        public List<RentDetailDto> GetRentDetailsOfReal(Expression<Func<Rent, bool>> filter = null)
        {
            return _rentDal.GetRentDetailsOfReal(filter);
        }
    }
}
