using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class OverriddenCursors : ClangObjectList<Cursor>
    {
        internal OverriddenCursors(CXCursor cursor)
        {
            this.m_value = cursor;
            uint cursorsCount = 0;
            clang.clang_getOverriddenCursors(this.m_value, out pCursors, out cursorsCount);
            this._count = (int)cursorsCount;
        }

        private CXCursor* pCursors;
        private int _count;
        private CXCursor m_value;

        protected internal override ValueType Value { get { return this.m_value; } }

        protected unsafe override void Dispose()
        {
            clang.clang_disposeOverriddenCursors(this.pCursors);
        }

        protected unsafe override Cursor EnsureItemAt(int index)
        {
            return new Cursor(this.pCursors[index]);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
