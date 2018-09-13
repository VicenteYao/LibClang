using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
            * Flags that can be passed to \c clang_codeCompleteAt() to
            * modify its behavior.
            *
            * The enumerators in this enumeration can be bitwise-OR'd together to
            * provide multiple options to \c clang_codeCompleteAt().
            */
    public enum CXCodeComplete_Flags
    {
        /**
         * Whether to include macros within the set of code
         * completions returned.
         */
        CXCodeComplete_IncludeMacros = 0x01,

        /**
         * Whether to include code patterns for language constructs
         * within the set of code completions, e.g., for loops.
         */
        CXCodeComplete_IncludeCodePatterns = 0x02,

        /**
         * Whether to include brief documentation within the set of code
         * completions returned.
         */
        CXCodeComplete_IncludeBriefComments = 0x04,

        /**
         * Whether to speed up completion by omitting top- or namespace-level entities
         * defined in the preamble. There's no guarantee any particular entity is
         * omitted. This may be useful if the headers are indexed externally.
         */
        CXCodeComplete_SkipPreamble = 0x08,

        /**
         * Whether to include completions with small
         * fix-its, e.g. change '.' to '->' on member access, etc.
         */
        CXCodeComplete_IncludeCompletionsWithFixIts = 0x10
    }
}
