using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntitFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentCompanyContext>, IBrandDal
    {
    }
}
