using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class CompletionResultAnnotationList : ClangObjectList<string>
    {

        internal CompletionResultAnnotationList(CXCompletionResult completionResult)
        {
            this.m_value = completionResult;
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        private CXCompletionResult m_value;

        protected override string EnsureItemAt(int index)
        {
            return clang.clang_getCompletionAnnotation(this.m_value.CompletionString, (uint)index).ToStringAndDispose();
        }

        protected override int GetCountCore()
        {
            return (int)clang.clang_getCompletionNumAnnotations(this.m_value.CompletionString);
        }
    }

}
