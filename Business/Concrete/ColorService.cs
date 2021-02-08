using Business.Abstract;
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
        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }
        public Color Get(Color color)
        {
            return GetById(color.Id);
        }
        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.Id == id);
        }
        public void Remove(Color color)
        {
            _colorDal.Delete(color);
        }
        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

    }
}
