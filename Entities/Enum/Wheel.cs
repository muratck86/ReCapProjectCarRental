using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Wheel
    {
        [Description("4WD")] fourwd,
        [Description("Front 2WD")] frontwd,
        [Description("Rear 2WD")] rearwd
    }
}
