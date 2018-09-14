using LibClang.Intertop;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LibClang
{
    public class TranslationUnit : ClangObject
    {
        internal TranslationUnit(IntPtr pTranlationUnit)
        {
            this.m_value = pTranlationUnit;
        }

        public unsafe CodeCompleteResults CodeCompleteAt(string completeFileName, uint completeline, uint completeColumn, UnsavedFile[] unsavedFiles, CXCodeComplete_Flags flags)
        {
            if (unsavedFiles==null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            CXCodeCompleteResults* pCodeComplete = clang.clang_codeCompleteAt(this.m_value, completeFileName, completeline, completeColumn, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)unsavedFiles.Length, (uint)flags);
            return new CodeCompleteResults((CXCodeCompleteResults*)pCodeComplete);
        }

        public void Suspend()
        {
            clang.clang_suspendTranslationUnit(this.m_value);
        }

        private CXSaveTranslationUnit_Flags? _defaultSaveFlags;
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

        private TranslationUnitResourceUsages _resourceUsages;
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

        private CXReparse_Flags _defaultReparseFlags;
        public CXReparse_Flags DefaultReparseFlags
        {
            get
            {

                this._defaultReparseFlags = (CXReparse_Flags)clang.clang_defaultReparseOptions(this.m_value);
                return this._defaultReparseFlags;
            }
        }


        public void Reparse(UnsavedFile[] unsavedFiles, CXReparse_Flags reparseFlags)
        {
            clang.clang_reparseTranslationUnit(this.m_value, (uint)unsavedFiles.Length, unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(), (uint)reparseFlags);
        }

        public void Save(string fileName,CXSaveTranslationUnit_Flags saveTranslationUnit_Flags)
        {
            clang.clang_saveTranslationUnit(this.m_value, fileName, (uint)saveTranslationUnit_Flags);
        }

        private string _spelling;
        public string Spelling
        {
            get
            {
                if (this._spelling==null)
                {
                    this._spelling = clang.clang_getTranslationUnitSpelling(this.m_value).ToStringAndDispose();
                }
                return this._spelling;
            }
        }

        private Cursor _cursor;

        public Cursor Cursor
        {
            get
            {
                CXCursor cursor = clang.clang_getTranslationUnitCursor(this.m_value);
                this._cursor = new Cursor(cursor);
                return this._cursor;
            }
        }

        private TargetInfo _targetInfo;
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

        private Diagnostic[] _diagnostics;
        public Diagnostic[] Diagnostics
        {
            get
            {
                if (_diagnostics==null)
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

        private DiagnosticSet _diagnosticSet;
        private IntPtr m_value;

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

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override void Dispose()
        {
            clang.clang_disposeTranslationUnit(this.m_value);
        }

        public unsafe TokenList Tokenize(SourceRange sourceRange)
        {
            CXToken* pToken = null;
            uint tokenCount = 0;
            clang.clang_tokenize(this.m_value, (CXSourceRange)sourceRange.Value, out pToken, out tokenCount);
            return new TokenList(this, pToken, (int)tokenCount);
        }

        public void AnnotateTokens(Token[] tokens, Cursor[] cursors)
        {
            if (tokens == null || tokens.Length == 0 || cursors.Length == 0)
            {
                return;
            }
            clang.clang_annotateTokens(this.m_value, tokens.Select(x => (CXToken)x.Value).ToArray(), (uint)tokens.Length, cursors.Select(x => (CXCursor)x.Value).ToArray());
        }

        public Cursor GetCursor(SourceLocation sourceLocation)
        {
            return new Cursor(clang.clang_getCursor(this.m_value, (CXSourceLocation)sourceLocation.Value));
        }

        public SourceLocation GetSourceLocation(File file, uint line, uint column)
        {
            return new SourceLocation(clang.clang_getLocation(this.m_value, (IntPtr)file.Value, line, column));
        }

        public SourceLocation GetSourceLocation(File file, uint offset)
        {
            return new SourceLocation(clang.clang_getLocationForOffset(this.m_value, (IntPtr)file.Value, offset));
        }

        public SourceRange GetSourceRange(File file, uint beginLine, uint beginColumn, uint endLine, uint endColumn)
        {
            var begin = this.GetSourceLocation(file, beginLine, beginColumn);
            var end = this.GetSourceLocation(file, endLine, endColumn);
            return new SourceRange(begin, end);
        }

        public SourceRange GetSourceRange(File file)
        {
            var begin = this.GetSourceLocation(file, 1, 1);
            var end = this.GetSourceLocation(file, (uint)file.Lines.Length, (uint)file.Lines[file.Lines.Length - 1].Length);
            return new SourceRange(begin, end);
        }

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

        public unsafe string GetFileContents(File file)
        {
            uint size = 0;
            string contents = new string(clang.clang_getFileContents(this.m_value, (IntPtr)file.Value, out size), 0, (int)size);
            return contents;
        }

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

        [StructLayout(LayoutKind.Sequential)]
        private unsafe class SourceRangeListObject
        {
            public uint count;
            public CXSourceRange* ranges;
        }

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
