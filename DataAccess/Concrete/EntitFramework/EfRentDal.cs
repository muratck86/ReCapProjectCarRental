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
        public List<RentDetailDto> GetRentDetails(Expression<Func<Rent, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var resultList = from r in filter == null ?
                                 context.Set<Rent>() : context.Set<Rent>().Where(filter)
                                 join cu in context.Users on r.CustomerId equals cu.Id
                                 join comp in context.Customers on r.CustomerId equals comp.UserId into rc
                                 from comp in rc.DefaultIfEmpty()
                                 join c in context.Cars on r.CarId equals c.Id
                                 join b in context.Brands on c.BrandID equals b.Id
                                 select new RentDetailDto
                                 {
                                     Id = r.Id,
                                     CarDetails = " " + c.Plate + " " + b.Name + " " + b.Model,
                                     UserName = cu.FirstName + " " + cu.LastName,
                                     CompanyName = comp.CompanyName,
                                     RentDate = r.RentDate,
                                     EstReturnDate = r.EstReturnDate,
                                     ActReturnDate = r.ActReturnDate
                                 };

                return resultList.ToList();
            }
        }

    }
}
