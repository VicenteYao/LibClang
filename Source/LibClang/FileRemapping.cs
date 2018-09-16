namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="FileRemapping" />
    /// </summary>
    public class FileRemapping : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileRemapping"/> class.
        /// </summary>
        /// <param name="path">The path<see cref="string"/></param>
        public FileRemapping(string path)
        {
            this.m_value = clang.clang_getRemappings(path);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRemapping"/> class.
        /// </summary>
        /// <param name="fileNames">The fileNames<see cref="string[]"/></param>
        public FileRemapping(string[] fileNames)
        {
            this.m_value = clang.clang_getRemappingsFromFileList(fileNames, (uint)fileNames.Length);
        }

        /// <summary>
        /// Defines the _mappings
        /// </summary>
        private (string, string)[] _mappings;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the Mappings
        /// </summary>
        public (string Original, string Transformed)[] Mappings
        {
            get
            {
                if (this._mappings == null)
                {
                    uint mappingsCount = clang.clang_remap_getNumFiles(this.m_value);
                    this._mappings = new (string, string)[mappingsCount];
                    for (uint i = 0; i < mappingsCount; i++)
                    {
                        CXString xOriginal;
                        CXString xTransformed;
                        clang.clang_remap_getFilenames(this.m_value, i, out xOriginal, out xTransformed);
                        this._mappings[i] = (xOriginal.ToStringAndDispose(), xTransformed.ToStringAndDispose());
                    }
                }
                return this._mappings;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_remap_dispose(this.m_value);
        }
    }
}
