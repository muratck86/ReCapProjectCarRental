using Core.Entities;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleRentalBaseService<T> where T: class, IEntity, new()
    {
        List<T> GetAll();
        T Get(T entity);
        T GetById(int id);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);

    }


}
