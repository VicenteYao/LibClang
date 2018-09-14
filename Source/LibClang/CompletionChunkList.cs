using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class CompletionChunkList : ClangObjectList<CompletionChunk, CXCompletionResult>
    {
        internal CompletionChunkList(CXCompletionResult completionResult)
        {
            this.Value = completionResult;
        }

        protected override CompletionChunk EnsureItemAt(int index)
        {
            CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(this.Value.CompletionString, (uint)index);
            IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.Value.CompletionString, (uint)index);
            string text = clang.clang_getCompletionChunkText(this.Value.CompletionString, (uint)index).ToStringAndDispose();
            return new CompletionChunk(chunkKind, text);
        }

        protected override int GetCountCore()
        {
            return (int)clang.clang_getNumCompletionChunks(this.Value.CompletionString);
        }
    }
}
