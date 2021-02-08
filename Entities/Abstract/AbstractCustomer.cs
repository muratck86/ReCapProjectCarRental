using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
    public abstract class AbstractCustomer : IEntity
    {
        public int Id { get; set; }
    }
}
