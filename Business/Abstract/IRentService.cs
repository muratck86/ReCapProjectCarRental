using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService : IVehicleRentalBaseService<Rent>
    {
        List<Rent> GetAll();

        Rent GetById(int id);
        void Remove(Rent rent);

        void Add(Rent rent);

        List<Rent> GetAllNotReturned(DateTime lateReturnFromDate);
    }
}
