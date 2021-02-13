using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<Brand> Get(Brand brand)
        {
            return GetById(brand.Id);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (System.DateTime.Now.Hour == 22 || System.DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (System.DateTime.Now.Hour == 22 || System.DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        public IResult Remove(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
                return new ErrorResult(Messages.ShortName);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }
    }
}
