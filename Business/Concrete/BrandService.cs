using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandService : IBrandService
    {
        IBrandDal _brandDal;
        public BrandService(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public Brand Get(Brand brand)
        {
            return _brandDal.Get(b => b.Id == brand.Id);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(p => p.Id == id);
        }
        public void Remove(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
