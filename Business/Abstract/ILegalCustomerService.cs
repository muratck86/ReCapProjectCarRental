using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ILegalCustomerService : IVehicleRentalBaseService<LegalCustomer>
    {
        List<LegalCustomer> GetAll();

        LegalCustomer GetById(int id);
        void Remove(LegalCustomer legalCustomer);

        void Add(LegalCustomer legalCustomer);
    }
}
