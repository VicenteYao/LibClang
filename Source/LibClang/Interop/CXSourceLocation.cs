using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * @}
     */

    /**
     * \defgroup CINDEX_LOCATIONS Physical source locations
     *
     * Clang represents physical source locations in its abstract syntax tree in
     * great detail, with file, line, and column information for the majority of
     * the tokens parsed in the source code. These data types and functions are
     * used to represent source location information, either for a particular
     * point in the program or for a range of points in the program, and extract
     * specific location information from those data types.
     *
     * @{
     */

    /**
     * Identifies a specific source location within a translation
     * unit.
     *
     * Use clang_getExpansionLocation() or clang_getSpellingLocation()
     * to map a source location to a particular file, line, and column.
     */
    public struct CXSourceLocation
    {
        public IntPtr ptr_data1;
        public IntPtr ptr_data2;
        public uint int_data;
    }
}
