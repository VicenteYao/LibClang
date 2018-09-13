using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{

    /**
     * Roles that are attributed to symbol occurrences.
     *
     * Internal: this currently mirrors low 9 bits of clang::index::SymbolRole with
     * higher bits zeroed. These high bits may be exposed in the future.
     */
    public enum CXSymbolRole
    {
        CXSymbolRole_None = 0,
        CXSymbolRole_Declaration = 1 << 0,
        CXSymbolRole_Definition = 1 << 1,
        CXSymbolRole_Reference = 1 << 2,
        CXSymbolRole_Read = 1 << 3,
        CXSymbolRole_Write = 1 << 4,
        CXSymbolRole_Call = 1 << 5,
        CXSymbolRole_Dynamic = 1 << 6,
        CXSymbolRole_AddressOf = 1 << 7,
        CXSymbolRole_Implicit = 1 << 8
    }
}
