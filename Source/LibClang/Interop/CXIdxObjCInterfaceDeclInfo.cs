using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXIdxObjCInterfaceDeclInfo
    {
        /* CXIdxObjCContainerDeclInfo*/
        IntPtr containerInfo;
        /*CXIdxBaseClassInfo*/
        IntPtr superInfo;
        /* CXIdxObjCProtocolRefListInfo*/
        IntPtr protocols;
    }
}
