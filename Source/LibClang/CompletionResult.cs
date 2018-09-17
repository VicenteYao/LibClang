namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionResult" />
    /// </summary>
    public class CompletionResult : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionResult"/> class.
        /// </summary>
        /// <param name="completionResult">The completionResult<see cref="CXCompletionResult"/></param>
        /// <param name="fixIts">The fixIts<see cref="FixIt[]"/></param>
        internal CompletionResult(CXCompletionResult completionResult, FixIt[] fixIts)
        {
            this.m_value = completionResult;
            this.FixIts = fixIts;
            this.CursorKind = completionResult.CursorKind;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCompletionResult m_value;

        /// <summary>
        /// Gets the CursorKind
        /// </summary>
        public CXCursorKind CursorKind { get; private set; }

        /// <summary>
        /// Gets the FixIts
        /// </summary>
        public FixIt[] FixIts { get; private set; }

        /// <summary>
        /// Defines the _completionChunkList
        /// </summary>
        private ClangList<CompletionChunk> _chunks;

        /// <summary>
        /// Gets the CompletionChunks
        /// </summary>
        public unsafe ClangList<CompletionChunk> Chunks
        {
            get
            {
                if (this._chunks == null)
                {
                    this._chunks = new CompletionChunkList(this.m_value.CompletionString);
                }
                return this._chunks;
            }
        }

        private string _parent;
        public string Parent
        {
            get
            {
                if (this._parent == null)
                {
                    CXCursorKind cursorKind = CXCursorKind.CXCursor_NotImplemented;
                    this._parent = clang.clang_getCompletionParent(this.m_value.CompletionString, out cursorKind).ToStringAndDispose();
                }
                return this._parent;
            }
        }

        private uint _priority;
        public uint Priority
        {
            get
            {
                this._priority = clang.clang_getCompletionPriority(this.m_value.CompletionString);
                return this._priority;
            }
        }

        private CXAvailabilityKind _availabilityKind;

        public CXAvailabilityKind AvailabilityKind
        {
            get
            {
                this._availabilityKind = clang.clang_getCompletionAvailability(this.m_value.CompletionString);
                return this._availabilityKind;
            }
        }

        /// <summary>
        /// Defines the _annotations
        /// </summary>
        private ClangList<string> _annotations;

        /// <summary>
        /// Gets the Annotations
        /// </summary>
        public ClangList<string> Annotations
        {
            get
            {
                if (this._annotations == null)
                {
                    this._annotations = new CompletionResultAnnotationList(this.m_value.CompletionString);
                }
                return this._annotations;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
