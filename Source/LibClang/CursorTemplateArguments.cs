using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public  class CursorTemplateArguments: ClangObjectList<TemplateArgument, CXCursor>
    {
        protected override TemplateArgument EnsureItemAt(int index)
        {
            var kind = clang.clang_Cursor_getTemplateArgumentKind(this.Value, (uint)index);
            if (kind == CXTemplateArgumentKind.CXTemplateArgumentKind_Integral)
            {
                return null;
            }
            return new Type(clang.clang_Cursor_getTemplateArgumentType(this.Value, (uint)index));
        }

        protected override int GetCountCore()
        {
            return clang.clang_Cursor_getNumTemplateArguments(this.Value);
        }
    }
}
