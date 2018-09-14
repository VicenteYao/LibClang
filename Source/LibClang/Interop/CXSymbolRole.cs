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
        /// <summary>
        /// Defines the CXSymbolRole_None
        /// </summary>
        CXSymbolRole_None = 0,
        /// <summary>
        /// Defines the CXSymbolRole_Declaration
        /// </summary>
        CXSymbolRole_Declaration = 1 << 0,
        /// <summary>
        /// Defines the CXSymbolRole_Definition
        /// </summary>
        CXSymbolRole_Definition = 1 << 1,
        /// <summary>
        /// Defines the CXSymbolRole_Reference
        /// </summary>
        CXSymbolRole_Reference = 1 << 2,
        /// <summary>
        /// Defines the CXSymbolRole_Read
        /// </summary>
        CXSymbolRole_Read = 1 << 3,
        /// <summary>
        /// Defines the CXSymbolRole_Write
        /// </summary>
        CXSymbolRole_Write = 1 << 4,
        /// <summary>
        /// Defines the CXSymbolRole_Call
        /// </summary>
        CXSymbolRole_Call = 1 << 5,
        /// <summary>
        /// Defines the CXSymbolRole_Dynamic
        /// </summary>
        CXSymbolRole_Dynamic = 1 << 6,
        /// <summary>
        /// Defines the CXSymbolRole_AddressOf
        /// </summary>
        CXSymbolRole_AddressOf = 1 << 7,
        /// <summary>
        /// Defines the CXSymbolRole_Implicit
        /// </summary>
        CXSymbolRole_Implicit = 1 << 8
    }
}
