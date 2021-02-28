using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {
                var result = from ca in context.Cars
                             join co in context.Colors on ca.ColorId equals co.Id
                             join b in context.Brands on ca.BrandID equals b.Id
                             select new CarDetailDto
                             {
                                 Id = ca.Id,
                                 ColorName = co.Name,
                                 Metalic = co.Metalic,
                                 BrandName = b.Name,
                                 ModelName = b.Model,
                                 FuelType = ca.FuelType,
                                 ModelYear = ca.ModelYear,
                                 DailyPrice = ca.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
