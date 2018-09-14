namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXString" />
    /// </summary>
    public struct CXString
    {
        /// <summary>
        /// Defines the data
        /// </summary>
        internal IntPtr data;

        /// <summary>
        /// Defines the private_flags
        /// </summary>
        internal uint private_flags;
    }
}
