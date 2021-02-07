using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public List<Rent> GetAllNotReturned(DateTime lateReturnFromDate)
        {
            return _rentDal.GetAll(r => r.EstReturnDate < lateReturnFromDate && r.ActReturnDate == null);
        }
    }
}
