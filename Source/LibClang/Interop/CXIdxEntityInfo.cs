using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public unsafe struct CXIdxEntityInfo
    {
        public CXIdxEntityKind kind;
        public CXIdxEntityCXXTemplateKind templateKind;
        public CXIdxEntityLanguage lang;
        public IntPtr name;
        public IntPtr USR;
        public CXCursor cursor;
        public CXIdxAttrInfo* attributes;
        public uint numAttributes;
    }
}
