using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities;
using System;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentCompanyContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentCompanyContext context = new CarRentCompanyContext())
            {

                var result = from ca in filter == null ? context.Cars : context.Set<Car>().Where(filter)
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
                                 BodyType = ca.BodyType,
                                 DailyPrice = ca.DailyPrice,
                                 GearType = ca.GearType,
                                 WheelDrive = ca.WheelDrive,
                                 Plate = ca.Plate,
                                 Descript = ca.Descript,
                             };
                return result.ToList();
            }
        }
    }
}
