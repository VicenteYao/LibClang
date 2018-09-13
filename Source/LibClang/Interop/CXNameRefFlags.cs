using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    public enum CXNameRefFlags
    {
        /**
         * Include the nested-name-specifier, e.g. Foo:: in x.Foo::y, in the
         * range.
         */
        CXNameRange_WantQualifier = 0x1,

        /**
         * Include the explicit template arguments, e.g. \<int> in x.f<int>,
         * in the range.
         */
        CXNameRange_WantTemplateArgs = 0x2,

        /**
         * If the name is non-contiguous, return the full spanning range.
         *
         * Non-contiguous names occur in Objective-C when a selector with two or more
         * parameters is used, or in C++ when using an operator:
         * \code
         * [object doSomething:here withValue:there]; // Objective-C
         * return some_vector[1]; // C++
         * \endcode
         */
        CXNameRange_WantSinglePiece = 0x4
    }

}
