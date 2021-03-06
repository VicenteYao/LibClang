﻿namespace LibClang.Intertop
{
    /**
        * Describes the kind of error that occurred (if any) in a call to
        * \c clang_saveTranslationUnit().
        */
    public enum CXSaveError
    {
        /**
                                 * Indicates that no error occurred while saving a translation unit.
                                 */
        CXSaveError_None = 0,
        /**
         * Indicates that an unknown error occurred while attempting to save
         * the file.
         *
         * This error typically indicates that file I/O failed when attempting to
         * write the file.
         */
        CXSaveError_Unknown = 1,
        /**
         * Indicates that errors during translation prevented this attempt
         * to save the translation unit.
         *
         * Errors that prevent the translation unit from being saved can be
         * extracted using \c clang_getNumDiagnostics() and \c clang_getDiagnostic().
         */
        CXSaveError_TranslationErrors = 2,
        /**
         * Indicates that the translation unit to be saved was somehow
         * invalid (e.g., NULL).
         */
        CXSaveError_InvalidTU = 3
    }
}
