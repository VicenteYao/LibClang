using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public  class CursorTemplateArguments: ClangObjectList<TemplateArgument>
    {
        private CXCursor m_value;

        internal CursorTemplateArguments(CXCursor cursor)
        {
            this.m_value = cursor;
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override TemplateArgument EnsureItemAt(int index)
        {
            var kind = clang.clang_Cursor_getTemplateArgumentKind(this.m_value, (uint)index);
            if (kind == CXTemplateArgumentKind.CXTemplateArgumentKind_Integral)
            {
                long longValue = clang.clang_Cursor_getTemplateArgumentValue(this.m_value, (uint)index);
                return new TemplateArgument(longValue);
            }
            Type type = new Type(clang.clang_Cursor_getTemplateArgumentType(this.m_value, (uint)index));
            return new TemplateArgument(type);
        }

        protected override int GetCountCore()
        {
            return clang.clang_Cursor_getNumTemplateArguments(this.m_value);
        }
    }
}
