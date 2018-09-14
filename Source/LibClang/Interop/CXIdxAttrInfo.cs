using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxAttrInfo
    {
        public CXIdxAttrKind kind;
        public CXCursor cursor;
        public CXIdxLoc loc;
    }
}
