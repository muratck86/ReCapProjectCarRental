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
    public class EfColorDal : IColorDal
    {
        public void Add(Color color)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(color).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color color)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                context.Entry(color).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                return filter == null ?
                    context.Set<Color>().ToList() : context.Set<Color>().Where(filter).ToList();
            }
        }

        public void Update(Color color)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var oldData = context.Entry(color);
                oldData.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
