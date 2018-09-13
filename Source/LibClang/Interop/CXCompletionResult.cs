using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using CXCompletionString = System.IntPtr;

namespace LibClang.Intertop
{
    /**
     * A single result of code completion.
     */
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CXCompletionResult
    {
        /**
         * The kind of entity that this completion refers to.
         *
         * The cursor kind will be a macro, keyword, or a declaration (one of the
         * *Decl cursor kinds), describing the entity that the completion is
         * referring to.
         *
         * \todo In the future, we would like to provide a full cursor, to allow
         * the client to extract additional information from declaration.
         */
        public CXCursorKind CursorKind;

        /**
         * The code-completion string that describes how to insert this
         * code-completion result into the editing buffer.
         */
        public CXCompletionString CompletionString;
    }
}
