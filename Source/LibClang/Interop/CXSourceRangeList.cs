using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Identifies an array of ranges.
     */
    public unsafe struct CXSourceRangeList
    {
        /** The number of ranges in the \c ranges array. */
        public uint count;
        /**
         * An array of \c CXSourceRanges.
         */
        public CXSourceRange* ranges;
    }
}
