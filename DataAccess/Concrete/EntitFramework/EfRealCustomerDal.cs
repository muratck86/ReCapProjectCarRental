using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfRealCustomerDal : IRealCustomerDal
    {
        public void Add(RealCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(RealCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public RealCustomer Get(Expression<Func<RealCustomer, bool>> filter)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return context.Set<RealCustomer>().SingleOrDefault(filter);
            }
        }

        public List<RealCustomer> GetAll(Expression<Func<RealCustomer, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return filter == null 
                    ? context.Set<RealCustomer>().ToList()
                    : context.Set<RealCustomer>().Where(filter).ToList();
            }
        }

        public void Update(RealCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
