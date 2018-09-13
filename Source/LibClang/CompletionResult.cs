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


        private CompletionChunk[] _completionChunk;
        public unsafe CompletionChunk[] CompletionChunks
        {
            get
            {
                if (this._completionChunk == null)
                {
                    uint chunks = clang.clang_getNumCompletionChunks(this.Value.CompletionString);
                    uint annotationsCount = clang.clang_getCompletionNumAnnotations(this.Value.CompletionString);
                    this._completionChunk = new CompletionChunk[chunks];
                    for (uint i = 0; i < chunks; i++)
                    {
                        CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(this.Value.CompletionString, i);
                        IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.Value.CompletionString, i);
                        string text = clang.clang_getCompletionChunkText(this.Value.CompletionString, i).ToStringAndDispose();

                        this._completionChunk[i] = new CompletionChunk(chunkKind, text);
                    }
                }
                return this._completionChunk;
            }
        }

        private string[] _annotations;

        public string[] Annotations
        {
            get
            {
                if (this._annotations == null)
                {
                    uint annotationsCount = clang.clang_getCompletionNumAnnotations(this.Value.CompletionString);
                    this._annotations = new string[annotationsCount];
                    for (uint i = 0; i < annotationsCount; i++)
                    {
                        this._annotations[i] = clang.clang_getCompletionAnnotation(this.Value.CompletionString, i).ToStringAndDispose();
                    }
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
