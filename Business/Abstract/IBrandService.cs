using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService : IVehicleRentalBaseService<Brand>
    {
        List<Brand> GetAll();

        Brand GetById(int id);
        void Remove(Brand brand);

        void Add(Brand brand);
    }
}
