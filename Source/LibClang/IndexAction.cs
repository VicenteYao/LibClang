using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public   class IndexAction : ClangObject<IntPtr>
    {
        internal IndexAction(IIndexActionEventHandler indexActionEventHandler, IntPtr value)
        {
            this.indexActionEventHandler = indexActionEventHandler;
            this.Value = value;
            EnsureCallbacks();
        }

        private IIndexActionEventHandler indexActionEventHandler;

        private unsafe void EnsureCallbacks()
        {
            indexerCallbacks.abortQuery = Marshal.GetFunctionPointerForDelegate(new abortQuery((clientData, reserve) =>
            {
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                this.indexActionEventHandler.OnQueryContinue(cancelEventArgs);
                if (cancelEventArgs.Cancel)
                {
                    return 0;
                }
                return 1;
            }));
            indexerCallbacks.diagnostic = Marshal.GetFunctionPointerForDelegate(new diagnostic((clientData, diagnostic, reserve) =>
            {
                DiagnosticSet diagnostics = new DiagnosticSet(diagnostic);
                this.indexActionEventHandler.OnDiagnostic(diagnostics);
            }));

            indexerCallbacks.enteredMainFile = Marshal.GetFunctionPointerForDelegate(new enteredMainFile((clientFile, cxFile, reserve) =>
            {
                File file = new File(cxFile);
                File result = this.indexActionEventHandler.OnEnteredMainFile(file);
                return result == null ? IntPtr.Zero : result.Value;
            }));

            indexerCallbacks.importedASTFile = Marshal.GetFunctionPointerForDelegate(new importedASTFile((clientData, reserve) =>
            {
                return IntPtr.Zero;
            }));

            indexerCallbacks.includedFile = Marshal.GetFunctionPointerForDelegate(new ppIncludedFile((clientData, fileInfo) =>
            {
                CXIdxIncludedFileInfo* cXIdxIncludedFileInfo = (CXIdxIncludedFileInfo*)fileInfo;
                IndexIncludedFileInfo indexIncludedFileInfo = new IndexIncludedFileInfo(cXIdxIncludedFileInfo);
                File result = this.indexActionEventHandler.OnIncludeFile(indexIncludedFileInfo);
                return result == null ? IntPtr.Zero : result.Value;
            }));

            indexerCallbacks.indexDeclaration = Marshal.GetFunctionPointerForDelegate(new indexDeclaration((clientData, declInfo) =>
             {
                 CXIdxDeclInfo* pIndexDeclInfo = (CXIdxDeclInfo*)declInfo;
                 IndexDeclInfo indexDeclInfo = new IndexDeclInfo(*pIndexDeclInfo);
                 this.indexActionEventHandler.OnIndexDeclaration(indexDeclInfo);
             }));

            indexerCallbacks.indexEntityReference = Marshal.GetFunctionPointerForDelegate(new indexEntityReference((clientData, refInfo) =>
             {
                 CXIdxEntityRefInfo* pIndexEntityRefInfo = (CXIdxEntityRefInfo*)refInfo;
                 IndexEntityRefInfo indexEntityRefInfo = new IndexEntityRefInfo(*pIndexEntityRefInfo);
                 this.indexActionEventHandler.OnIndexEntityRefInfo(indexEntityRefInfo);
             }));
            indexerCallbacks.startedTranslationUnit = Marshal.GetFunctionPointerForDelegate(new startedTranslationUnit((clientData, reserved) =>
            {
                
                return IntPtr.Zero;
            }));
        }

        IndexerCallbacks indexerCallbacks = default(IndexerCallbacks);





        protected override void Dispose()
        {
            clang.clang_IndexAction_dispose(this.Value);
        }

        public unsafe void Index(TranslationUnit translationUnit, CXIndexOptFlags indexOptFlags)
        {
            int callbackSize = (int)Marshal.SizeOf(typeof(IndexerCallbacks));
            IndexerCallbacks * pIndexerCallbacks = (IndexerCallbacks*)Marshal.AllocHGlobal(callbackSize);
            Marshal.StructureToPtr(indexerCallbacks, (IntPtr)pIndexerCallbacks, false);
            clang.clang_indexTranslationUnit(this.Value, IntPtr.Zero, (IntPtr)pIndexerCallbacks, (uint)callbackSize, (uint)indexOptFlags, translationUnit.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
