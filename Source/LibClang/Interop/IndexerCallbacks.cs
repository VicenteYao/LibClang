namespace LibClang.Intertop
{
    using System;
    using System.Runtime.InteropServices;
    using CXClientData = System.IntPtr;
    using CXDiagnosticSet = System.IntPtr;
    using CXFile = System.IntPtr;
    using CXIdxClientASTFile = System.IntPtr;
    using CXIdxClientContainer = System.IntPtr;
    using CXIdxClientFile = System.IntPtr;

    /// <summary>
    /// The abortQuery
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
    /// <returns>The <see cref="int"/></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int abortQuery(CXClientData client_data, IntPtr reserved);

    /// <summary>
    /// The diagnostic
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="set">The set<see cref="CXDiagnosticSet"/></param>
    /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void diagnostic(CXClientData client_data, CXDiagnosticSet set, IntPtr reserved);

    /// <summary>
    /// The enteredMainFile
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="mainFile">The mainFile<see cref="CXFile"/></param>
    /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
    /// <returns>The <see cref="CXIdxClientFile"/></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientFile enteredMainFile(CXClientData client_data,
                      CXFile mainFile, IntPtr reserved);

    /// <summary>
    /// The ppIncludedFile
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="fileInfo">The fileInfo<see cref="IntPtr"/></param>
    /// <returns>The <see cref="CXIdxClientFile"/></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientFile ppIncludedFile(CXClientData client_data,
                               /*CXIdxIncludedFileInfo*/ IntPtr fileInfo);

    /// <summary>
    /// The indexEntityReference
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="refInfo">The refInfo<see cref="IntPtr"/></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void indexEntityReference(CXClientData client_data,
                    /*CXIdxEntityRefInfo*/IntPtr refInfo);

    /// <summary>
    /// The indexDeclaration
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="declInfo">The declInfo<see cref="IntPtr"/></param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void indexDeclaration(CXClientData client_data,
          /* CXIdxDeclInfo*/IntPtr declInfo);

    /// <summary>
    /// The startedTranslationUnit
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="reserved">The reserved<see cref="IntPtr"/></param>
    /// <returns>The <see cref="CXIdxClientContainer"/></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientContainer startedTranslationUnit(CXClientData client_data,
                                IntPtr reserved);

    /// <summary>
    /// The importedASTFile
    /// </summary>
    /// <param name="client_data">The client_data<see cref="CXClientData"/></param>
    /// <param name="fileInfo">The fileInfo<see cref="IntPtr"/></param>
    /// <returns>The <see cref="CXIdxClientASTFile"/></returns>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientASTFile importedASTFile(CXClientData client_data,
                                  /*CXIdxImportedASTFileInfo*/IntPtr fileInfo);

    /// <summary>
    /// Defines the <see cref="IndexerCallbacks" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IndexerCallbacks
    {
        /// <summary>
        /// Defines the abortQuery
        /// </summary>
        public IntPtr abortQuery;

        /// <summary>
        /// Defines the diagnostic
        /// </summary>
        public IntPtr diagnostic;

        /// <summary>
        /// Defines the enteredMainFile
        /// </summary>
        public IntPtr enteredMainFile;

        /// <summary>
        /// Defines the includedFile
        /// </summary>
        public IntPtr includedFile;

        /// <summary>
        /// Defines the importedASTFile
        /// </summary>
        public IntPtr importedASTFile;

        /// <summary>
        /// Defines the startedTranslationUnit
        /// </summary>
        public IntPtr startedTranslationUnit;

        /// <summary>
        /// Defines the indexDeclaration
        /// </summary>
        public IntPtr indexDeclaration;

        /// <summary>
        /// Defines the indexEntityReference
        /// </summary>
        public IntPtr indexEntityReference;
    }
}
