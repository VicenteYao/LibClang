namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxObjCProtocolRefInfo" />
    /// </summary>
    public struct CXIdxObjCProtocolRefInfo
    {
        /// <summary>
        /// Defines the protocol
        /// </summary>
        internal CXIdxEntityInfo protocol;

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
