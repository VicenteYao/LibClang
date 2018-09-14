namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxObjCPropertyDeclInfo" />
    /// </summary>
    public struct CXIdxObjCPropertyDeclInfo
    {
        /// <summary>
        /// Defines the declInfo
        /// </summary>
        internal IntPtr declInfo;

        /// <summary>
        /// Defines the getter
        /// </summary>
        internal IntPtr getter;

        /// <summary>
        /// Defines the setter
        /// </summary>
        internal IntPtr setter;
    }
}
