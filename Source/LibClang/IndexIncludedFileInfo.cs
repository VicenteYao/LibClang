using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class IndexIncludedFileInfo
    {
        internal unsafe IndexIncludedFileInfo(CXIdxIncludedFileInfo* cXIdxIncludedFileInfo)
        {
            this.HashLocation = new IndexLocation(cXIdxIncludedFileInfo->hashLoc);
            this.IsAngled = cXIdxIncludedFileInfo->isAngled > 0;
            this.IsImport = cXIdxIncludedFileInfo->isImport > 0;
            this.IsModuleImport = cXIdxIncludedFileInfo->isModuleImport > 0;
            this.FileName = new string(cXIdxIncludedFileInfo->filename);
        }

        public IndexLocation HashLocation { get; private set; }

        public string FileName { get; private set; }

        public File File { get; private set; }

        public bool IsImport { get; private set; }

        public bool IsAngled { get; private set; }

        public bool IsModuleImport { get; private set; }
          

    }
}
