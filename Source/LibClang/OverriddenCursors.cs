using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class OverriddenCursors : ClangObjectList<Cursor,IntPtr>, IReadOnlyList<Cursor>
    {
        internal unsafe OverriddenCursors(CXCursor* pOverridenCursors,int count)
        {
            this.Value = (IntPtr)pOverridenCursors;
            this._count = count;
        }

        private int _count;

        protected unsafe override void Dispose()
        {
            clang.clang_disposeOverriddenCursors((CXCursor*)this.Value);
        }

        protected unsafe override Cursor EnsureItemAt(int index)
        {
            CXCursor* pCursors = (CXCursor*)this.Value;
            return new Cursor(pCursors[index]);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
