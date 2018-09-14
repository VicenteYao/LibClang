using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class CompletionChunkList : ClangObjectList<CompletionChunk>
    {
        internal CompletionChunkList(CXCompletionResult completionResult)
        {
            this.m_value = completionResult;
        }

        private CXCompletionResult m_value;

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override CompletionChunk EnsureItemAt(int index)
        {
            CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(this.m_value.CompletionString, (uint)index);
            IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.m_value.CompletionString, (uint)index);
            string text = clang.clang_getCompletionChunkText(this.m_value.CompletionString, (uint)index).ToStringAndDispose();
            return new CompletionChunk(chunkKind, text);
        }

        protected override int GetCountCore()
        {
            return (int)clang.clang_getNumCompletionChunks(this.m_value.CompletionString);
        }
    }
}
