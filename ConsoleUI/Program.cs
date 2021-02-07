using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntitFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class Program
    {
        public static void main(string[] args)
        {
            ICarService carService = new CarService(new EfCarDal());

            IRentService rentService = new RentService(new EfRentDal());
            //var liste = rentService.GetAllNotReturned(DateTime.Now);
            foreach (var rent in rentService.GetAllNotReturned(DateTime.Now))
            {
                Console.WriteLine(rent.RentDate +" " 
                    + carService.GetById(rent.CarId).Plate + " "
                    + rent.RentDate + " " + rent.EstReturnDate);
            }
        }
    }
}
