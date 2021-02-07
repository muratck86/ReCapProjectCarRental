using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IVehicleRentalBaseService<Car>
    {
        List<Car> GetAll();

        Car GetById(int id);
        void Remove(Car car);

        void Add(Car car);

        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);

    }
}
