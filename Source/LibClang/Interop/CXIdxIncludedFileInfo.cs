namespace LibClang.Intertop
{
    using CXFile = System.IntPtr;

    /// <summary>
    /// Defines the <see cref="CXIdxIncludedFileInfo" />
    /// </summary>
    public unsafe struct CXIdxIncludedFileInfo
    {
        /// <summary>
        /// Defines the hashLoc
        /// </summary>
        public CXIdxLoc hashLoc;

        /// <summary>
        /// Defines the filename
        /// </summary>
        public sbyte* filename;

        /// <summary>
        /// Defines the file
        /// </summary>
        internal CXFile file;

        /// <summary>
        /// Defines the isImport
        /// </summary>
        public int isImport;

        /// <summary>
        /// Defines the isAngled
        /// </summary>
        public int isAngled;

        /// <summary>
        /// Defines the isModuleImport
        /// </summary>
        public int isModuleImport;
    }
}
