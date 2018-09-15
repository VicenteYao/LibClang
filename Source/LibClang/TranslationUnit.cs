namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="TranslationUnit" />
    /// </summary>
    public class TranslationUnit : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationUnit"/> class.
        /// </summary>
        /// <param name="pTranlationUnit">The pTranlationUnit<see cref="IntPtr"/></param>
        internal TranslationUnit(IntPtr pTranlationUnit)
        {
            this.m_value = pTranlationUnit;
        }

        /// <summary>
        /// The CodeCompleteAt
        /// </summary>
        /// <param name="completeFileName">The completeFileName<see cref="string"/></param>
        /// <param name="completeline">The completeline<see cref="uint"/></param>
        /// <param name="completeColumn">The completeColumn<see cref="uint"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <param name="flags">The flags<see cref="CXCodeComplete_Flags"/></param>
        /// <returns>The <see cref="CodeCompleteResults"/></returns>
        public unsafe CodeCompleteResults CodeCompleteAt(string completeFileName, uint completeline, uint completeColumn, UnsavedFile[] unsavedFiles, CXCodeComplete_Flags flags)
        {
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            CXCodeCompleteResults* pCodeComplete = clang.clang_codeCompleteAt(this.m_value, completeFileName, completeline, completeColumn, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)flags);
            return new CodeCompleteResults((CXCodeCompleteResults*)pCodeComplete);
        }

        /// <summary>
        /// The Suspend
        /// </summary>
        public void Suspend()
        {
            clang.clang_suspendTranslationUnit(this.m_value);
        }

        /// <summary>
        /// Defines the _defaultSaveFlags
        /// </summary>
        private CXSaveTranslationUnit_Flags? _defaultSaveFlags;

        /// <summary>
        /// Gets the DefaultSaveFlags
        /// </summary>
        public CXSaveTranslationUnit_Flags DefaultSaveFlags
        {
            get
            {
                if (!this._defaultSaveFlags.HasValue)
                {
                    this._defaultSaveFlags = (CXSaveTranslationUnit_Flags)clang.clang_defaultSaveOptions(this.m_value);
                }
                return this._defaultSaveFlags.Value;
            }
        }



        /// <summary>
        /// Defines the _resourceUsages
        /// </summary>
        private TranslationUnitResourceUsages _resourceUsages;

        /// <summary>
        /// Gets the ResourceUsages
        /// </summary>
        public TranslationUnitResourceUsages ResourceUsages
        {
            get
            {
                CXTUResourceUsage cXTUResourceUsage;
                cXTUResourceUsage = clang.clang_getCXTUResourceUsage(this.m_value);
                this._resourceUsages = new TranslationUnitResourceUsages(cXTUResourceUsage);
                return this._resourceUsages;
            }
        }

        /// <summary>
        /// The FindIncludesInFile
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <param name="searchFunc">The searchFunc<see cref="Func{Cursor, SourceRange, bool}"/></param>
        /// <returns>The <see cref="CXResult"/></returns>
        public CXResult FindIncludesInFile(File file, Func<Cursor, SourceRange, bool> searchFunc)
        {
            CXCursorAndRangeVisitor cursorAndRangeVisitor = default(CXCursorAndRangeVisitor);
            cursorAndRangeVisitor.Visit = Marshal.GetFunctionPointerForDelegate(new visit((context, cxCursor, cxRange) =>
            {
                if (searchFunc != null)
                {
                    Cursor cursor = new Cursor(cxCursor);
                    SourceRange sourceRange = new SourceRange(cxRange);
                    bool result = searchFunc(cursor, sourceRange);
                    return result ? CXVisitorResult.CXVisit_Continue : CXVisitorResult.CXVisit_Break;
                }
                return CXVisitorResult.CXVisit_Break;
            }));
            return clang.clang_findIncludesInFile(this.m_value, (IntPtr)file.Value, cursorAndRangeVisitor);
        }

        /// <summary>
        /// Defines the _defaultReparseFlags
        /// </summary>
        private CXReparse_Flags _defaultReparseFlags;

        /// <summary>
        /// Gets the DefaultReparseFlags
        /// </summary>
        public CXReparse_Flags DefaultReparseFlags
        {
            get
            {

                this._defaultReparseFlags = (CXReparse_Flags)clang.clang_defaultReparseOptions(this.m_value);
                return this._defaultReparseFlags;
            }
        }

        /// <summary>
        /// The Reparse
        /// </summary>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <param name="reparseFlags">The reparseFlags<see cref="CXReparse_Flags"/></param>
        public void Reparse(UnsavedFile[] unsavedFiles, CXReparse_Flags reparseFlags)
        {
            clang.clang_reparseTranslationUnit(this.m_value, (uint)unsavedFiles.Length, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)reparseFlags);
        }

        /// <summary>
        /// The Save
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <param name="saveTranslationUnit_Flags">The saveTranslationUnit_Flags<see cref="CXSaveTranslationUnit_Flags"/></param>
        public void Save(string fileName, CXSaveTranslationUnit_Flags saveTranslationUnit_Flags)
        {
            clang.clang_saveTranslationUnit(this.m_value, fileName, (uint)saveTranslationUnit_Flags);
        }

        /// <summary>
        /// Defines the _spelling
        /// </summary>
        private string _spelling;

        /// <summary>
        /// Gets the Spelling
        /// </summary>
        public string Spelling
        {
            get
            {
                if (this._spelling == null)
                {
                    this._spelling = clang.clang_getTranslationUnitSpelling(this.m_value).ToStringAndDispose();
                }
                return this._spelling;
            }
        }

        /// <summary>
        /// Defines the _cursor
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// Gets the Cursor
        /// </summary>
        public Cursor Cursor
        {
            get
            {
                CXCursor cursor = clang.clang_getTranslationUnitCursor(this.m_value);
                this._cursor = new Cursor(cursor);
                return this._cursor;
            }
        }

        /// <summary>
        /// Defines the _targetInfo
        /// </summary>
        private TargetInfo _targetInfo;

        /// <summary>
        /// Gets the TargetInfo
        /// </summary>
        public TargetInfo TargetInfo
        {
            get
            {
                if (this._targetInfo == null)
                {
                    IntPtr value = clang.clang_getTranslationUnitTargetInfo(this.m_value);
                    if (value != IntPtr.Zero)
                    {
                        this._targetInfo = new TargetInfo(value);
                    }
                }
                return this._targetInfo;
            }
        }

        /// <summary>
        /// Defines the _diagnostics
        /// </summary>
        private Diagnostic[] _diagnostics;

        /// <summary>
        /// Gets the Diagnostics
        /// </summary>
        public Diagnostic[] Diagnostics
        {
            get
            {
                if (_diagnostics == null)
                {
                    uint diagnosticCount = clang.clang_getNumDiagnostics(this.m_value);
                    this._diagnostics = new Diagnostic[diagnosticCount];
                    for (uint i = 0; i < diagnosticCount; i++)
                    {
                        this._diagnostics[i] = new Diagnostic(clang.clang_getDiagnostic(this.m_value, i));
                    }
                }
                return this._diagnostics;
            }
        }

        /// <summary>
        /// Defines the _diagnosticSet
        /// </summary>
        private DiagnosticSet _diagnosticSet;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the DiagnosticSet
        /// </summary>
        public DiagnosticSet DiagnosticSet
        {
            get
            {

                if (this._diagnosticSet == null)
                {
                    this._diagnosticSet = new DiagnosticSet(clang.clang_getDiagnosticSetFromTU(this.m_value));
                }
                return this._diagnosticSet;
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
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_disposeTranslationUnit(this.m_value);
        }

        /// <summary>
        /// The Tokenize
        /// </summary>
        /// <param name="sourceRange">The sourceRange<see cref="SourceRange"/></param>
        /// <returns>The <see cref="TokenList"/></returns>
        public unsafe TokenList Tokenize(SourceRange sourceRange)
        {
            CXToken* pToken = null;
            uint tokenCount = 0;
            clang.clang_tokenize(this.m_value, (CXSourceRange)sourceRange.Value, out pToken, out tokenCount);
            return new TokenList(this, pToken, (int)tokenCount);
        }

        /// <summary>
        /// The AnnotateTokens
        /// </summary>
        /// <param name="tokens">The tokens<see cref="Token[]"/></param>
        /// <param name="cursors">The cursors<see cref="Cursor[]"/></param>
        public void AnnotateTokens(Token[] tokens, Cursor[] cursors)
        {
            if (tokens == null || tokens.Length == 0 || cursors.Length == 0)
            {
                return;
            }
            clang.clang_annotateTokens(this.m_value, tokens.Select(x => (CXToken)x.Value).ToArray(), (uint)tokens.Length, cursors.Select(x => (CXCursor)x.Value).ToArray());
        }

        /// <summary>
        /// The GetCursor
        /// </summary>
        /// <param name="sourceLocation">The sourceLocation<see cref="SourceLocation"/></param>
        /// <returns>The <see cref="Cursor"/></returns>
        public Cursor GetCursor(SourceLocation sourceLocation)
        {
            return new Cursor(clang.clang_getCursor(this.m_value, (CXSourceLocation)sourceLocation.Value));
        }

        /// <summary>
        /// The GetSourceLocation
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        /// <returns>The <see cref="SourceLocation"/></returns>
        public SourceLocation GetSourceLocation(File file, uint line, uint column)
        {
            return new SourceLocation(clang.clang_getLocation(this.m_value, (IntPtr)file.Value, line, column));
        }

        /// <summary>
        /// The GetSourceLocation
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <param name="offset">The offset<see cref="uint"/></param>
        /// <returns>The <see cref="SourceLocation"/></returns>
        public SourceLocation GetSourceLocation(File file, uint offset)
        {
            return new SourceLocation(clang.clang_getLocationForOffset(this.m_value, (IntPtr)file.Value, offset));
        }

        /// <summary>
        /// The GetSourceRange
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <param name="beginLine">The beginLine<see cref="uint"/></param>
        /// <param name="beginColumn">The beginColumn<see cref="uint"/></param>
        /// <param name="endLine">The endLine<see cref="uint"/></param>
        /// <param name="endColumn">The endColumn<see cref="uint"/></param>
        /// <returns>The <see cref="SourceRange"/></returns>
        public SourceRange GetSourceRange(File file, uint beginLine, uint beginColumn, uint endLine, uint endColumn)
        {
            var begin = this.GetSourceLocation(file, beginLine, beginColumn);
            var end = this.GetSourceLocation(file, endLine, endColumn);
            return new SourceRange(begin, end);
        }

        /// <summary>
        /// The GetSourceRange
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <returns>The <see cref="SourceRange"/></returns>
        public SourceRange GetSourceRange(File file)
        {
            var begin = this.GetSourceLocation(file, 1, 1);
            var end = this.GetSourceLocation(file, (uint)file.Lines.Length, (uint)file.Lines[file.Lines.Length - 1].Length);
            return new SourceRange(begin, end);
        }

        /// <summary>
        /// The GetFile
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <returns>The <see cref="File"/></returns>
        public File GetFile(string fileName)
        {
            IntPtr pFile = clang.clang_getFile(this.m_value, fileName);
            if (pFile == IntPtr.Zero)
            {
                return null;
            }
            File file = new File(pFile);
            return file;
        }

        /// <summary>
        /// The GetFileContents
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <returns>The <see cref="string"/></returns>
        public unsafe string GetFileContents(File file)
        {
            uint size = 0;
            string contents = new string((sbyte*)clang.clang_getFileContents(this.m_value, (IntPtr)file.Value, out size), 0, (int)size);
            return contents;
        }

        /// <summary>
        /// The GetModule
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <returns>The <see cref="Module"/></returns>
        public Module GetModule(File file)
        {
            IntPtr pModule = clang.clang_getModuleForFile(this.m_value, (IntPtr)file.Value);
            if (pModule == IntPtr.Zero)
            {
                return null;
            }
            Module module = new Module(pModule);
            return module;
        }

        /// <summary>
        /// The GetTopLeverHeaders
        /// </summary>
        /// <param name="module">The module<see cref="Module"/></param>
        /// <returns>The <see cref="File[]"/></returns>
        public File[] GetTopLeverHeaders(Module module)
        {
            uint topleverHeadersCount = clang.clang_Module_getNumTopLevelHeaders(this.m_value, (IntPtr)module.Value);
            File[] topleverHeaders = new File[topleverHeadersCount];
            for (uint i = 0; i < topleverHeadersCount; i++)
            {
                topleverHeaders[i] = new File(clang.clang_Module_getTopLevelHeader(this.m_value, (IntPtr)module.Value, i));
            }
            return topleverHeaders;
        }

        /// <summary>
        /// Defines the <see cref="SourceRangeListObject" />
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private unsafe class SourceRangeListObject
        {
            /// <summary>
            /// Defines the count
            /// </summary>
            public uint count;

            /// <summary>
            /// Defines the ranges
            /// </summary>
            public CXSourceRange* ranges;
        }

        /// <summary>
        /// The GetSkippedRanges
        /// </summary>
        /// <param name="file">The file<see cref="File"/></param>
        /// <returns>The <see cref="SourceRangeList"/></returns>
        public unsafe SourceRangeList GetSkippedRanges(File file)
        {
            IntPtr pRangeList = clang.clang_getSkippedRanges(this.m_value, (IntPtr)file.Value);
            if (pRangeList == IntPtr.Zero)
            {
                return null;
            }
            CXSourceRangeList* pCXSourceRangeList = (CXSourceRangeList*)pRangeList;
            return new SourceRangeList(*pCXSourceRangeList);
        }

        /// <summary>
        /// The GetAllSkippedRanges
        /// </summary>
        /// <returns>The <see cref="SourceRangeList"/></returns>
        public unsafe SourceRangeList GetAllSkippedRanges()
        {
            IntPtr pRangeList = clang.clang_getAllSkippedRanges(this.m_value);
            if (pRangeList == IntPtr.Zero)
            {
                return null;
            }
            CXSourceRangeList* pCXSourceRangeList = (CXSourceRangeList*)pRangeList;
            return new SourceRangeList(*pCXSourceRangeList);
        }
    }
}
