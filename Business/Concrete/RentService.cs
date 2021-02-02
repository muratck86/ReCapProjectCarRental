using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentService : IVehicleRentalService<Rent>
    {
        ICarRentalDal<Rent> _rentDal;
        public RentService(ICarRentalDal<Rent> carRentDal)
        {
            _rentDal = carRentDal;
        }
        public List<Rent> GetAll()
        {
            return _rentDal.GetAll();
        }

        public Rent GetById(int id)
        {
            return _rentDal.GetById(id);
        }
        public bool Remove(Rent rent)
        {
            return _rentDal.Remove(rent);
        }

        public void Add(Rent rent)
        {
            _rentDal.Add(rent);
        }
    }
}
