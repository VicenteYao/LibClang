using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
     * Represents the storage classes as declared in the source. CX_SC_Invalid
     * was added for the case that the passed cursor in not a declaration.
     */
    public enum CX_StorageClass
    {
        CX_SC_Invalid,
        CX_SC_None,
        CX_SC_Extern,
        CX_SC_Static,
        CX_SC_PrivateExtern,
        CX_SC_OpenCLWorkGroupLocal,
        CX_SC_Auto,
        CX_SC_Register
    };
}
