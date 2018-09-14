namespace LibClang.Intertop
{
    /**
          * Describes the kind of error that occurred (if any) in a call to
          * \c clang_loadDiagnostics.
          */
    public enum CXLoadDiag_Error
    {
        /**
                         * Indicates that no error occurred.
                         */
        CXLoadDiag_None = 0,
        /**
         * Indicates that an unknown error occurred while attempting to
         * deserialize diagnostics.
         */
        CXLoadDiag_Unknown = 1,
        /**
         * Indicates that the file containing the serialized diagnostics
         * could not be opened.
         */
        CXLoadDiag_CannotLoad = 2,
        /**
         * Indicates that the serialized diagnostics file is invalid or
         * corrupt.
         */
        CXLoadDiag_InvalidFile = 3
    }
}
