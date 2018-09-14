namespace LibClang.Intertop
{
    using CXFile = System.IntPtr;
    using CXModule = System.IntPtr;

    /// <summary>
    /// Defines the <see cref="CXIdxImportedASTFileInfo" />
    /// </summary>
    public struct CXIdxImportedASTFileInfo
    {
        /// <summary>
        /// Defines the file
        /// </summary>
        public CXFile file;

        /// <summary>
        /// Defines the module
        /// </summary>
        public CXModule module;

        /// <summary>
        /// Defines the loc
        /// </summary>
        public CXIdxLoc loc;

        /// <summary>
        /// Defines the isImplicit
        /// </summary>
        public int isImplicit;
    }
}
