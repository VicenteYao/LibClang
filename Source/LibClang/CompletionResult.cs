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
        private CompletionChunkList _completionChunkList;

        /// <summary>
        /// Gets the CompletionChunks
        /// </summary>
        public unsafe CompletionChunkList CompletionChunks
        {
            get
            {
                if (this._completionChunkList == null)
                {
                    this._completionChunkList = new CompletionChunkList(this.m_value);
                }
                return this._completionChunkList;
            }
        }

        /// <summary>
        /// Defines the _annotations
        /// </summary>
        private CompletionResultAnnotationList _annotations;

        /// <summary>
        /// Gets the Annotations
        /// </summary>
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

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
