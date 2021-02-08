using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Wheel
    {
        [Description("4WD")] fourwd, //0
        [Description("Front 2WD")] frontwd, //1
        [Description("Rear 2WD")] rearwd //2
    }
}
