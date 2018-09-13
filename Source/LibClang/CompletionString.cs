using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class CompletionString : ClangObject<IntPtr>
    {
        internal CompletionString(string text,CXCompletionChunkKind chunkKind,IntPtr pCompletionString)
        {
            this.Text = text;
            this.CompletionChunkKind = chunkKind;
            this.Value = pCompletionString;
        }

        private CompletionString[] completionStrings;
        public CompletionString[] CompletionStrings
        {
            get
            {
                if (this.completionStrings == null)
                {
                    uint chunks = clang.clang_getNumCompletionChunks(this.Value);
                    this.completionStrings = new CompletionString[chunks];
                    for (uint i = 0; i < chunks; i++)
                    {
                        IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.Value, i);
                        string text = clang.clang_getCompletionChunkText(pCompletionString, i).ToStringAndDispose();
                        CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(pCompletionString, i);
                        this.completionStrings[i] = new CompletionString(text, chunkKind, pCompletionString);
                    }
                }
                return this.completionStrings;
            }
        }

        public CXCompletionChunkKind CompletionChunkKind { get; private set; }

        public string Text { get; private set; }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }



        public override string ToString()
        {
            return string.Format("{0}:{1}", this.CompletionChunkKind, this.Text);
        }
    }
}
