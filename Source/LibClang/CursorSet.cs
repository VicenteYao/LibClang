using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class CursorSet : ClangObject
    {
        public CursorSet()
        {
            this.m_value = clang.clang_createCXCursorSet();
        }

        private IntPtr m_value;

        protected internal override ValueType Value => throw new NotImplementedException();

        public bool Contains(Cursor cursor)
        {
            return clang.clang_CXCursorSet_contains(this.m_value, (CXCursor)cursor.Value) > 0;
        }

        public bool Insert(Cursor cursor)
        {
            return clang.clang_CXCursorSet_insert(this.m_value, (CXCursor)cursor.Value) > 0;
        }

        protected override void Dispose()
        {
            clang.clang_disposeCXCursorSet(this.m_value);
        }
    }
}
