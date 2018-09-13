using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxObjCCategoryDeclInfo
    {
        /* CXIdxObjCContainerDeclInfo*/
        IntPtr containerInfo;
        /* CXIdxEntityInfo*/
        IntPtr objcClass;
        CXCursor classCursor;
        CXIdxLoc classLoc;
        /* CXIdxObjCProtocolRefListInfo*/
        IntPtr protocols;
    }
}
