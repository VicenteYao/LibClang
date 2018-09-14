using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TypeTemplateArguments : ClangObjectList<Type, CXType>
    {
        internal TypeTemplateArguments(CXType type)
        {
            this.Value = type;
        }

        protected override Type EnsureItemAt(int index)
        {
            return new Type(clang.clang_Type_getTemplateArgumentAsType(this.Value, (uint)index));
        }

        protected override int GetCountCore()
        {
            return clang.clang_Type_getNumTemplateArguments(this.Value);
        }
    }
}
