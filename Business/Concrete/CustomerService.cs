using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerService(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult();
        }

        public IDataResult<Customer> Get(Customer entity)
        {
            return GetById(entity.Id);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            var customer = _customerDal.Get(b => b.Id == id);
            if (customer == null)
                return new ErrorDataResult<Customer>(Messages.NoSuchCustomer);
            return new SuccessDataResult<Customer>(_customerDal.Get(r => r.Id == id));
        }

        public IResult Remove(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();

        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();

        }
    }
}
