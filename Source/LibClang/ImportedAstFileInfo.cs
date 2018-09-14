namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="ImportedAstFileInfo" />
    /// </summary>
    public class ImportedAstFileInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportedAstFileInfo"/> class.
        /// </summary>
        /// <param name="importedASTFileInfo">The importedASTFileInfo<see cref="CXIdxImportedASTFileInfo"/></param>
        internal ImportedAstFileInfo(CXIdxImportedASTFileInfo importedASTFileInfo)
        {
            this.m_value = importedASTFileInfo;
            this.File = new File(importedASTFileInfo.file);
            this.Module = new Module(importedASTFileInfo.module);
            this.IndexLocation = new IndexLocation(importedASTFileInfo.loc);
            this.IsImplicit = importedASTFileInfo.isImplicit > 0;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxImportedASTFileInfo m_value;

        /// <summary>
        /// Gets the File
        /// </summary>
        public File File { get; private set; }

        /// <summary>
        /// Gets the Module
        /// </summary>
        public Module Module { get; private set; }

        /// <summary>
        /// Gets the IndexLocation
        /// </summary>
        public IndexLocation IndexLocation { get; private set; }

        /// <summary>
        /// Gets a value indicating whether IsImplicit
        /// </summary>
        public bool IsImplicit { get; private set; }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
