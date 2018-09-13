using System;
using System.Collections.Generic;
using System.Text;
using CXClientData = System.IntPtr;
using CXDiagnosticSet = System.IntPtr;
using CXFile = System.IntPtr;
using CXIdxClientFile = System.IntPtr;
using CXIdxClientContainer = System.IntPtr;
using CXIdxClientASTFile = System.IntPtr;
using System.Runtime.InteropServices;
namespace LibClang.Intertop
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int abortQuery(CXClientData client_data, IntPtr reserved);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void diagnostic(CXClientData client_data, CXDiagnosticSet set, IntPtr reserved);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientFile enteredMainFile(CXClientData client_data,
                      CXFile mainFile, IntPtr reserved);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientFile ppIncludedFile(CXClientData client_data,
                               /*CXIdxIncludedFileInfo*/ IntPtr fileInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void indexEntityReference(CXClientData client_data,
                    /*CXIdxEntityRefInfo*/IntPtr refInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void indexDeclaration(CXClientData client_data,
          /* CXIdxDeclInfo*/IntPtr declInfo);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientContainer startedTranslationUnit(CXClientData client_data,
                                IntPtr reserved);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate CXIdxClientASTFile importedASTFile(CXClientData client_data,
                                  /*CXIdxImportedASTFileInfo*/IntPtr fileInfo);


    /**
           * A group of callbacks used by #clang_indexSourceFile and
           * #clang_indexTranslationUnit.
           */
      [StructLayout(LayoutKind.Sequential)]
    public unsafe struct IndexerCallbacks
    {
        /**
         * Called periodically to check whether indexing should be aborted.
         * Should return 0 to continue, and non-zero to abort.
         */
        public IntPtr abortQuery;

        /**
         * Called at the end of indexing; passes the complete diagnostic set.
         */
        public IntPtr diagnostic;

        public IntPtr enteredMainFile;



        /**
         * Called when a file gets \#included/\#imported.
         */
        public IntPtr includedFile;

        /**
         * Called when a AST file (PCH or module) gets imported.
         *
         * AST files will not get indexed (there will not be callbacks to index all
         * the entities in an AST file). The recommended action is that, if the AST
         * file is not already indexed, to initiate a new indexing job specific to
         * the AST file.
         */
        public IntPtr importedASTFile;
        /**
* Called at the beginning of indexing a translation unit.
*/
        public IntPtr startedTranslationUnit;


        public IntPtr indexDeclaration;

        /**
         * Called to index a reference of an entity.
         */
        public IntPtr indexEntityReference;

    }
}
