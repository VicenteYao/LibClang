using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
          * List the possible error codes for \c clang_Type_getSizeOf,
          *   \c clang_Type_getAlignOf, \c clang_Type_getOffsetOf and
          *   \c clang_Cursor_getOffsetOf.
          *
          * A value of this enumeration type can be returned if the target type is not
          * a valid argument to sizeof, alignof or offsetof.
          */
    enum CXTypeLayoutError
    {
        /**
         * Type is of kind CXType_Invalid.
         */
        CXTypeLayoutError_Invalid = -1,
        /**
         * The type is an incomplete Type.
         */
        CXTypeLayoutError_Incomplete = -2,
        /**
         * The type is a dependent Type.
         */
        CXTypeLayoutError_Dependent = -3,
        /**
         * The type is not a constant size type.
         */
        CXTypeLayoutError_NotConstantSize = -4,
        /**
         * The Field name is not valid for this record.
         */
        CXTypeLayoutError_InvalidFieldName = -5
    };
}
