using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{


    public unsafe struct CXIdxCXXClassDeclInfo
    {
       public CXIdxDeclInfo* declInfo;

        public CXIdxDeclInfo* bases;
        public uint numBases;
    }
}
