using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string FuelType { get; set; }
        public string GearType { get; set; }
        public string WheelDrive { get; set; }
        public string BodyType { get; set; }
        public string Plate { get; set; }
        public string ColorName { get; set; }
        public bool Metalic { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Descript { get; set; }

    }

}
