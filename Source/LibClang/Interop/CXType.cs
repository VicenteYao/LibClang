using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * The type of an element in the abstract syntax tree.
     *
     */
    public struct CXType
    {
        public CXTypeKind kind;
        public IntPtr data1;
        public IntPtr data2;
    };
}
