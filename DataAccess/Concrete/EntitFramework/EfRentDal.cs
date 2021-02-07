using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfRentDal : IRentDal
    {
        public void Add(Rent rent)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(rent).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rent rent)
        {
            using (CarRentCompanyContext context  = new CarRentCompanyContext())
            {
                context.Entry(rent).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Rent Get(Expression<Func<Rent, bool>> filter)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return context.Set<Rent>().SingleOrDefault(filter);
            }
        }

        public List<Rent> GetAll(Expression<Func<Rent, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return filter == null ?
                    context.Set<Rent>().ToList() : context.Set<Rent>().Where(filter).ToList();
            }
        }

        public void Update(Rent rent)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(rent).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
