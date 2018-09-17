namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="Index" />
    /// </summary>
    public unsafe class Index : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Index"/> class.
        /// </summary>
        /// <param name="excludeDeclarationsFromPCH">The excludeDeclarationsFromPCH<see cref="bool"/></param>
        /// <param name="displayDiagnostics">The displayDiagnostics<see cref="bool"/></param>
        public Index(bool excludeDeclarationsFromPCH, bool displayDiagnostics)
        {
            this.m_value = clang.clang_createIndex(excludeDeclarationsFromPCH ? 1 : 0, excludeDeclarationsFromPCH ? 1 : 0);
        }

        /// <summary>
        /// Defines the _globalOptFlags
        /// </summary>
        private CXGlobalOptFlags _globalOptFlags;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets or sets the GlobalOptFlags
        /// </summary>
        public CXGlobalOptFlags GlobalOptFlags
        {
            get { return _globalOptFlags = (CXGlobalOptFlags)clang.clang_CXIndex_getGlobalOptions(this.m_value); }
            set
            {

                _globalOptFlags = value;
                clang.clang_CXIndex_setGlobalOptions(this.m_value, (uint)value);
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
        /// The CreateTranslationUnit
        /// </summary>
        /// <param name="astFileName">The astFileName<see cref="string"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public TranslationUnit CreateTranslationUnit(string astFileName)
        {
            IntPtr pTranslationUnit = clang.clang_createTranslationUnit(this.m_value, astFileName);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The CreateTranslationUnit
        /// </summary>
        /// <param name="astFileName">The astFileName<see cref="string"/></param>
        /// <param name="errorCode">The errorCode<see cref="CXErrorCode"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public TranslationUnit CreateTranslationUnit(string astFileName, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            errorCode = clang.clang_createTranslationUnit2(this.m_value, astFileName, out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The CreateTranslationUnit
        /// </summary>
        /// <param name="sourceFileName">The sourceFileName<see cref="string"/></param>
        /// <param name="commandLineArgs">The cmdArgs<see cref="string[]"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public TranslationUnit CreateTranslationUnit(string sourceFileName, string[] commandLineArgs, UnsavedFile[] unsavedFiles)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            string[] commandLineArgsArray = commandLineArgs;
            UnsavedFile[] unsavedFilesArray = unsavedFiles;
            if (commandLineArgsArray == null)
            {
                commandLineArgsArray = new string[0];
            }
            if (unsavedFilesArray == null)
            {
                unsavedFilesArray = new UnsavedFile[0];
            }
            pTranslationUnit = clang.clang_createTranslationUnitFromSourceFile(this.m_value,
                sourceFileName,
                commandLineArgsArray.Length,
                commandLineArgsArray,
                (uint)unsavedFilesArray.Length,
                unsavedFilesArray.Select(x => (CXUnsavedFile)x.Value).ToArray());
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The Parse
        /// </summary>
        /// <param name="sourceFileName">The sourceFileName<see cref="string"/></param>
        /// <param name="flags">The globalOptFlags<see cref="CXGlobalOptFlags"/></param>
        /// <param name="commandLineArgs">The commandLineArgs<see cref="string[]"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public unsafe TranslationUnit Parse(string sourceFileName, string[] commandLineArgs, UnsavedFile[] unsavedFiles, CXTranslationUnit_Flags flags)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            string[] commandLineArgsArray = commandLineArgs;
            UnsavedFile[] unsavedFilesArray = unsavedFiles;
            if (commandLineArgsArray == null)
            {
                commandLineArgsArray = new string[0];
            }
            if (unsavedFilesArray == null)
            {
                unsavedFilesArray = new UnsavedFile[0];
            }
            pTranslationUnit = clang.clang_parseTranslationUnit(this.m_value,
                sourceFileName,
                commandLineArgsArray,
                commandLineArgsArray.Length,
                unsavedFilesArray.Select(x => (CXUnsavedFile)x.Value).ToArray(),
                (uint)unsavedFilesArray.Length,
                (uint)flags);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The Parse
        /// </summary>
        /// <param name="sourceFileName">The sourceFileName<see cref="string"/></param>
        /// <param name="globalOptFlags">The globalOptFlags<see cref="CXGlobalOptFlags"/></param>
        /// <param name="commandLineArgs">The commandLineArgs<see cref="string[]"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <param name="errorCode">The errorCode<see cref="CXErrorCode"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public TranslationUnit Parse(string sourceFileName, string[] commandLineArgs, UnsavedFile[] unsavedFiles, CXTranslationUnit_Flags globalOptFlags, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            string[] commandLineArgsArray = commandLineArgs;
            UnsavedFile[] unsavedFilesArray = unsavedFiles;
            if (commandLineArgsArray == null)
            {
                commandLineArgsArray = new string[0];
            }
            if (unsavedFilesArray == null)
            {
                unsavedFilesArray = new UnsavedFile[0];
            }
            errorCode = clang.clang_parseTranslationUnit2(this.m_value,
                sourceFileName,
                commandLineArgsArray,
                commandLineArgsArray.Length,
                unsavedFilesArray.Select(x => (CXUnsavedFile)x.Value).ToArray(),
                (uint)unsavedFilesArray.Length,
                (uint)globalOptFlags,
                out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The ParseWithFullArguments
        /// </summary>
        /// <param name="sourceFileName">The sourceFileName<see cref="string"/></param>
        /// <param name="globalOptFlags">The globalOptFlags<see cref="CXGlobalOptFlags"/></param>
        /// <param name="commandLineArgs">The commandLineArgs<see cref="string[]"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <param name="errorCode">The errorCode<see cref="CXErrorCode"/></param>
        /// <returns>The <see cref="TranslationUnit"/></returns>
        public TranslationUnit Parse(string sourceFileName,string clangExecutablePath, string[] commandLineArgs, UnsavedFile[] unsavedFiles, CXTranslationUnit_Flags globalOptFlags, out CXErrorCode errorCode)
        {
            IntPtr pTranslationUnit = IntPtr.Zero;
            string[] commandLineArgsArray = commandLineArgs;
            UnsavedFile[] unsavedFilesArray = unsavedFiles;
            if (string.IsNullOrEmpty(clangExecutablePath) || string.IsNullOrWhiteSpace(clangExecutablePath))
            {
                errorCode = CXErrorCode.CXError_InvalidArguments;
                return null;
            }
            if (commandLineArgsArray == null || commandLineArgsArray.Length == 0)
            {
                commandLineArgsArray = new string[1] {
                    clangExecutablePath
                };
            }
            else
            {
                commandLineArgsArray = Array.CreateInstance(typeof(string), 1 + commandLineArgs.Length) as string[];
                commandLineArgsArray[0] = clangExecutablePath;
                Array.Copy(commandLineArgs, 0, commandLineArgsArray, 1, commandLineArgs.Length);
            }
            if (unsavedFilesArray == null)
            {
                unsavedFilesArray = new UnsavedFile[0];
            }
            errorCode = clang.clang_parseTranslationUnit2FullArgv(this.m_value,
                sourceFileName,
                commandLineArgsArray,
                commandLineArgsArray.Length,
                unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(),
                (uint)unsavedFiles.Length,
                (uint)globalOptFlags,
                out pTranslationUnit);
            if (pTranslationUnit == IntPtr.Zero)
            {
                return null;
            }
            return new TranslationUnit(pTranslationUnit);
        }

        /// <summary>
        /// The CreateIndexAction
        /// </summary>
        /// <param name="indexActionEventHandler">The indexActionEventHandler<see cref="IIndexActionEventHandler"/></param>
        /// <returns>The <see cref="IndexAction"/></returns>
        public IndexAction CreateIndexAction(IIndexActionEventHandler indexActionEventHandler)
        {
            IntPtr pIndexAction = clang.clang_IndexAction_create(this.m_value);
            if (pIndexAction == IntPtr.Zero)
            {
                return null;
            }
            return new IndexAction(indexActionEventHandler, pIndexAction);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_disposeIndex(this.m_value);
        }
    }
}
