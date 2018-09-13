using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
          * Describes the exception specification of a cursor.
          *
          * A negative value indicates that the cursor is not a function declaration.
          */
    public enum CXCursor_ExceptionSpecificationKind
    {

        /**
         * The cursor has no exception specification.
         */
        CXCursor_ExceptionSpecificationKind_None,

        /**
         * The cursor has exception specification throw()
         */
        CXCursor_ExceptionSpecificationKind_DynamicNone,

        /**
         * The cursor has exception specification throw(T1, T2)
         */
        CXCursor_ExceptionSpecificationKind_Dynamic,

        /**
         * The cursor has exception specification throw(...).
         */
        CXCursor_ExceptionSpecificationKind_MSAny,

        /**
         * The cursor has exception specification basic noexcept.
         */
        CXCursor_ExceptionSpecificationKind_BasicNoexcept,

        /**
         * The cursor has exception specification computed noexcept.
         */
        CXCursor_ExceptionSpecificationKind_ComputedNoexcept,

        /**
         * The exception specification has not yet been evaluated.
         */
        CXCursor_ExceptionSpecificationKind_Unevaluated,

        /**
         * The exception specification has not yet been instantiated.
         */
        CXCursor_ExceptionSpecificationKind_Uninstantiated,

        /**
         * The exception specification has not been parsed yet.
         */
        CXCursor_ExceptionSpecificationKind_Unparsed
    }
}
