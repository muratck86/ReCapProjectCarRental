using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentCompanyContext>, IColorDal
    {

    }
}
