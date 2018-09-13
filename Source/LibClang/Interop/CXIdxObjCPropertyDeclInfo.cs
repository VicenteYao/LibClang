using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    public struct CXIdxObjCPropertyDeclInfo
    {
        /* CXIdxDeclInfo*/
        IntPtr declInfo;
        /*CXIdxEntityInfo*/
        IntPtr getter;
        /*CXIdxEntityInfo*/
        IntPtr setter;
    }
}
