using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfLegalCustomerDal : EfEntityRepositoryBase<LegalCustomer, CarRentCompanyContext>, ILegalCustomerDal
    {

    }
}
