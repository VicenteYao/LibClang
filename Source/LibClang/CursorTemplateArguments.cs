using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public  class CursorTemplateArguments: ClangObjectList<TypeTemplateArgument, CXCursor>
    {
        internal CursorTemplateArguments(CXCursor cursor)
        {
            this.Value = cursor;
        }

        protected override TypeTemplateArgument EnsureItemAt(int index)
        {
            var kind = clang.clang_Cursor_getTemplateArgumentKind(this.Value, (uint)index);
            if (kind == CXTemplateArgumentKind.CXTemplateArgumentKind_Integral)
            {
                long longValue = clang.clang_Cursor_getTemplateArgumentValue(this.Value, (uint)index);
                return new TypeTemplateArgument(longValue);
            }
            Type type = new Type(clang.clang_Cursor_getTemplateArgumentType(this.Value, (uint)index));
            return new TypeTemplateArgument(type);
        }

        protected override int GetCountCore()
        {
            return clang.clang_Cursor_getNumTemplateArguments(this.Value);
        }
    }
}
