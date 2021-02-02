using Entities.Abstract;
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
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }

        public string Description { get; set; }
        public string Model { get; set; }

        public Fuel FuelType { get; set; }
        public Body BodyType { get; set; }

        public Gear GearType { get; set; }
        public Wheel WheelDrive { get; set; }

    }

}
