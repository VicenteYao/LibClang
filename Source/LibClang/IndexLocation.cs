namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexLocation" />
    /// </summary>
    public class IndexLocation : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexLocation"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="CXIdxLoc"/></param>
        internal IndexLocation(CXIdxLoc value)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Defines the _sourceLocation
        /// </summary>
        private SourceLocation _sourceLocation;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxLoc m_value;

        /// <summary>
        /// Gets the SourceLocation
        /// </summary>
        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation == null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_indexLoc_getCXSourceLocation(this.m_value));
                }
                return this._sourceLocation;
            }
        }

        /// <summary>
        /// The EnsurenExpansionLocation
        /// </summary>
        private void EnsurenExpansionLocation()
        {
            if (this.expansionLocation == null)
            {
                IntPtr pfilePtr = IntPtr.Zero;
                IntPtr pIndexFile = IntPtr.Zero;
                uint line;
                uint column;
                uint offset;
                clang.clang_indexLoc_getFileLocation(this.m_value, out pIndexFile, out pfilePtr, out line, out column, out offset);
                File file = new File(pfilePtr);
                File indexFile = new File(pIndexFile);
                this.expansionLocation = new ExpansionLocation(indexFile, file, line, column, offset);
            }
        }

        /// <summary>
        /// Defines the <see cref="ExpansionLocation" />
        /// </summary>
        private class ExpansionLocation
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExpansionLocation"/> class.
            /// </summary>
            /// <param name="indexFile">The indexFile<see cref="File"/></param>
            /// <param name="file">The file<see cref="File"/></param>
            /// <param name="line">The line<see cref="uint"/></param>
            /// <param name="column">The column<see cref="uint"/></param>
            /// <param name="offset">The offset<see cref="uint"/></param>
            internal ExpansionLocation(File indexFile, File file, uint line, uint column, uint offset)
            {
                this.IndexFile = indexFile;
                this.File = file;
                this.Line = line;
                this.Column = column;
                this.Offset = offset;
            }

            /// <summary>
            /// Defines the IndexFile
            /// </summary>
            public File IndexFile;

            /// <summary>
            /// Defines the File
            /// </summary>
            public File File;

            /// <summary>
            /// Defines the Line
            /// </summary>
            public uint Line;

            /// <summary>
            /// Defines the Column
            /// </summary>
            public uint Column;

            /// <summary>
            /// Defines the Offset
            /// </summary>
            public uint Offset;
        }

        /// <summary>
        /// Defines the expansionLocation
        /// </summary>
        private ExpansionLocation expansionLocation;

        /// <summary>
        /// Gets the File
        /// </summary>
        public File File
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.File;
            }
        }

        /// <summary>
        /// Gets the IndexFile
        /// </summary>
        public File IndexFile
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.IndexFile;
            }
        }

        /// <summary>
        /// Gets the Column
        /// </summary>
        public uint Column
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Column;
            }
        }

        /// <summary>
        /// Gets the Line
        /// </summary>
        public uint Line
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Line;
            }
        }

        /// <summary>
        /// Gets the Offset
        /// </summary>
        public uint Offset
        {
            get
            {
                this.EnsurenExpansionLocation();
                return this.expansionLocation.Offset;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return this.SourceLocation.ToString();
        }
    }
}
