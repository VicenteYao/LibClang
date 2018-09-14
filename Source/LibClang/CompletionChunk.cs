namespace LibClang
{
    using LibClang.Intertop;

    /// <summary>
    /// Defines the <see cref="CompletionChunk" />
    /// </summary>
    public class CompletionChunk
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionChunk"/> class.
        /// </summary>
        /// <param name="chunkKind">The chunkKind<see cref="CXCompletionChunkKind"/></param>
        /// <param name="text">The text<see cref="string"/></param>
        internal CompletionChunk(CXCompletionChunkKind chunkKind, string text)
        {
            this.Text = text;
            this.CompletionChunkKind = chunkKind;
        }

        /// <summary>
        /// Gets the CompletionChunkKind
        /// </summary>
        public CXCompletionChunkKind CompletionChunkKind { get; private set; }

        /// <summary>
        /// Gets the Text
        /// </summary>
        public string Text { get; private set; }

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
