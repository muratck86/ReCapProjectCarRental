using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var brand = _brandDal.Get(b => b.Id == id);
            if (brand == null)
                return new ErrorDataResult<Brand>(Messages.NoSuchBrand);
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.Id == id));
        }

        public IResult Remove(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, Messages.BrandDeleted);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, Messages.BrandUpdated);
        }

        public IDataResult<List<Brand>> GetByName(string brandName)
        {
            var brands = _brandDal.GetAll(c => c.Name == brandName);
            if (brands == null)
                return new ErrorDataResult<List<Brand>>(Messages.NoSuchBrand);
            return new SuccessDataResult<List<Brand>>(brands);
        }
    }
}
