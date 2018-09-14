namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxLoc" />
    /// </summary>
    public unsafe struct CXIdxLoc
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
        /// Defines the int_data
        /// </summary>
        public uint int_data;
    }
}
