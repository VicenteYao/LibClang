using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
     public class CompletionResult:ClangObject<CXCompletionResult>
    {
        internal CompletionResult(CXCompletionResult completionResult)
        {
            this.CursorKind = completionResult.CursorKind;
            this.Value = completionResult;
        }

        public CXCursorKind CursorKind { get; private set; }


        private CompletionString[] completionStrings;
        public unsafe CompletionString[] CompletionStrings
        {
            get
            {
                if (this.completionStrings == null)
                {
                    uint chunks = clang.clang_getNumCompletionChunks(this.Value.CompletionString);
                    this.completionStrings = new CompletionString[chunks];
                    for (uint i = 0; i < chunks; i++)
                    {
                        CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(this.Value.CompletionString, i);
                        IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.Value.CompletionString, i);
                        string text = clang.clang_getCompletionChunkText(this.Value.CompletionString, i).ToStringAndDispose();
                        this.completionStrings[i] = new CompletionString(text, chunkKind);
                    }
                }
                return this.completionStrings;
            }
        }


        protected override void Dispose()
        {

        }

        protected override bool EqualsCore(ClangObject<CXCompletionResult> clangObject)
        {
            return false;
        }
    }
}
