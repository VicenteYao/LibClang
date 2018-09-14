namespace LibClang.Intertop
{
    /**
     * Represents the storage classes as declared in the source. CX_SC_Invalid
     * was added for the case that the passed cursor in not a declaration.
     */
    public enum CX_StorageClass
    {
        /// <summary>
        /// Defines the CX_SC_Invalid
        /// </summary>
        CX_SC_Invalid,
        /// <summary>
        /// Defines the CX_SC_None
        /// </summary>
        CX_SC_None,
        /// <summary>
        /// Defines the CX_SC_Extern
        /// </summary>
        CX_SC_Extern,
        /// <summary>
        /// Defines the CX_SC_Static
        /// </summary>
        CX_SC_Static,
        /// <summary>
        /// Defines the CX_SC_PrivateExtern
        /// </summary>
        CX_SC_PrivateExtern,
        /// <summary>
        /// Defines the CX_SC_OpenCLWorkGroupLocal
        /// </summary>
        CX_SC_OpenCLWorkGroupLocal,
        /// <summary>
        /// Defines the CX_SC_Auto
        /// </summary>
        CX_SC_Auto,
        /// <summary>
        /// Defines the CX_SC_Register
        /// </summary>
        CX_SC_Register
    };
}
