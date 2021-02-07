using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRealCustomerService : IVehicleRentalBaseService<RealCustomer> 
    {
        List<RealCustomer> GetAll();

        RealCustomer GetById(int id);
        void Remove(RealCustomer realCustomer);

        void Add(RealCustomer realCustomer);
    }
}
