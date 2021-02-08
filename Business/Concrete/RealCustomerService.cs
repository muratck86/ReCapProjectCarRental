using Business.Abstract;
using DataAccess.Abstract;
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
            _customerServiceDal.Add(realCustomer);
        }

        public RealCustomer Get(RealCustomer entity)
        {
            throw new NotImplementedException();
        }

        public List<RealCustomer> GetAll()
        {
            return _customerServiceDal.GetAll();
        }

        public RealCustomer GetById(int id)
        {
            return _customerServiceDal.Get(r => r.Id == id);
        }

        public void Remove(RealCustomer realCustomer)
        {
            _customerServiceDal.Delete(realCustomer);
        }

        public void Update(RealCustomer realCustomer)
        {
            _customerServiceDal.Update(realCustomer);
        }
    }
}
