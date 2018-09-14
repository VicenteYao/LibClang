using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class OverriddenCursors : ClangObjectList<Cursor, CXCursor>
    {
        internal OverriddenCursors(CXCursor cursor)
        {
            this.Value = cursor;
            uint cursorsCount = 0;
            clang.clang_getOverriddenCursors(this.Value, out pCursors, out cursorsCount);
            this._count = (int)cursorsCount;
        }

        private CXCursor* pCursors;
        private int _count;

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
