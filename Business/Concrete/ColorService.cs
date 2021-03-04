using Business.Abstract;
using Business.BusinessAspect.AutoFac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorService : IColorService
    {
        IColorDal _colorDal;
        public ColorService(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> Get(Color color)
        {
            return GetById(color.Id);
        }
        public IDataResult<Color> GetById(int id)
        {
            var color = _colorDal.Get(b => b.Id == id);
            if (color == null)
                return new ErrorDataResult<Color>(Messages.NoSuchColor);
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IVehicleRentalBaseService<Color>.Get")]
        public IResult Remove(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorRemoved);
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin,color.add")]
        [CacheRemoveAspect("IVehicleRentalBaseService<Color>.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);

        }

        [SecuredOperation("admin,color.add")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);

        }

    }
}
