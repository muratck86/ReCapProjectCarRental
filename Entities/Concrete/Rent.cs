using Core.Entities;
using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

/*
 * This class holds the information about every rent event,
 * when a vehicle is first rented, RentDate is the start date of the rental.
 * Usually there is an EstimatedReturnDate when a customer provides this information and
 * the ActualReturnDate will be null until a car is delivered back to the company.
 */
namespace Entities.Concrete
{
    public class Rent : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? EstReturnDate { get; set; }
        public DateTime? ActReturnDate { get; set; }

    }
}
