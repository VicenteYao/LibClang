namespace LibClang
{
    using LibClang.Intertop;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="IndexIncludedFileInfo" />
    /// </summary>
    public class IndexIncludedFileInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexIncludedFileInfo"/> class.
        /// </summary>
        /// <param name="cXIdxIncludedFileInfo">The cXIdxIncludedFileInfo<see cref="CXIdxIncludedFileInfo*"/></param>
        internal unsafe IndexIncludedFileInfo(CXIdxIncludedFileInfo cXIdxIncludedFileInfo)
        {
            this.HashLocation = new IndexLocation(cXIdxIncludedFileInfo.hashLoc);
            this.IsAngled = cXIdxIncludedFileInfo.isAngled > 0;
            this.IsImport = cXIdxIncludedFileInfo.isImport > 0;
            this.IsModuleImport = cXIdxIncludedFileInfo.isModuleImport > 0;
            this.File = new File(cXIdxIncludedFileInfo.file);
            this.FileName = Marshal.PtrToStringAnsi(cXIdxIncludedFileInfo.filename);
        }

        /// <summary>
        /// Gets the HashLocation
        /// </summary>
        public IndexLocation HashLocation { get; private set; }

        /// <summary>
        /// Gets the FileName
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the File
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsImport
        /// </summary>
        public bool IsImport { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsAngled
        /// </summary>
        public bool IsAngled { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsModuleImport
        /// </summary>
        public bool IsModuleImport { get; private set; }
    }
}
