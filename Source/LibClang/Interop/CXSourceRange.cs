using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Identifies a half-open character range in the source code.
     *
     * Use clang_getRangeStart() and clang_getRangeEnd() to retrieve the
     * starting and end locations from a source range, respectively.
     */
    public struct CXSourceRange
    {
        public IntPtr ptr_data1;
        public IntPtr ptr_data2;
        public uint begin_int_data;
        public uint end_int_data;
    }
}
