using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;
using System.Linq;

namespace LibClang
{
    public   class IndexAction : ClangObject<IntPtr>
    {
        internal IndexAction(IIndexActionEventHandler indexActionEventHandler, IntPtr value)
        {
            this._indexActionEventHandler = indexActionEventHandler;
            this.Value = value;
            EnsureCallbacks();
        }
        private IndexerCallbacks _indexerCallbacks = default(IndexerCallbacks);
        private IIndexActionEventHandler _indexActionEventHandler;

        private unsafe void EnsureCallbacks()
        {
           this._indexerCallbacks.abortQuery = Marshal.GetFunctionPointerForDelegate(new abortQuery((clientData, reserve) =>
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                this._indexActionEventHandler?.OnQueryContinue(cancelEventArgs);
                if (!cancelEventArgs.Cancel)
                {
                    return 0;
                }
                return 1;
            }));
            this._indexerCallbacks.diagnostic = Marshal.GetFunctionPointerForDelegate(new diagnostic((clientData, diagnostic, reserve) =>
            {
                DiagnosticSet diagnostics = new DiagnosticSet(diagnostic);
                this._indexActionEventHandler?.OnDiagnostic(diagnostics);
            }));

            this._indexerCallbacks.enteredMainFile = Marshal.GetFunctionPointerForDelegate(new enteredMainFile((clientFile, cxFile, reserve) =>
            {
                File file = new File(cxFile);
                File result = this._indexActionEventHandler?.OnEnteredMainFile(file);
                return result == null ? IntPtr.Zero : result.Value;
            }));

            this._indexerCallbacks.importedASTFile = Marshal.GetFunctionPointerForDelegate(new importedASTFile((clientData, reserve) =>
            {
                return IntPtr.Zero;
            }));

            this._indexerCallbacks.includedFile = Marshal.GetFunctionPointerForDelegate(new ppIncludedFile((clientData, fileInfo) =>
            {
                CXIdxIncludedFileInfo* cXIdxIncludedFileInfo = (CXIdxIncludedFileInfo*)fileInfo;
                IndexIncludedFileInfo indexIncludedFileInfo = new IndexIncludedFileInfo(cXIdxIncludedFileInfo);
                File result = this._indexActionEventHandler?.OnIncludeFile(indexIncludedFileInfo);
                return result == null ? IntPtr.Zero : result.Value;
            }));

            this._indexerCallbacks.indexDeclaration = Marshal.GetFunctionPointerForDelegate(new indexDeclaration((clientData, declInfo) =>
             {
                 CXIdxDeclInfo* pIndexDeclInfo = (CXIdxDeclInfo*)declInfo;
                 IndexDeclInfo indexDeclInfo = new IndexDeclInfo(*pIndexDeclInfo);
                 this._indexActionEventHandler?.OnIndexDeclaration(indexDeclInfo);
             }));

            this._indexerCallbacks.indexEntityReference = Marshal.GetFunctionPointerForDelegate(new indexEntityReference((clientData, refInfo) =>
             {
                 CXIdxEntityRefInfo* pIndexEntityRefInfo = (CXIdxEntityRefInfo*)refInfo;
                 IndexEntityRefInfo indexEntityRefInfo = new IndexEntityRefInfo(*pIndexEntityRefInfo);
                 this._indexActionEventHandler?.OnIndexEntityRefInfo(indexEntityRefInfo);
             }));
            this._indexerCallbacks.startedTranslationUnit = Marshal.GetFunctionPointerForDelegate(new startedTranslationUnit((clientData, reserved) =>
            {
                
                return IntPtr.Zero;
            }));
        }



        protected override void Dispose()
        {
            clang.clang_IndexAction_dispose(this.Value);
        }

        public unsafe bool Index(TranslationUnit translationUnit, CXIndexOptFlags indexOptFlags)
        {
            using (Pointer<IndexerCallbacks> ptrIndexerCallbacks=new Pointer<IndexerCallbacks>(this._indexerCallbacks))
            {
                return clang.clang_indexTranslationUnit(this.Value,
                    IntPtr.Zero,
                    ptrIndexerCallbacks,
                    (uint)(ptrIndexerCallbacks.Size / IntPtr.Size),
                    (uint)indexOptFlags, translationUnit.Value) > 0;
            }
        }

        public void IndexSourceFile(string sourceFile,string[] cmdLineArgs,UnsavedFile[] unsavedFiles,CXIndexOptFlags indexOptFlags,CXTranslationUnit_Flags translationUnit_Flags)
        {
            if (cmdLineArgs==null)
            {
                cmdLineArgs = new string[0];
            }
            if (unsavedFiles==null)
            {
                unsavedFiles = new UnsavedFile[0];
            }
            using (Pointer<IndexerCallbacks> ptrIndexerCallbacks = new Pointer<IndexerCallbacks>(this._indexerCallbacks))
            {
                IntPtr pTU = IntPtr.Zero;
                clang.clang_indexSourceFile(this.Value,
                    IntPtr.Zero,
                    ptrIndexerCallbacks,
                    (uint)(ptrIndexerCallbacks.Size / IntPtr.Size), 
                    (uint)indexOptFlags,
                    sourceFile,
                    cmdLineArgs,
                    cmdLineArgs.Length,
                    unsavedFiles.Select(x => x.Value).ToArray(),
                    (uint)unsavedFiles.Length,
                    out pTU,
                      (uint)translationUnit_Flags
                    );
            }

        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
