using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : ICarRentalDal<Color>
    {
        List<Color> _colors;
        public InMemoryColorDal()
        {
            _colors = new List<Color>
            {
                new Color { Id = 1, IsMetalic = false, Name = "White"},
                new Color { Id = 2, IsMetalic = false, Name = "Grey"},
                new Color { Id = 3, IsMetalic = true, Name = "Grey"},
                new Color { Id = 4, IsMetalic = true, Name = "Black"}
            };
        }

        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int id)
        {
            return _colors.SingleOrDefault(r => r.Id == id);
        }

        public bool Remove(Color color)
        {
            return _colors.Remove(color);
        }

        public bool Update(Color color)
        {
            Color colorToUpdate = GetById(color.Id);
            if (colorToUpdate != null)
            {
                colorToUpdate.Id = color.Id;
                colorToUpdate.Name = color.Name;
                colorToUpdate.IsMetalic = color.IsMetalic;
                colorToUpdate.RGBValue = color.RGBValue;
                return true;
            }
            else return false;
        }

    }
}
