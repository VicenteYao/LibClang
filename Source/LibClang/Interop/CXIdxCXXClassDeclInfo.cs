using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{


    public struct CXIdxCXXClassDeclInfo
    {
        /* CXIdxDeclInfo*/
        IntPtr declInfo;
        /*CXIdxBaseClassInfo*/
        IntPtr bases;
        uint numBases;
    }
}
