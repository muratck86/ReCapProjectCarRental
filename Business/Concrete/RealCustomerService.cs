using Business.Abstract;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RealCustomerService : IRealCustomerService
    {
        IRealCustomerDal _customerServiceDal;

        public RealCustomerService(IRealCustomerDal customerServiceDal)
        {
            _customerServiceDal = customerServiceDal;
        }

        public void Add(RealCustomer realCustomer)
        {
            throw new NotImplementedException();
        }

        public List<RealCustomer> GetAll()
        {
            return _customerServiceDal.GetAll();
        }

        public RealCustomer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(RealCustomer realCustomer)
        {
            throw new NotImplementedException();
        }
    }
}
