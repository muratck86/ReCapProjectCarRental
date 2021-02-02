using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryRentDal : ICarRentalDal<Rent>
    {
        List<Rent> _rents;
        public InMemoryRentDal()
        {
            _rents = new List<Rent>
            {
                new Rent { Id = 1, CarId = 1, RentDate = new DateTime(2020, 10, 15),
                    EstimatedReturnDate = new DateTime(2020, 12, 15), ActualReturnDate = new DateTime(2020, 12, 15)},
                new Rent { Id = 2, CarId = 2, RentDate = new DateTime(2020, 6, 5),
                    EstimatedReturnDate = new DateTime(2020, 6, 15), ActualReturnDate = new DateTime(2020, 6, 19)},
                new Rent { Id = 3, CarId = 3, RentDate = new DateTime(2020, 8, 25),
                    EstimatedReturnDate = new DateTime(2020, 10, 25), ActualReturnDate = new DateTime(2020, 10, 30)},
                new Rent { Id = 4, CarId = 4, RentDate = new DateTime(2021, 2, 1),
                    EstimatedReturnDate = new DateTime(2021, 3, 15) },
                new Rent { Id = 5, CarId = 2, RentDate = new DateTime(2021, 1, 15),
                    EstimatedReturnDate = new DateTime(2021, 2, 1), ActualReturnDate = new DateTime(2021, 2, 1)},
                new Rent { Id = 6, CarId = 5, RentDate = new DateTime(2020, 9, 17),
                    EstimatedReturnDate = new DateTime(2020, 9, 25), ActualReturnDate = new DateTime(2020, 9, 23)},
                new Rent { Id = 7, CarId = 10, RentDate = new DateTime(2020, 11, 29),
                    EstimatedReturnDate = new DateTime(2020, 12, 15), ActualReturnDate = new DateTime(2020, 12, 15)},
                new Rent { Id = 8, CarId = 7, RentDate = new DateTime(2020, 12, 26),
                    EstimatedReturnDate = new DateTime(2021, 1, 10), ActualReturnDate = new DateTime(2021, 1, 10)},
                new Rent { Id = 9, CarId = 9, RentDate = new DateTime(2020, 7, 30),
                    EstimatedReturnDate = new DateTime(2020, 9, 30), ActualReturnDate = new DateTime(2020, 9, 30)},
            };
        }
        public void Add(Rent rent)
        {
            _rents.Add(rent);
        }

        public List<Rent> GetAll()
        {
            return _rents;
        }

        public Rent GetById(int id)
        {
            return _rents.SingleOrDefault(r => r.Id == id);
        }

        public bool Remove(Rent rent)
        {
            return _rents.Remove(rent);
        }

        public bool Update(Rent rent)
        {
            Rent rentToUpdate = GetById(rent.Id);
            if (rentToUpdate != null)
            {
                rentToUpdate.CarId = rent.CarId;
                rentToUpdate.ActualReturnDate = rent.ActualReturnDate;
                rentToUpdate.EstimatedReturnDate = rent.EstimatedReturnDate;
                rentToUpdate.RentDate = rent.RentDate;
                return true;
            }
            else return false;
        }
    }
}
