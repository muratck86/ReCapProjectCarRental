using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : ICarRentalDal<Car>
    {
        List<Car> GetAvailibleCars();


        /*
         * First, check if the given car is in the cars inventory.
         * Check if this car exists in the rent records and  if so, then check if these rent records contain an ActualReturnDate */
        bool IsAvailible(Car car);

        /* Search a car by properties */
        List<Car> GetByProp(Color color);
        List<Car> GetByProp(int modelYear);
        List<Car> GetByProp(string subStrOfBrand);
    }
}
