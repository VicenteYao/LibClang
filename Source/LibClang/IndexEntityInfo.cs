using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public  class IndexEntityInfo:ClangObject<IntPtr>
    {
        internal IndexEntityInfo(IntPtr entityInfo)
        {
            this.Value = entityInfo;
        }
    }
}
