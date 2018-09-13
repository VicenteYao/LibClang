using System;
using System.Collections.Generic;
using System.Text;
using CXFile = System.IntPtr;
using CXModule = System.IntPtr;

namespace LibClang.Intertop
{

    /**
     * Data for IndexerCallbacks#importedASTFile.
     */
    public struct CXIdxImportedASTFileInfo
    {
        /**
         * Top level AST file containing the imported PCH, module or submodule.
         */
        public CXFile file;
        /**
         * The imported module or NULL if the AST file is a PCH.
         */
        public CXModule module;
        /**
         * Location where the file is imported. Applicable only for modules.
         */
        public CXIdxLoc loc;
        /**
         * Non-zero if an inclusion directive was automatically turned into
         * a module import. Applicable only for modules.
         */
        public int isImplicit;

    }
}
