using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class CompletionChunk 
    {
        internal CompletionChunk(CXCompletionChunkKind chunkKind,string text)
        {
            this.Text = text;
            this.CompletionChunkKind = chunkKind;
        }

        public CXCompletionChunkKind CompletionChunkKind { get; private set; }

        public string Text { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.CompletionChunkKind, this.Text);
        }
    }
}
