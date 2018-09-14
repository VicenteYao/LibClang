namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxObjCInterfaceDeclInfo" />
    /// </summary>
    public struct CXIdxObjCInterfaceDeclInfo
    {
        /// <summary>
        /// Defines the containerInfo
        /// </summary>
        internal IntPtr containerInfo;

        /// <summary>
        /// Defines the superInfo
        /// </summary>
        internal IntPtr superInfo;

        /// <summary>
        /// Defines the protocols
        /// </summary>
        internal IntPtr protocols;
    }
}
