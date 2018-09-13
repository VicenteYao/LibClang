using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public enum CXVisibilityKind
    {
        /** This value indicates that no visibility information is available
         * for a provided CXCursor. */
        CXVisibility_Invalid,

        /** Symbol not seen by the linker. */
        CXVisibility_Hidden,
        /** Symbol seen by the linker but resolves to a symbol inside this object. */
        CXVisibility_Protected,
        /** Symbol seen by the linker and acts like a normal symbol. */
        CXVisibility_Default
    }
}
