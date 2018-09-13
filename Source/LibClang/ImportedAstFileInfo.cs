using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class ImportedAstFileInfo:ClangObject<CXIdxImportedASTFileInfo>
    {

        internal ImportedAstFileInfo(CXIdxImportedASTFileInfo cXIdxImportedASTFileInfo)
        {
            this.File = new File(cXIdxImportedASTFileInfo.file);
            this.Module = new Module(cXIdxImportedASTFileInfo.module);
            this.IndexLocation = new IndexLocation(cXIdxImportedASTFileInfo.loc);
            this.IsImplicit = cXIdxImportedASTFileInfo.isImplicit > 0;
        }

        public File File { get; private set; }

        public Module Module { get;private set; }

        public IndexLocation IndexLocation { get; private set; }


        public bool IsImplicit { get; private set; }

        protected override bool EqualsCore(ClangObject<CXIdxImportedASTFileInfo> clangObject)
        {
            return false;
        }
    }
}
