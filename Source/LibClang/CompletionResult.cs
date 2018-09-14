using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
     public class CompletionResult:ClangObject<CXCompletionResult>
    {
        internal CompletionResult(CXCompletionResult completionResult, FixIt[] fixIts)
        {
            this.FixIts = fixIts;
            this.CursorKind = completionResult.CursorKind;
            this.Value = completionResult;
        }

        public CXCursorKind CursorKind { get; private set; }

        public FixIt[] FixIts { get; private set; }


        private CompletionChunkList _completionChunk;
        public unsafe CompletionChunkList CompletionChunks
        {
            get
            {
                if (this._completionChunk == null)
                {
                    this._completionChunk = new CompletionChunkList(this.Value);
                }
                return this._completionChunk;
            }
        }

        private CompletionResultAnnotationList _annotations;

        public CompletionResultAnnotationList Annotations
        {
            get
            {
                if (this._annotations == null)
                {
                    this._annotations = new CompletionResultAnnotationList(this.Value);
                }
                return this._annotations;
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
