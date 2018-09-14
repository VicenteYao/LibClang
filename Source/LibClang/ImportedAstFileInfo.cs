using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class ImportedAstFileInfo:ClangObject
    {

        internal ImportedAstFileInfo(CXIdxImportedASTFileInfo importedASTFileInfo)
        {
            this.m_value = importedASTFileInfo;
            this.File = new File(importedASTFileInfo.file);
            this.Module = new Module(importedASTFileInfo.module);
            this.IndexLocation = new IndexLocation(importedASTFileInfo.loc);
            this.IsImplicit = importedASTFileInfo.isImplicit > 0;
        }

        private CXIdxImportedASTFileInfo m_value;

        public File File { get; private set; }

        public Module Module { get;private set; }

        public IndexLocation IndexLocation { get; private set; }


        public bool IsImplicit { get; private set; }

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
