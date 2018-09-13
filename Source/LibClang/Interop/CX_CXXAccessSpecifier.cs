using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Represents the C++ access control level to a base class for a
     * cursor with kind CX_CXXBaseSpecifier.
     */
    enum CX_CXXAccessSpecifier
    {
        CX_CXXInvalidAccessSpecifier,
        CX_CXXPublic,
        CX_CXXProtected,
        CX_CXXPrivate
    };
}
