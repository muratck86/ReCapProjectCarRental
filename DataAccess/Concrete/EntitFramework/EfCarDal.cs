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
    public class EfCarDal : ICarDal
    {

        public void Add(Car car)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(car).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car car)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var toDelete = context.Entry(car);
                toDelete.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var car = context.Set<Car>().SingleOrDefault(filter);
                return car;
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return filter == null ? 
                    context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car car)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var toUpdate = context.Entry(car);
                toUpdate.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
