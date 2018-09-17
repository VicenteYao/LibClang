namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="UnsavedFile" />
    /// </summary>
    public class UnsavedFile : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsavedFile"/> class.
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        public UnsavedFile(string fileName, string contents)
        {
            this.m_value = new CXUnsavedFile()
            {
                Filename = Marshal.StringToHGlobalAnsi(fileName),
                Contents = Marshal.StringToHGlobalAnsi(contents),
                Length = (uint)contents.Length,
            };
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXUnsavedFile m_value;

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            Marshal.FreeHGlobal(this.m_value.Filename);
            Marshal.FreeHGlobal(this.m_value.Contents);
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
