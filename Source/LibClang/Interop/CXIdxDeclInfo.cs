namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxDeclInfo" />
    /// </summary>
    public unsafe struct CXIdxDeclInfo
    {
        /// <summary>
        /// Defines the entityInfo
        /// </summary>
        public CXIdxEntityInfo* entityInfo;

        /// <summary>
        /// Defines the cursor
        /// </summary>
        public CXCursor cursor;

        /// <summary>
        /// Defines the loc
        /// </summary>
        public CXIdxLoc loc;

        /// <summary>
        /// Defines the semanticContainer
        /// </summary>
        public CXIdxContainerInfo* semanticContainer;

        /// <summary>
        /// Defines the lexicalContainer
        /// </summary>
        public CXIdxContainerInfo* lexicalContainer;

        /// <summary>
        /// Defines the isRedeclaration
        /// </summary>
        public int isRedeclaration;

        /// <summary>
        /// Defines the isDefinition
        /// </summary>
        public int isDefinition;

        /// <summary>
        /// Defines the isContainer
        /// </summary>
        public int isContainer;

        /// <summary>
        /// Defines the declAsContainer
        /// </summary>
        public CXIdxContainerInfo* declAsContainer;

        /// <summary>
        /// Defines the isImplicit
        /// </summary>
        public int isImplicit;

        /// <summary>
        /// Defines the attributes
        /// </summary>
        public CXIdxAttrInfo* attributes;

        /// <summary>
        /// Defines the numAttributes
        /// </summary>
        public uint numAttributes;

        /// <summary>
        /// Defines the flags
        /// </summary>
        public uint flags;
    }
}
