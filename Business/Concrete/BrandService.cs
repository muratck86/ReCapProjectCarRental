using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class BrandService : IVehicleRentalService<Brand>
    {
        ICarRentalDal<Brand> _brandDal;
        public BrandService(ICarRentalDal<Brand> carRentalDal)
        {
            _brandDal = carRentalDal;
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.GetById(id);
        }
        public bool Remove(Brand brand)
        {
            return _brandDal.Remove(brand);
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }
    }
}
