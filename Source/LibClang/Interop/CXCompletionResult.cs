namespace LibClang.Intertop
{
    using System.Runtime.InteropServices;
    using CXCompletionString = System.IntPtr;

    /// <summary>
    /// Defines the <see cref="CXCompletionResult" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct CXCompletionResult
    {
        /// <summary>
        /// Defines the CursorKind
        /// </summary>
        public CXCursorKind CursorKind;

        /// <summary>
        /// Defines the CompletionString
        /// </summary>
        public CXCompletionString CompletionString;
    }
}
