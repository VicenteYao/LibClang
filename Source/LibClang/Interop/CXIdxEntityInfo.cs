using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public unsafe struct CXIdxEntityInfo
    {
        CXIdxEntityKind kind;
        CXIdxEntityCXXTemplateKind templateKind;
        CXIdxEntityLanguage lang;
        sbyte* name;
        sbyte* USR;
        CXCursor cursor;
        CXIdxAttrInfo* attributes;
        uint numAttributes;
    }
}
