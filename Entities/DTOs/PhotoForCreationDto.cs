using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PhotoForCreationDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile CarImage { get; set; }
    }
}
