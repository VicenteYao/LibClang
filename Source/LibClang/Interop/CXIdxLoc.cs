using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    /**
     * Source location passed to index callbacks.
     */
    public unsafe struct CXIdxLoc
    {
        public IntPtr ptr_data1;
        public IntPtr ptr_data2;
        public uint int_data;
    }

}
