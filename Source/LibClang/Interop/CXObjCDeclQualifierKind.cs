namespace LibClang.Intertop
{
    /**
     * 'Qualifiers' written next to the return and parameter types in
     * Objective-C method declarations.
     */
    public enum CXObjCDeclQualifierKind
    {
        /// <summary>
        /// Defines the CXObjCDeclQualifier_None
        /// </summary>
        CXObjCDeclQualifier_None = 0x0,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_In
        /// </summary>
        CXObjCDeclQualifier_In = 0x1,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_Inout
        /// </summary>
        CXObjCDeclQualifier_Inout = 0x2,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_Out
        /// </summary>
        CXObjCDeclQualifier_Out = 0x4,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_Bycopy
        /// </summary>
        CXObjCDeclQualifier_Bycopy = 0x8,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_Byref
        /// </summary>
        CXObjCDeclQualifier_Byref = 0x10,
        /// <summary>
        /// Defines the CXObjCDeclQualifier_Oneway
        /// </summary>
        CXObjCDeclQualifier_Oneway = 0x20
    }
}
