namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="SourceLocation" />
    /// </summary>
    public class SourceLocation : ClangObject
    {
        /// <summary>
        /// Initializes static members of the <see cref="SourceLocation"/> class.
        /// </summary>
        static SourceLocation()
        {
            SourceLocation.Null = new SourceLocation(clang.clang_getNullLocation());
        }

        /// <summary>
        /// Gets the Null
        /// </summary>
        public static SourceLocation Null { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceLocation"/> class.
        /// </summary>
        /// <param name="sourceLocation">The sourceLocation<see cref="CXSourceLocation"/></param>
        internal SourceLocation(CXSourceLocation sourceLocation)
        {
            this.m_value = sourceLocation;
        }

        /// <summary>
        /// The EnsurenExpansionLocation
        /// </summary>
        private void EnsurenExpansionLocation()
        {
            if (this.expansionLocation == null)
            {
                IntPtr filePtr = IntPtr.Zero;
                uint line;
                uint column;
                uint offset;
                clang.clang_getExpansionLocation(this.m_value, out filePtr, out line, out column, out offset);
                File file = new File(filePtr);
                this.expansionLocation = new ExpansionLocation(file, line, column, offset);
            }
        }

        /// <summary>
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalLocations(this.m_value, (CXSourceLocation)clangObject.Value) > 0;
        }

        /// <summary>
        /// Defines the <see cref="ExpansionLocation" />
        /// </summary>
        private class ExpansionLocation
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExpansionLocation"/> class.
            /// </summary>
            /// <param name="file">The file<see cref="File"/></param>
            /// <param name="line">The line<see cref="uint"/></param>
            /// <param name="column">The column<see cref="uint"/></param>
            /// <param name="offset">The offset<see cref="uint"/></param>
            internal ExpansionLocation(File file, uint line, uint column, uint offset)
            {
                this.File = file;
                this.Line = line;
                this.Column = column;
                this.Offset = offset;
            }

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
        /// Defines the presumedLocation
        /// </summary>
        private PresumedLocation presumedLocation;

        /// <summary>
        /// Gets the PresumedLocation
        /// </summary>
        public PresumedLocation PresumedLocation
        {
            get
            {
                if (this.presumedLocation == null)
                {
                    this.EnsurePresumedLocation();
                }
                return this.presumedLocation;
            }
        }

        /// <summary>
        /// The EnsurePresumedLocation
        /// </summary>
        private void EnsurePresumedLocation()
        {
            if (this.presumedLocation == null)
            {
                CXString ptrFileName;
                uint column;
                uint line;
                clang.clang_getPresumedLocation(this.m_value, out ptrFileName, out line, out column);
                this.presumedLocation = new PresumedLocation(ptrFileName.ToStringAndDispose(), line, column);
            }
        }

        /// <summary>
        /// Defines the isFromMainFile
        /// </summary>
        private bool? isFromMainFile;

        /// <summary>
        /// Gets a value indicating whether IsFromMainFile
        /// </summary>
        public bool IsFromMainFile
        {

            get
            {
                if (!this.isFromMainFile.HasValue)
                {
                    this.isFromMainFile = clang.clang_Location_isFromMainFile(this.m_value) > 0;
                }
                return this.isFromMainFile.Value;
            }
        }

        /// <summary>
        /// Defines the isInSystemHeader
        /// </summary>
        private bool? isInSystemHeader;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXSourceLocation m_value;

        /// <summary>
        /// Gets a value indicating whether IsInSystemHeader
        /// </summary>
        public bool IsInSystemHeader
        {
            get
            {
                if (!this.isInSystemHeader.HasValue)
                {
                    this.isInSystemHeader = clang.clang_Location_isInSystemHeader(this.m_value) > 0;
                }
                return this.isInSystemHeader.Value;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value { get { return this.m_value; } }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("{0}:{1},{2}", this.File, this.Line, this.Column);
        }
    }
}
