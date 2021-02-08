using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Entities.Abstract
{
    public enum Fuel
    {
        Gas, //0
        [Description("Gas&LPG")] GasLPG, //1
        Diesel, //2
        Hybrid, //3
        Electric, //4
        Hydrogen //5
    }
}
