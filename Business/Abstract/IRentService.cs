using Core.Utilities.Results;
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
        IDataResult<List<RentDetailDto>> GetAllNotReturned(DateTime lateReturnFromDate);
        IDataResult<List<RentDetailDto>> GetRentDetails(Expression<Func<Rent, bool>> filter = null);
        IDataResult<List<Rent>> GetAllCurrentRents();
        IDataResult<List<Rent>> GetAllAvailibleCars();
    }
}
