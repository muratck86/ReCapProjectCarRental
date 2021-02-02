using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities.Abstract
{
    public enum Fuel
    {
        Gas,
        [Description("Gas&LPG")] GasLPG,
        Diesel,
        Hybrid,
        Electric,
        Hydrogen
    }
}
