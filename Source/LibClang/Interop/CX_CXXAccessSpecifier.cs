namespace LibClang.Intertop
{
    /**
     * Represents the C++ access control level to a base class for a
     * cursor with kind CX_CXXBaseSpecifier.
     */
    enum CX_CXXAccessSpecifier
    {
        /// <summary>
        /// Defines the CX_CXXInvalidAccessSpecifier
        /// </summary>
        CX_CXXInvalidAccessSpecifier,
        /// <summary>
        /// Defines the CX_CXXPublic
        /// </summary>
        CX_CXXPublic,
        /// <summary>
        /// Defines the CX_CXXProtected
        /// </summary>
        CX_CXXProtected,
        /// <summary>
        /// Defines the CX_CXXPrivate
        /// </summary>
        CX_CXXPrivate
    };
}
