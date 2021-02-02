using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorService : IVehicleRentalService<Color>
    {
        ICarRentalDal<Color> _colors;
        public ColorService(ICarRentalDal<Color> carRentalDal)
        {
            _colors = carRentalDal;
        }
        public List<Color> GetAll()
        {
            return _colors.GetAll();
        }

        public Color GetById(int id)
        {
            return _colors.GetById(id);
        }
        public bool Remove(Color color)
        {
            return _colors.Remove(color);
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }
    }
}
