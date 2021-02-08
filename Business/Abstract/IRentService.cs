using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentService : IVehicleRentalBaseService<Rent>
    {
        List<RentDetailDto> GetAllNotReturned(DateTime lateReturnFromDate);
        List<RentDetailDto> GetRentDetails(Expression<Func<Rent, bool>> filter = null);
        List<RentDetailDto> GetRentDetailsOfLegal(Expression<Func<Rent, bool>> filter = null);
        List<RentDetailDto> GetRentDetailsOfReal(Expression<Func<Rent, bool>> filter = null);
    }
}
