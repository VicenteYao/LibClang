namespace LibClang.Intertop
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="CXToken" />
    /// </summary>
    public struct CXToken
    {
        /// <summary>
        /// Defines the int_data1
        /// </summary>
        public uint int_data1;

        /// <summary>
        /// Defines the int_data2
        /// </summary>
        public uint int_data2;

        /// <summary>
        /// Defines the int_data3
        /// </summary>
        public uint int_data3;

        /// <summary>
        /// Defines the int_data4
        /// </summary>
        public uint int_data4;

        /// <summary>
        /// Defines the ptr_data
        /// </summary>
        public IntPtr ptr_data;
    }

    /// <summary>
    /// Defines the <see cref="CXTokenObject" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public class CXTokenObject
    {
        /// <summary>
        /// Defines the int_data1
        /// </summary>
        public uint int_data1;

        /// <summary>
        /// Defines the int_data2
        /// </summary>
        public uint int_data2;

        /// <summary>
        /// Defines the int_data3
        /// </summary>
        public uint int_data3;

        /// <summary>
        /// Defines the int_data4
        /// </summary>
        public uint int_data4;

        /// <summary>
        /// Defines the ptr_data
        /// </summary>
        public IntPtr ptr_data;
    }
}
