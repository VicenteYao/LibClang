using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxAttrInfo
    {
        CXIdxAttrKind kind;
        CXCursor cursor;
        CXIdxLoc loc;
    }
}
