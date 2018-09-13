using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace LibClang.Intertop
{

    /**
     * Describes a single preprocessing token.
     */
    public struct CXToken
    {
        public uint int_data1;
        public uint int_data2;
        public uint int_data3;
        public uint int_data4;
        public IntPtr ptr_data;
    }

    [StructLayout(LayoutKind.Sequential)]
    public class CXTokenObject
    {
        public uint int_data1;
        public uint int_data2;
        public uint int_data3;
        public uint int_data4;
        public IntPtr ptr_data;
    }
}
