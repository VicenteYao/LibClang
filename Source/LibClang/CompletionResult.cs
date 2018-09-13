using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
     public class CompletionResult:ClangObject<IntPtr>
    {
        internal CompletionResult(CXCursorKind cursorKind, IntPtr pCompletionResult)
        {
            this.CursorKind = cursorKind;
            this.Value = pCompletionResult;
        }

        public CXCursorKind CursorKind { get; private set; }


        private CompletionString[] completionStrings;
        public unsafe CompletionString[] CompletionStrings
        {
            get
            {
                if (this.completionStrings == null)
                {
                    CXCompletionResult* pCompletionResult = (CXCompletionResult*)this.Value;
                    uint chunks = clang.clang_getNumCompletionChunks(this.Value);
                    this.completionStrings = new CompletionString[chunks];
                    for (uint i = 0; i < chunks; i++)
                    {
                        IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(pCompletionResult->CompletionString, i);
                        string text = clang.clang_getCompletionChunkText(pCompletionString, i).ToStringAndDispose();
                        CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(pCompletionString, i);
                        this.completionStrings[i] = new CompletionString(text, chunkKind, pCompletionString);
                    }
                }
                return this.completionStrings;
            }
        }


        protected override void Dispose()
        {
            Marshal.FreeHGlobal(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
