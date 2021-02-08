using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentDetailDto : IDto
    {
        public int Id { get; set; }
        public string CarDetails { get; set; }
        public string Customer { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? EstReturnDate { get; set; }
        public DateTime? ActReturnDate { get; set; }
    }
}
