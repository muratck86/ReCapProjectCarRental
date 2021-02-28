using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile File { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }
    }
}
