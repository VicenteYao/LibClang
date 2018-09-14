namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="IndexAction" />
    /// </summary>
    public class IndexAction : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexAction"/> class.
        /// </summary>
        /// <param name="indexActionEventHandler">The indexActionEventHandler<see cref="IIndexActionEventHandler"/></param>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal IndexAction(IIndexActionEventHandler indexActionEventHandler, IntPtr value)
        {
            this._indexActionEventHandler = indexActionEventHandler;
            this.m_value = value;
            this.EnsureCallbacks();
        }

        /// <summary>
        /// Defines the _indexerCallbacks
        /// </summary>
        private IndexerCallbacks _indexerCallbacks = default(IndexerCallbacks);

        /// <summary>
        /// Defines the _indexActionEventHandler
        /// </summary>
        private IIndexActionEventHandler _indexActionEventHandler;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the abortQuery
        /// </summary>
        private abortQuery abortQuery;

        /// <summary>
        /// Defines the diagnostic
        /// </summary>
        private diagnostic diagnostic;

        /// <summary>
        /// Defines the enteredMainFile
        /// </summary>
        private enteredMainFile enteredMainFile;

        /// <summary>
        /// Defines the importedASTFile
        /// </summary>
        private importedASTFile importedASTFile;

        /// <summary>
        /// Defines the ppIncludedFile
        /// </summary>
        private ppIncludedFile ppIncludedFile;

        /// <summary>
        /// Defines the indexDeclaration
        /// </summary>
        private indexDeclaration indexDeclaration;

        /// <summary>
        /// Defines the indexEntityReference
        /// </summary>
        private indexEntityReference indexEntityReference;

        /// <summary>
        /// Defines the startedTranslationUnit
        /// </summary>
        private startedTranslationUnit startedTranslationUnit;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The EnsureCallbacks
        /// </summary>
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

        /// <summary>
        /// The HandleStartedTranslationUnit
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        private IntPtr HandleStartedTranslationUnit(IntPtr client_data, IntPtr reserved)
        {
            this._indexActionEventHandler?.OnStartTranslationUnit();
            return IntPtr.Zero;
        }

        /// <summary>
        /// The HandleEntityReference
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="refInfo">The refInfo<see cref="IntPtr"/></param>
        private unsafe void HandleEntityReference(IntPtr client_data, IntPtr refInfo)
        {
            CXIdxEntityRefInfo* pIndexEntityRefInfo = (CXIdxEntityRefInfo*)refInfo;
            using (IndexEntityRefInfo indexEntityRefInfo = new IndexEntityRefInfo(*pIndexEntityRefInfo))
            {
                this._indexActionEventHandler?.OnIndexEntityRefInfo(indexEntityRefInfo);
            }
        }

        /// <summary>
        /// The HandleIndexDeclaration
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
        private unsafe void HandleIndexDeclaration(IntPtr client_data, IntPtr declInfo)
        {
            CXIdxDeclInfo* pIndexDeclInfo = (CXIdxDeclInfo*)declInfo;
            IndexDeclInfo indexDeclInfo = new IndexDeclInfo(*pIndexDeclInfo);
            this._indexActionEventHandler?.OnIndexDeclaration(indexDeclInfo);
        }

        /// <summary>
        /// The HandlePPIncludedFile
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="fileInfo">The fileInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        private unsafe IntPtr HandlePPIncludedFile(IntPtr client_data, IntPtr fileInfo)
        {
            CXIdxIncludedFileInfo* cXIdxIncludedFileInfo = (CXIdxIncludedFileInfo*)fileInfo;
            IndexIncludedFileInfo indexIncludedFileInfo = new IndexIncludedFileInfo(cXIdxIncludedFileInfo);
            File result = this._indexActionEventHandler?.OnIncludeFile(indexIncludedFileInfo);
            return result == null ? IntPtr.Zero : (IntPtr)result.Value;
        }

        /// <summary>
        /// The HandleImportedASTFile
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="fileInfo">The fileInfo<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        private IntPtr HandleImportedASTFile(IntPtr client_data, IntPtr fileInfo)
        {
            return IntPtr.Zero;
        }

        /// <summary>
        /// The HandleEnteredMainFile
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="mainFile">The mainFile<see cref="IntPtr"/></param>
        /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
        /// <returns>The <see cref="IntPtr"/></returns>
        private IntPtr HandleEnteredMainFile(IntPtr client_data, IntPtr mainFile, IntPtr reserved)
        {
            using (File file = new File(mainFile))
            {
                File result = this._indexActionEventHandler?.OnEnteredMainFile(file);
                return result == null ? IntPtr.Zero : (IntPtr)result.Value;
            }
        }

        /// <summary>
        /// The HandleDiagnostic
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="set">The set<see cref="IntPtr"/></param>
        /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
        private void HandleDiagnostic(IntPtr client_data, IntPtr set, IntPtr reserved)
        {
            using (DiagnosticSet diagnostics = new DiagnosticSet(set))
            {
                this._indexActionEventHandler?.OnDiagnostic(diagnostics);
            }
        }

        /// <summary>
        /// The HandleAbortQuery
        /// </summary>
        /// <param name="client_data">The client_data<see cref="IntPtr"/></param>
        /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
        /// <returns>The <see cref="int"/></returns>
        private int HandleAbortQuery(IntPtr client_data, IntPtr reserved)
        {
            if (this._indexActionEventHandler != null)
            {
                return this._indexActionEventHandler.OnQueryAbort() ? 1 : 0;
            }
            return 1;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_IndexAction_dispose(this.m_value);
        }

        /// <summary>
        /// The Index
        /// </summary>
        /// <param name="translationUnit">The translationUnit<see cref="TranslationUnit"/></param>
        /// <param name="indexOptFlags">The indexOptFlags<see cref="CXIndexOptFlags"/></param>
        /// <returns>The <see cref="CXErrorCode"/></returns>
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

        /// <summary>
        /// The IndexSourceFile
        /// </summary>
        /// <param name="sourceFile">The sourceFile<see cref="string"/></param>
        /// <param name="translationUnit">The translationUnit<see cref="TranslationUnit"/></param>
        /// <param name="cmdLineArgs">The cmdLineArgs<see cref="string[]"/></param>
        /// <param name="unsavedFiles">The unsavedFiles<see cref="UnsavedFile[]"/></param>
        /// <param name="indexOptFlags">The indexOptFlags<see cref="CXIndexOptFlags"/></param>
        /// <param name="translationUnit_Flags">The translationUnit_Flags<see cref="CXTranslationUnit_Flags"/></param>
        /// <returns>The <see cref="CXErrorCode"/></returns>
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
