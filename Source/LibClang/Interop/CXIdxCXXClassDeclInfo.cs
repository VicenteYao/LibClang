namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxCXXClassDeclInfo" />
    /// </summary>
    public unsafe struct CXIdxCXXClassDeclInfo
    {
        /// <summary>
        /// Defines the declInfo
        /// </summary>
        public CXIdxDeclInfo* declInfo;

        /// <summary>
        /// Defines the bases
        /// </summary>
        public CXIdxDeclInfo* bases;

        /// <summary>
        /// Defines the numBases
        /// </summary>
        public uint numBases;
    }
}
