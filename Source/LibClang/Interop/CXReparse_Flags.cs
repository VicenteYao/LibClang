﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    /**
     * Flags that control the reparsing of translation units.
     *
     * The enumerators in this enumeration type are meant to be bitwise
     * ORed together to specify which options should be used when
     * reparsing the translation unit.
     */
    enum CXReparse_Flags
    {
        /**
         * Used to indicate that no special reparsing options are needed.
         */
        CXReparse_None = 0x0
    };
}
