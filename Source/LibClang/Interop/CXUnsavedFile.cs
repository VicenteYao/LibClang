namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXUnsavedFile" />
    /// </summary>
    public unsafe struct CXUnsavedFile
    {
        /// <summary>
        /// Defines the Filename
        /// </summary>
        public IntPtr Filename;

        /// <summary>
        /// Defines the Contents
        /// </summary>
        public IntPtr Contents;

        /// <summary>
        /// Defines the Length
        /// </summary>
        public uint Length;
    }
}
