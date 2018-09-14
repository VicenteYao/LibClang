namespace LibClang.Intertop
{
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="CXCodeCompleteResults" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CXCodeCompleteResults
    {
        /// <summary>
        /// Defines the Results
        /// </summary>
        public CXCompletionResult* Results;

        /// <summary>
        /// Defines the NumResults
        /// </summary>
        public uint NumResults;
    }
}
