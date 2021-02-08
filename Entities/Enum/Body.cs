using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Body
    {
        SUV, //0
        Sedan, //1
        [Description("Hatch-Back")] HB, //2
        [Description("Station-Wagon")] stw, //3
        Coupe, //4
        Cabrio, //5
        Roadster, //6
        Crossover, //7
        [Description("Mini Van")] mv //8
    }
}
