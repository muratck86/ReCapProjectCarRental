using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Body
    {
        SUV,
        Sedan,
        [Description("Hatch-Back")] HB,
        [Description("Station-Wagon")] stw,
        Coupe,
        Cabrio,
        Roadster,
        Crossover,
        [Description("Mini Van")] mv
    }
}
