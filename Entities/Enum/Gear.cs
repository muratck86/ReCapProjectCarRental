using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Gear
    {
        Manual, //0
        Auto, //1
        [Description("Semi-Auto")] SemiAuto //2
    }
}
