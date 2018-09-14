namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxBaseClassInfo" />
    /// </summary>
    public struct CXIdxBaseClassInfo
    {
        /// <summary>
        /// Defines the baseInfo
        /// </summary>
        internal CXIdxEntityInfo baseInfo;

        /// <summary>
        /// Defines the cursor
        /// </summary>
        internal CXCursor cursor;

        /// <summary>
        /// Defines the loc
        /// </summary>
        internal CXIdxLoc loc;
    }
}
