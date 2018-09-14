namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXIdxIBOutletCollectionAttrInfo" />
    /// </summary>
    public struct CXIdxIBOutletCollectionAttrInfo
    {
        /// <summary>
        /// Defines the attrInfo
        /// </summary>
        internal CXIdxAttrInfo attrInfo;

        /// <summary>
        /// Defines the objcClass
        /// </summary>
        internal CXIdxEntityInfo objcClass;

        /// <summary>
        /// Defines the classCursor
        /// </summary>
        internal CXCursor classCursor;

        /// <summary>
        /// Defines the classLoc
        /// </summary>
        internal CXIdxLoc classLoc;
    }
}
