using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    /*
     * This class keeps the fields of the car object which also can be an SUV or mini van also
     * The fields FuelType, BodyType, GearType and WheelDrive are defined as enums
     */
    public class Car : IEntity
    {
        public int Id { get; set; }
        public int BrandID { get; set; }
        public string Plate { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descript { get; set; }

        //public Fuel FuelType { get; set; }
        //public Body BodyType { get; set; }

        //public Gear GearType { get; set; }
        //public Wheel WheelDrive { get; set; }
        public string FuelType { get; set; }
        public string BodyType { get; set; }
        public string GearType { get; set; }
        public string WheelDrive { get; set; }

    }

}
