using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class CompletionResultAnnotationList : ClangObjectList<string, CXCompletionResult>
    {

        internal CompletionResultAnnotationList(CXCompletionResult completionResult)
        {
            this.Value = completionResult;
        }

        protected override string EnsureItemAt(int index)
        {
            return clang.clang_getCompletionAnnotation(this.Value.CompletionString, (uint)index).ToStringAndDispose();
        }

        protected override int GetCountCore()
        {
            return (int)clang.clang_getCompletionNumAnnotations(this.Value.CompletionString);
        }
    }

}
