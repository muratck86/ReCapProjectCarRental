using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public bool Metalic { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public string FuelType { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
    }
}
