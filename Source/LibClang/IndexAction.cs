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
                if (this._indexActionEventHandler!=null)
                {
                    return this._indexActionEventHandler.OnQueryAbort() ? 1 : 0;
                }
                return 1;
            }));
            this._indexerCallbacks.diagnostic = Marshal.GetFunctionPointerForDelegate(new diagnostic((clientData, diagnostic, reserve) =>
            {
                using (DiagnosticSet diagnostics = new DiagnosticSet(diagnostic))
                {
                    this._indexActionEventHandler?.OnDiagnostic(diagnostics);
                }  
            }));

            this._indexerCallbacks.enteredMainFile = Marshal.GetFunctionPointerForDelegate(new enteredMainFile((clientFile, cxFile, reserve) =>
            {
                using (File file = new File(cxFile))
                {
                    File result = this._indexActionEventHandler?.OnEnteredMainFile(file);

                    return result == null ? IntPtr.Zero : result.Value;
                }
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
                 //CXIdxDeclInfo* pIndexDeclInfo = (CXIdxDeclInfo*)declInfo;
                 //IndexDeclInfo indexDeclInfo = new IndexDeclInfo(*pIndexDeclInfo);
                 //this._indexActionEventHandler?.OnIndexDeclaration(indexDeclInfo);
             }));

            this._indexerCallbacks.indexEntityReference = Marshal.GetFunctionPointerForDelegate(new indexEntityReference((clientData, refInfo) =>
             {
                 CXIdxEntityRefInfo* pIndexEntityRefInfo = (CXIdxEntityRefInfo*)refInfo;
                 CXIdxEntityRefInfo  copy= new CXIdxEntityRefInfo();
                 copy.container = pIndexEntityRefInfo->container;
                 copy.cursor = pIndexEntityRefInfo->cursor;
                 copy.kind = pIndexEntityRefInfo->kind;
                 copy.loc = pIndexEntityRefInfo->loc;
                 copy.parentEntity = pIndexEntityRefInfo->parentEntity;
                 copy.referencedEntity = pIndexEntityRefInfo->referencedEntity;
                 copy.role = pIndexEntityRefInfo->role;
                 IndexEntityRefInfo indexEntityRefInfo = new IndexEntityRefInfo(copy);
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
                    (uint)(ptrIndexerCallbacks.Size),
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
                    (uint)(ptrIndexerCallbacks.Size), 
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
