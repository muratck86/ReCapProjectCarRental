using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService : IVehicleRentalBaseService<CarImage>
    {
        IDataResult<List<CarImage>> GetImagesByCarId(int id);
        IResult AddImage(IFormFile file, CarImage carImage);
        IResult UpdateImage(IFormFile file, CarImage carImage);
    }
}
