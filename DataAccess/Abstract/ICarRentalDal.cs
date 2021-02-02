using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarRentalDal<T>
    {
        List<T> GetAll();
        T GetById(int Id);

        void Add(T t);

        bool Remove(T t);

        bool Update(T t);
    }
}
