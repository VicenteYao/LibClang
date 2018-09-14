using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRangeList : ClangObjectList<SourceRange>
    {
        private CXSourceRangeList m_value;

        internal SourceRangeList(CXSourceRangeList sourceRangeList)
        {
            this.m_value = sourceRangeList;
        }

        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        protected unsafe override void Dispose()
        {
            clang.clang_disposeSourceRangeList((IntPtr)this.m_value.ranges);
        }

        protected unsafe override SourceRange EnsureItemAt(int index)
        {
            return new SourceRange(this.m_value.ranges[index]);
        }

        protected override int GetCountCore()
        {
            return (int)this.m_value.count;
        }
    }
}
