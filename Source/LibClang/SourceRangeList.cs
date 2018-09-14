using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRangeList:ClangObjectList<SourceRange, CXSourceRangeList>, IReadOnlyList<SourceRange>
    {
        internal SourceRangeList(CXSourceRangeList sourceRangeList)
        {
            this.Value = sourceRangeList;
        }

        protected unsafe override void Dispose()
        {
            clang.clang_disposeSourceRangeList((IntPtr)this.Value.ranges);
        }

        protected unsafe override SourceRange EnsureItemAt(int index)
        {
            return new SourceRange(this.Value.ranges[index]);
        }

        protected override int GetCountCore()
        {
            return (int)this.Value.count;
        }
    }
}
