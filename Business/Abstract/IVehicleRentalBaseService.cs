using Core.Entities;
using Core.Utilities.Results;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleRentalBaseService<T> where T: class, IEntity, new()
    {
        IDataResult<List<T>> GetAll();
        IDataResult<T> Get(T entity);
        IDataResult<T> GetById(int id);
        IResult Add(T entity);
        IResult Remove(T entity);
        IResult Update(T entity);

    }


}
