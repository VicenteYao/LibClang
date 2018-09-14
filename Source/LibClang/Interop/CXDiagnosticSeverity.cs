namespace LibClang.Intertop
{
    /**
          * @}
          */

    /**
     * \defgroup CINDEX_DIAG Diagnostic reporting
     *
     * @{
     */

    /**
     * Describes the severity of a particular diagnostic.
     */
    enum CXDiagnosticSeverity
    {
        /**
                         * A diagnostic that has been suppressed, e.g., by a command-line
                         * option.
                         */
        CXDiagnostic_Ignored = 0,
        /**
         * This diagnostic is a note that should be attached to the
         * previous (non-note) diagnostic.
         */
        CXDiagnostic_Note = 1,
        /**
         * This diagnostic indicates suspicious code that may not be
         * wrong.
         */
        CXDiagnostic_Warning = 2,
        /**
         * This diagnostic indicates that the code is ill-formed.
         */
        CXDiagnostic_Error = 3,
        /**
         * This diagnostic indicates that the code is ill-formed such
         * that future parser recovery is unlikely to produce useful
         * results.
         */
        CXDiagnostic_Fatal = 4
    }
}
