using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RealCustomerService : IRealCustomerService
    {
        ICustomerDal _customerServiceDal;

        public RealCustomerService(ICustomerDal customerServiceDal)
        {
            _customerServiceDal = customerServiceDal;
        }

        public IResult Add(RealCustomer realCustomer)
        {
            _customerServiceDal.Add(realCustomer);
            return new SuccessResult();
        }

        public IDataResult<RealCustomer> Get(RealCustomer entity)
        {
            return GetById(entity.Id);
        }

        public IDataResult<List<RealCustomer>> GetAll()
        {
            return new SuccessDataResult<List<RealCustomer>>(_customerServiceDal.GetAll());
        }

        public IDataResult<RealCustomer> GetById(int id)
        {
            return new SuccessDataResult<RealCustomer>(_customerServiceDal.Get(r => r.Id == id));
        }

        public IResult Remove(RealCustomer realCustomer)
        {
            _customerServiceDal.Delete(realCustomer);
            return new SuccessResult();

        }

        public IResult Update(RealCustomer realCustomer)
        {
            _customerServiceDal.Update(realCustomer);
            return new SuccessResult();

        }
    }
}
