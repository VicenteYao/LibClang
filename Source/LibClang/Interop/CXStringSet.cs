using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    public unsafe struct CXStringSet
    {
        public CXString* Strings;
        public uint Count;
    }
}
