using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfRentDal : EfEntityRepositoryBase<Rent, CarRentCompanyContext>, IRentDal
    {
        public List<RentDetailDto> GetRentDetailsOfReal(Expression<Func<Rent, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var resultList = from r in filter == null ?
                    context.Set<Rent>() : context.Set<Rent>().Where(filter)
                                 join rc in context.RealCustomers on r.CustomerId equals rc.Id
                                 join c in context.Cars on r.CarId equals c.Id
                                 join b in context.Brands on c.BrandID equals b.Id
                                 select new RentDetailDto
                                 {
                                     Id = r.Id,
                                     CarDetails = " " + c.Plate + " " + b.Name + " " + b.Name,
                                     Customer = rc.FirstName + " " + rc.LastName,

                                     RentDate = r.RentDate,
                                     EstReturnDate = r.EstReturnDate,
                                     ActReturnDate = r.ActReturnDate
                                 };
                return resultList.ToList();
            }
        }

        public List<RentDetailDto> GetRentDetailsOfLegal(Expression<Func<Rent, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var resultList = from r in filter == null ?
                    context.Set<Rent>() : context.Set<Rent>().Where(filter)
                                 join lc in context.LegalCustomers on r.CustomerId equals lc.Id
                                 join c in context.Cars on r.CarId equals c.Id
                                 join b in context.Brands on c.BrandID equals b.Id
                                 select new RentDetailDto
                                 {
                                     Id = r.Id,
                                     CarDetails = " " + c.Plate + " " + b.Name + " " + b.Name,
                                     Customer = lc.CompanyName,
                                     RentDate = r.RentDate,
                                     EstReturnDate = r.EstReturnDate,
                                     ActReturnDate = r.ActReturnDate
                                 };
                return resultList.ToList();
            }
        }

        public List<RentDetailDto> GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var real = GetRentDetailsOfReal(filter);
                var legal = GetRentDetailsOfLegal(filter);

                foreach (var item in legal)
                {
                    real.Add(item);
                }
                return real;
            }
        }
    }
}
