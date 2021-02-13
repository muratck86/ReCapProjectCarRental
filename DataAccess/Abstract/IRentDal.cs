using Core.DataAccess;
using Core.Entities;
using Entities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IRentDal : IEntityRepository<Rent> 
    {
        List<RentDetailDto> GetRentDetails(Expression<Func<Rent, bool>> filter = null);
    }
}
