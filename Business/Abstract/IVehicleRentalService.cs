using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleRentalService<T>
    {
        List<T> GetAll();

        T GetById(int id);
        bool Remove(T t);

        void Add(T t);
    }


}
