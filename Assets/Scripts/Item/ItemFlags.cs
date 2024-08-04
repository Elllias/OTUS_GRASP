using System;

namespace Sample
{
    //Нельзя менять!
    [Flags]
    public enum ItemFlags
    {
        NONE = 0,
        STACKABLE = 1,
        CONSUMABLE = 2,
        EQUPPABLE = 4,
        EFFECTIBLE = 8
    }
}