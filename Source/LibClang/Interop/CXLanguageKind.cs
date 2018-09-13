using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    /**
     * Describe the "language" of the entity referred to by a cursor.
     */
    public enum CXLanguageKind
    {
        CXLanguage_Invalid = 0,
        CXLanguage_C,
        CXLanguage_ObjC,
        CXLanguage_CPlusPlus
    }
}
