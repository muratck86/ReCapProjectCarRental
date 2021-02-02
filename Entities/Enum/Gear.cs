using System.ComponentModel;

namespace Entities.Abstract
{
    public enum Gear
    {
        Manual,
        Auto,
        [Description("Semi-Auto")] SemiAuto
    }
}
