namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxEntityRefInfo" />
    /// </summary>
    public unsafe struct CXIdxEntityRefInfo
    {
        /// <summary>
        /// Defines the kind
        /// </summary>
        public CXIdxEntityRefKind kind;

        /// <summary>
        /// Defines the cursor
        /// </summary>
        public CXCursor cursor;

        /// <summary>
        /// Defines the loc
        /// </summary>
        public CXIdxLoc loc;

        /// <summary>
        /// Defines the referencedEntity
        /// </summary>
        public CXIdxEntityInfo* referencedEntity;

        /// <summary>
        /// Defines the parentEntity
        /// </summary>
        public CXIdxEntityInfo* parentEntity;

        /// <summary>
        /// Defines the container
        /// </summary>
        public CXIdxContainerInfo* container;

        /// <summary>
        /// Defines the role
        /// </summary>
        public CXSymbolRole role;
    }
}
