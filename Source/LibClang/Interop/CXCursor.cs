namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXCursor" />
    /// </summary>
    public unsafe struct CXCursor
    {
        /// <summary>
        /// Defines the kind
        /// </summary>
        public CXCursorKind kind;

        /// <summary>
        /// Defines the xdata
        /// </summary>
        public int xdata;

        /// <summary>
        /// Defines the data1
        /// </summary>
        public IntPtr data1;

        /// <summary>
        /// Defines the data2
        /// </summary>
        public IntPtr data2;

        /// <summary>
        /// Defines the data3
        /// </summary>
        public IntPtr data3;
    }
}
