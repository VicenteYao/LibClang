namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="File" />
    /// </summary>
    public class File : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="File"/> class.
        /// </summary>
        /// <param name="file">The file<see cref="IntPtr"/></param>
        internal File(IntPtr file)
        {
            this.m_value = file;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the _fileName
        /// </summary>
        private string _fileName;

        /// <summary>
        /// Gets the FileName
        /// </summary>
        public string FileName
        {
            get
            {
                if (this._fileName == null)
                {
                    this._fileName = clang.clang_getFileName(this.m_value).ToStringAndDispose();
                }
                return this._fileName;
            }
        }

        /// <summary>
        /// Defines the realPathName
        /// </summary>
        private string realPathName;

        /// <summary>
        /// Gets the RealPathName
        /// </summary>
        public string RealPathName
        {
            get
            {
                if (this.realPathName == null)
                {
                    this.realPathName = clang.clang_File_tryGetRealPathName(this.m_value).ToStringAndDispose();
                }
                return this.realPathName;
            }
        }

        /// <summary>
        /// Defines the lines
        /// </summary>
        private string[] lines;

        /// <summary>
        /// Gets the Lines
        /// </summary>
        public string[] Lines
        {
            get
            {
                if (this.lines == null)
                {
                    this.lines = System.IO.File.ReadAllLines(this.FileName);
                }
                return this.lines;
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
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_File_isEqual(this.m_value, (IntPtr)clangObject.Value) > 0;
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return this.FileName;
        }
    }
}
