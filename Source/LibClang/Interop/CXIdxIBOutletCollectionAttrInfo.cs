using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxIBOutletCollectionAttrInfo
    {
        CXIdxAttrInfo attrInfo;
        CXIdxEntityInfo objcClass;
        CXCursor classCursor;
        CXIdxLoc classLoc;
    }
}
