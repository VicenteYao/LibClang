namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxObjCCategoryDeclInfo" />
    /// </summary>
    public struct CXIdxObjCCategoryDeclInfo
    {
        /// <summary>
        /// Defines the containerInfo
        /// </summary>
        internal IntPtr containerInfo;

        /// <summary>
        /// Defines the objcClass
        /// </summary>
        internal IntPtr objcClass;

        /// <summary>
        /// Defines the classCursor
        /// </summary>
        internal CXCursor classCursor;

        /// <summary>
        /// Defines the classLoc
        /// </summary>
        internal CXIdxLoc classLoc;

        /// <summary>
        /// Defines the protocols
        /// </summary>
        internal IntPtr protocols;
    }
}
