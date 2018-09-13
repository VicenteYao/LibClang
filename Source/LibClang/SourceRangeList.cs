using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRangeList:ClangObject<CXSourceRangeList>
    {
        internal SourceRangeList(CXSourceRangeList sourceRangeList)
        {
            this.Value = sourceRangeList;
        }

        protected unsafe override void Dispose()
        {
            clang.clang_disposeSourceRangeList((IntPtr)this.Value.ranges);
        }

        protected unsafe override bool EqualsCore(ClangObject<CXSourceRangeList> clangObject)
        {
            return this.Value.ranges == clangObject.Value.ranges;
        }
    }
}
