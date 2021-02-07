using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class LegalCustomer : AbstractCustomer
    {
        public string TaxNo { get; set; }
        public string CompanyName { get; set; }
    }
}
