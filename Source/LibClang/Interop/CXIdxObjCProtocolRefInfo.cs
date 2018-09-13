using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxObjCProtocolRefInfo
    {
        CXIdxEntityInfo protocol;
        CXCursor cursor;
        CXIdxLoc loc;
    }
}
