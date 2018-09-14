namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXSourceRange" />
    /// </summary>
    public struct CXSourceRange
    {
        /// <summary>
        /// Defines the ptr_data1
        /// </summary>
        public IntPtr ptr_data1;

        /// <summary>
        /// Defines the ptr_data2
        /// </summary>
        public IntPtr ptr_data2;

        /// <summary>
        /// Defines the begin_int_data
        /// </summary>
        public uint begin_int_data;

        /// <summary>
        /// Defines the end_int_data
        /// </summary>
        public uint end_int_data;
    }
}
