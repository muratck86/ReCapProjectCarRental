using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class RealCustomer : AbstractCustomer
    {
        public string NationalIdNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
