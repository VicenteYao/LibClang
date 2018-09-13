using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
          * The memory usage of a CXTranslationUnit, broken into categories.
          */
    public unsafe struct CXTUResourceUsage
    {
        /* Private data member, used for queries. */
        public void* data;

        /* The number of entries in the 'entries' array. */
        public uint numEntries;

        /* An array of key-value pairs, representing the breakdown of memory
                  usage. */
        public CXTUResourceUsageEntry* entries;

    }
}
