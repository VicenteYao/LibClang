using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class CursorSet : ClangObject<IntPtr>
    {
        public CursorSet()
        {
            this.Value = clang.clang_createCXCursorSet();
        }

        public bool Contains(Cursor cursor)
        {
            return clang.clang_CXCursorSet_contains(this.Value, cursor.Value) > 0;
        }

        public bool Insert(Cursor cursor)
        {
            return clang.clang_CXCursorSet_insert(this.Value, cursor.Value) > 0;
        }

        protected override void Dispose()
        {
            clang.clang_disposeCXCursorSet(this.Value);
        }
    }
}
