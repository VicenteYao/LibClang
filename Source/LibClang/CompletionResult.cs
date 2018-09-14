using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
     public class CompletionResult:ClangObject
    {
        internal CompletionResult(CXCompletionResult completionResult, FixIt[] fixIts)
        {
            this.FixIts = fixIts;
            this.CursorKind = completionResult.CursorKind;
        }

        private CXCompletionResult m_value;

        public CXCursorKind CursorKind { get; private set; }

        public FixIt[] FixIts { get; private set; }


        private CompletionChunkList _completionChunk;
        public unsafe CompletionChunkList CompletionChunks
        {
            get
            {
                if (this._completionChunk == null)
                {
                    this._completionChunk = new CompletionChunkList(this.m_value);
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
                    this._annotations = new CompletionResultAnnotationList(this.m_value);
                }
                return this._annotations;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
