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
            _legalCustomerDal.Add(legalCustomer);
        }

        public List<LegalCustomer> GetAll()
        {
            return _legalCustomerDal.GetAll();
        }
        public LegalCustomer Get(LegalCustomer legalCustomer)
        {
            return GetById(legalCustomer.Id);
        }
        public LegalCustomer GetById(int id)
        {
            return _legalCustomerDal.Get(l => l.Id == id);
        }

        public void Remove(LegalCustomer legalCustomer)
        {
            _legalCustomerDal.Delete(legalCustomer);
        }

        public void Update(LegalCustomer legalCustomer)
        {
            _legalCustomerDal.Update(legalCustomer);
        }
    }
}
