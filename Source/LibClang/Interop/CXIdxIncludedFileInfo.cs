namespace LibClang.Intertop
{
    using System;
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
        public IntPtr filename;

        /// <summary>
        /// Defines the file
        /// </summary>
        public CXFile file;

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
