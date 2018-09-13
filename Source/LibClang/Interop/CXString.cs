using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * A character string.
     *
     * The \c CXString type is used to return strings from the interface when
     * the ownership of that string might differ from one call to the next.
     * Use \c clang_getCString() to retrieve the string data and, once finished
     * with the string data, call \c clang_disposeString() to free the string.
     */
    public struct CXString
    {
        IntPtr data;
        uint private_flags;
    }
}
