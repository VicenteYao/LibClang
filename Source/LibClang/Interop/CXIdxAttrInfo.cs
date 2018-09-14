namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxAttrInfo" />
    /// </summary>
    public struct CXIdxAttrInfo
    {
        /// <summary>
        /// Defines the kind
        /// </summary>
        public CXIdxAttrKind kind;

        /// <summary>
        /// Defines the cursor
        /// </summary>
        public CXCursor cursor;

        /// <summary>
        /// Defines the loc
        /// </summary>
        public CXIdxLoc loc;
    }
}
