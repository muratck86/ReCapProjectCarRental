using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfLegalCustomerDal : ILegalCustomerDal
    {
        public void Add(LegalCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(LegalCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public LegalCustomer Get(Expression<Func<LegalCustomer, bool>> filter)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return context.Set<LegalCustomer>().SingleOrDefault(filter);
            }
        }

        public List<LegalCustomer> GetAll(Expression<Func<LegalCustomer, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return filter == null 
                    ? context.Set<LegalCustomer>().ToList()
                    : context.Set<LegalCustomer>().Where(filter).ToList();
            }
        }

        public void Update(LegalCustomer customer)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(customer).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
