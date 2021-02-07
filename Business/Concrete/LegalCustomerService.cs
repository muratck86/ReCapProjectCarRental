using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class LegalCustomerService : ILegalCustomerService
    {
        ILegalCustomerDal _legalCustomerDal;

        public LegalCustomerService(ILegalCustomerDal legalCustomerDal)
        {
            _legalCustomerDal = legalCustomerDal;
        }

        public void Add(LegalCustomer legalCustomer)
        {
            throw new NotImplementedException();
        }

        public List<LegalCustomer> GetAll()
        {
            return _legalCustomerDal.GetAll();
        }

        public LegalCustomer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(LegalCustomer legalCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
