using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
    * Uniquely identifies a CXFile, that refers to the same underlying file,
    * across an indexing session.
    */
    public struct CXFileUniqueID
    {
        public ulong data1;
        public ulong data2;
        public ulong data3;
    }
}
