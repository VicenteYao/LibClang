namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the CXResult
    /// </summary>
    public enum CXResult
    {
        /**
                         * Function returned successfully.
                         */
        CXResult_Success = 0,
        /**
         * One of the parameters was invalid for the function.
         */
        CXResult_Invalid = 1,
        /**
         * The function was terminated by a callback (e.g. it returned
         * CXVisit_Break)
         */
        CXResult_VisitBreak = 2
    }
}
