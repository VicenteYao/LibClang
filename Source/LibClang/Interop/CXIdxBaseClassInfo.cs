using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    public struct CXIdxBaseClassInfo
    {
        CXIdxEntityInfo baseInfo;
        CXCursor cursor;
        CXIdxLoc loc;
    }
}
