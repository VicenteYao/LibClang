using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Describe the "thread-local storage (TLS) kind" of the declaration
     * referred to by a cursor.
     */
    public enum CXTLSKind
    {
        CXTLS_None = 0,
        CXTLS_Dynamic,
        CXTLS_Static
    }
}
