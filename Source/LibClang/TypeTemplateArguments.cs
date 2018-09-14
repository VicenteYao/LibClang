using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TypeTemplateArguments : ClangObjectList<Type>
    {
        private CXType m_value;

        internal TypeTemplateArguments(CXType type)
        {
            this.m_value = type;
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override Type EnsureItemAt(int index)
        {
            return new Type(clang.clang_Type_getTemplateArgumentAsType(this.m_value, (uint)index));
        }

        protected override int GetCountCore()
        {
            return clang.clang_Type_getNumTemplateArguments(this.m_value);
        }
    }
}
