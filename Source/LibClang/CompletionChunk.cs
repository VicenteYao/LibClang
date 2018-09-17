namespace LibClang
{
    using System;
    using LibClang.Intertop;

    /// <summary>
    /// Defines the <see cref="CompletionChunk" />
    /// </summary>
    public class CompletionChunk:ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionChunk"/> class.
        /// </summary>
        /// <param name="chunkKind">The chunkKind<see cref="CXCompletionChunkKind"/></param>
        /// <param name="text">The text<see cref="string"/></param>
        internal CompletionChunk(IntPtr pCompletionString, uint chunkNumer)
        {
            this.m_value = pCompletionString;
            this._chunkNumber = chunkNumer;
            this.m_CompletionString = clang.clang_getCompletionChunkCompletionString(pCompletionString, chunkNumer);
            if (this.m_CompletionString!=IntPtr.Zero)
            {

            }
        }


        /// <summary>
        /// Defines the _completionChunkList
        /// </summary>
        private ClangList<CompletionChunk> _chunks;
        private IntPtr m_value;
        private IntPtr m_CompletionString;
        private uint _chunkNumber;


        /// <summary>
        /// Gets the CompletionChunks
        /// </summary>
        public unsafe ClangList<CompletionChunk> Chunks
        {
            get
            {
                if (this._chunks == null)
                {
                    this._chunks = new CompletionChunkList(this.m_CompletionString);
                }
                return this._chunks;
            }
        }


        private CXCompletionChunkKind _completionChunkKind;
        /// <summary>
        /// Gets the CompletionChunkKind
        /// </summary>
        public CXCompletionChunkKind CompletionChunkKind
        {
            get
            {
                this._completionChunkKind = clang.clang_getCompletionChunkKind(this.m_value, this._chunkNumber);
                return this._completionChunkKind;
            }
        }



        private string _text;
        /// <summary>
        /// Gets the Text
        /// </summary>
        public string Text
        {
            get
            {
                if (this._text == null)
                {
                    this._text = clang.clang_getCompletionChunkText(this.m_value, this._chunkNumber).ToStringAndDispose();
                }
                return this._text;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("{0}:{1}", this.CompletionChunkKind, this.Text);
        }
    }
}
