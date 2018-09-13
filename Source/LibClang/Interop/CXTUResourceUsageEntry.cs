using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public struct CXTUResourceUsageEntry
    {
        /* The memory usage category. */
        public CXTUResourceUsageKind kind;
        /* Amount of resources used.
            The units will depend on the resource kind. */
        public uint amount;
    }

}
