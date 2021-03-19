using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService : IVehicleRentalBaseService<Brand>
    {
        IDataResult<List<Brand>> GetByName(string brandName);
    }
}
