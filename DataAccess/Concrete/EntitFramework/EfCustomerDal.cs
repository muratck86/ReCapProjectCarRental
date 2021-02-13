using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntitFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentCompanyContext>, ICustomerDal
    {

    }
}
