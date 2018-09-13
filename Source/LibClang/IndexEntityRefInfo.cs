using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexEntityRefInfo : ClangObject<CXIdxEntityRefInfo>
    {

        internal IndexEntityRefInfo(CXIdxEntityRefInfo cXIdxEntityRefInfo)
        {
            this.Value = cXIdxEntityRefInfo;
        }

        protected override bool EqualsCore(ClangObject<CXIdxEntityRefInfo> clangObject)
        {
            return false;
        }
    }
}
