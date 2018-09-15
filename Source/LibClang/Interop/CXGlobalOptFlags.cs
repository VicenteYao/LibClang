namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the CXGlobalOptFlags
    /// </summary>
    public enum CXGlobalOptFlags
    {
        /**
                                 * Used to indicate that no special CXIndex options are needed.
                                 */
        CXGlobalOpt_None = 0x0,
        /**
         * Used to indicate that threads that libclang creates for indexing
         * purposes should use background priority.
         *
         * Affects #clang_indexSourceFile, #clang_indexTranslationUnit,
         * #clang_parseTranslationUnit, #clang_saveTranslationUnit.
         */
        CXGlobalOpt_ThreadBackgroundPriorityForIndexing = 0x1,
        /**
         * Used to indicate that threads that libclang creates for editing
         * purposes should use background priority.
         *
         * Affects #clang_reparseTranslationUnit, #clang_codeCompleteAt,
         * #clang_annotateTokens
         */
        CXGlobalOpt_ThreadBackgroundPriorityForEditing = 0x2,
        /**
         * Used to indicate that all threads that libclang creates should use
         * background priority.
         */
        CXGlobalOpt_ThreadBackgroundPriorityForAll =
            CXGlobalOpt_ThreadBackgroundPriorityForIndexing |
            CXGlobalOpt_ThreadBackgroundPriorityForEditing
    }
}
