using Business.Abstract;
using Core.Utilities.Results;
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

        public IResult Add(LegalCustomer legalCustomer)
        {
            _legalCustomerDal.Add(legalCustomer);
            return new SuccessResult();
        }

        public IDataResult<List<LegalCustomer>> GetAll()
        {
            return new SuccessDataResult<List<LegalCustomer>>(_legalCustomerDal.GetAll());
        }
        public IDataResult<LegalCustomer> Get(LegalCustomer legalCustomer)
        {
            return GetById(legalCustomer.Id);
        }
        public IDataResult<LegalCustomer> GetById(int id)
        {
            return new SuccessDataResult<LegalCustomer>(_legalCustomerDal.Get(l => l.Id == id));
        }

        public IResult Remove(LegalCustomer legalCustomer)
        {
            _legalCustomerDal.Delete(legalCustomer);
            return new SuccessResult();

        }

        public IResult Update(LegalCustomer legalCustomer)
        {
            _legalCustomerDal.Update(legalCustomer);
            return new SuccessResult();

        }
    }
}
