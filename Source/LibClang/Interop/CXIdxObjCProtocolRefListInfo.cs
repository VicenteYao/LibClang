namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxObjCProtocolRefListInfo" />
    /// </summary>
    public struct CXIdxObjCProtocolRefListInfo
    {
        /// <summary>
        /// Defines the protocols
        /// </summary>
        internal IntPtr protocols;

        /// <summary>
        /// Defines the numProtocols
        /// </summary>
        internal uint numProtocols;
    }
}
