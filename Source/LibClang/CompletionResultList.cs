using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class CompletionResultList : ClangObjectList<CompletionResult, IntPtr>
    {
        internal unsafe CompletionResultList(CXCodeCompleteResults* pCompleteResults)
        {
            this.Value = (IntPtr)pCompleteResults;
        }


        protected unsafe override CompletionResult EnsureItemAt(int index)
        {
            CXCodeCompleteResults* pCXCodeCompleteResults = (CXCodeCompleteResults*)this.Value;
            uint fixitCount = clang.clang_getCompletionNumFixIts(pCXCodeCompleteResults, (uint)index);
            FixIt[] fixIts = new FixIt[fixitCount];
            for (uint J = 0; J < fixitCount; J++)
            {
                CXSourceRange xSourceRange;
                string text = clang.clang_getCompletionFixIt(pCXCodeCompleteResults, (uint)index, J, out xSourceRange).ToStringAndDispose();
                SourceRange sourceRange = new SourceRange(xSourceRange);
                fixIts[J] = new FixIt(text, sourceRange);
            }
            return new CompletionResult(pCXCodeCompleteResults->Results[index], fixIts);
        }

        protected unsafe override int GetCountCore()
        {
            CXCodeCompleteResults* pCXCodeCompleteResults = (CXCodeCompleteResults*)this.Value;
            return (int)pCXCodeCompleteResults->NumResults;
        }
    }
}
