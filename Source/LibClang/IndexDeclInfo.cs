using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexDeclInfo:ClangObject<CXIdxDeclInfo>
    {
        internal IndexDeclInfo(CXIdxDeclInfo cXIdxDeclInfo)
        {
            this.Value = cXIdxDeclInfo;
        }

        protected override bool EqualsCore(ClangObject<CXIdxDeclInfo> clangObject)
        {
            return false;
        }
    }
}
