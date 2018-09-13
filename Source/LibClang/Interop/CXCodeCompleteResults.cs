using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Contains the results of code-completion.
     *
     * This data structure contains the results of code completion, as
     * produced by \c clang_codeCompleteAt(). Its contents must be freed by
     * \c clang_disposeCodeCompleteResults.
     */
    public unsafe struct CXCodeCompleteResults
    {
        /**
         * The code-completion results.
         */
        public CXCompletionResult* Results;

        /**
         * The number of code-completion results stored in the
         * \c Results array.
         */
        public uint NumResults;
    }
}
