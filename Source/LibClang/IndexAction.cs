using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;
using System.Linq;
using System.Runtime.CompilerServices;

namespace LibClang
{
    public   class IndexAction : ClangObject
    {
        internal IndexAction(IIndexActionEventHandler indexActionEventHandler, IntPtr value)
        {
            this._indexActionEventHandler = indexActionEventHandler;
            this.m_value = value;
            this.EnsureCallbacks();
        }
        private IndexerCallbacks _indexerCallbacks = default(IndexerCallbacks);
        private IIndexActionEventHandler _indexActionEventHandler;
        private IntPtr m_value;
        private abortQuery abortQuery;
        private diagnostic diagnostic;
        private enteredMainFile enteredMainFile;
        private importedASTFile importedASTFile;
        private ppIncludedFile ppIncludedFile;
        private indexDeclaration indexDeclaration;
        private indexEntityReference indexEntityReference;
        private startedTranslationUnit startedTranslationUnit;

        protected internal override ValueType Value { get { return this.m_value; } }

        private unsafe void EnsureCallbacks()
        {

            this.abortQuery = new abortQuery(HandleAbortQuery);
            this.diagnostic = new diagnostic(HandleDiagnostic);
            this.enteredMainFile = new enteredMainFile(HandleEnteredMainFile);
            this.importedASTFile = new importedASTFile(HandleImportedASTFile);
            this.ppIncludedFile = new ppIncludedFile(HandlePPIncludedFile);
            this.indexDeclaration = new indexDeclaration(HandleIndexDeclaration);
            this.indexEntityReference = new indexEntityReference(HandleEntityReference);
            this.startedTranslationUnit = new startedTranslationUnit(HandleStartedTranslationUnit);

            this._indexerCallbacks.abortQuery = Marshal.GetFunctionPointerForDelegate(this.abortQuery);
            this._indexerCallbacks.diagnostic = Marshal.GetFunctionPointerForDelegate(this.diagnostic);
            this._indexerCallbacks.enteredMainFile = Marshal.GetFunctionPointerForDelegate(this.enteredMainFile);
            this._indexerCallbacks.importedASTFile = Marshal.GetFunctionPointerForDelegate(this.importedASTFile);
            this._indexerCallbacks.includedFile = Marshal.GetFunctionPointerForDelegate(this.ppIncludedFile);
            this._indexerCallbacks.indexDeclaration = Marshal.GetFunctionPointerForDelegate(this.indexDeclaration);
            this._indexerCallbacks.indexEntityReference = Marshal.GetFunctionPointerForDelegate(this.indexEntityReference);
            this._indexerCallbacks.startedTranslationUnit = Marshal.GetFunctionPointerForDelegate(this.startedTranslationUnit);
        }

        private IntPtr HandleStartedTranslationUnit(IntPtr client_data, IntPtr reserved)
        {
            this._indexActionEventHandler?.OnStartTranslationUnit();
            return IntPtr.Zero;
        }

        private unsafe void HandleEntityReference(IntPtr client_data, IntPtr refInfo)
        {
            CXIdxEntityRefInfo* pIndexEntityRefInfo = (CXIdxEntityRefInfo*)refInfo;
            using (IndexEntityRefInfo indexEntityRefInfo = new IndexEntityRefInfo(*pIndexEntityRefInfo))
            {
                this._indexActionEventHandler?.OnIndexEntityRefInfo(indexEntityRefInfo);
            }
        }

        private unsafe void HandleIndexDeclaration(IntPtr client_data, IntPtr declInfo)
        {
            CXIdxDeclInfo* pIndexDeclInfo = (CXIdxDeclInfo*)declInfo;
            IndexDeclInfo indexDeclInfo = new IndexDeclInfo(*pIndexDeclInfo);
            this._indexActionEventHandler?.OnIndexDeclaration(indexDeclInfo);
        }

        private unsafe IntPtr HandlePPIncludedFile(IntPtr client_data, IntPtr fileInfo)
        {
            CXIdxIncludedFileInfo* cXIdxIncludedFileInfo = (CXIdxIncludedFileInfo*)fileInfo;
            IndexIncludedFileInfo indexIncludedFileInfo = new IndexIncludedFileInfo(cXIdxIncludedFileInfo);
            File result = this._indexActionEventHandler?.OnIncludeFile(indexIncludedFileInfo);
            return result == null ? IntPtr.Zero : (IntPtr)result.Value;
        }

        private IntPtr HandleImportedASTFile(IntPtr client_data, IntPtr fileInfo)
        {
            return IntPtr.Zero;
        }

        private IntPtr HandleEnteredMainFile(IntPtr client_data, IntPtr mainFile, IntPtr reserved)
        {
            using (File file = new File(mainFile))
            {
                File result = this._indexActionEventHandler?.OnEnteredMainFile(file);
                return result == null ? IntPtr.Zero : (IntPtr)result.Value;
            }
        }

        private void HandleDiagnostic(IntPtr client_data, IntPtr set, IntPtr reserved)
        {
            using (DiagnosticSet diagnostics = new DiagnosticSet(set))
            {
                this._indexActionEventHandler?.OnDiagnostic(diagnostics);
            }
        }

        private int HandleAbortQuery(IntPtr client_data, IntPtr reserved)
        {
            if (this._indexActionEventHandler != null)
            {
                return this._indexActionEventHandler.OnQueryAbort() ? 1 : 0;
            }
            return 1;
        }

        protected override void Dispose()
        {
            clang.clang_IndexAction_dispose(this.m_value);
        }

        public unsafe CXErrorCode Index(TranslationUnit translationUnit, CXIndexOptFlags indexOptFlags)
        {
            using (Pointer<IndexerCallbacks> ptrIndexerCallbacks = new Pointer<IndexerCallbacks>(this._indexerCallbacks))
            {
                CXErrorCode errorCode = (CXErrorCode)clang.clang_indexTranslationUnit(this.m_value,
                    IntPtr.Zero,
                    ptrIndexerCallbacks,
                    (uint)(ptrIndexerCallbacks.Size),
                    (uint)indexOptFlags, (IntPtr)translationUnit.Value);
                return errorCode;
            }
        }

        public CXErrorCode IndexSourceFile(string sourceFile, out TranslationUnit translationUnit, string[] cmdLineArgs, UnsavedFile[] unsavedFiles, CXIndexOptFlags indexOptFlags, CXTranslationUnit_Flags translationUnit_Flags)
        {
            translationUnit = null;
            if (cmdLineArgs == null)
            {
                cmdLineArgs = new string[0];
            }
            if (unsavedFiles == null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            using (Pointer<IndexerCallbacks> ptrIndexerCallbacks = new Pointer<IndexerCallbacks>(this._indexerCallbacks))
            {
                IntPtr pTU = IntPtr.Zero;
                CXErrorCode errorCode = (CXErrorCode)clang.clang_indexSourceFile(this.m_value,
                     IntPtr.Zero,
                     ptrIndexerCallbacks,
                     (uint)(ptrIndexerCallbacks.Size),
                     (uint)indexOptFlags,
                     sourceFile,
                     cmdLineArgs,
                     cmdLineArgs.Length,
                     unsavedFiles.Select(x => (CXUnsavedFile)x.Value).ToArray(),
                     (uint)unsavedFiles.Length,
                     out pTU,
                       (uint)translationUnit_Flags
                     );
                if (pTU != IntPtr.Zero)
                {
                    translationUnit = new TranslationUnit(pTU);
                }
                return errorCode;
            }
        }

    }
}
