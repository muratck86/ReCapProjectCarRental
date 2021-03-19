using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IVehicleRentalBaseService<Car>
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
    }
}
