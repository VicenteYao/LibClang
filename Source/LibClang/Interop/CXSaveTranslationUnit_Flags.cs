using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
          * Flags that control how translation units are saved.
          *
          * The enumerators in this enumeration type are meant to be bitwise
          * ORed together to specify which options should be used when
          * saving the translation unit.
          */
    enum CXSaveTranslationUnit_Flags
    {
        /**
         * Used to indicate that no special saving options are needed.
         */
        CXSaveTranslationUnit_None = 0x0
    };
}
