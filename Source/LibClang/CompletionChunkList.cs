namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionChunkList" />
    /// </summary>
    internal class CompletionChunkList : ClangList<CompletionChunk>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionChunkList"/> class.
        /// </summary>
        /// <param name="pCompletionString">The completionResult<see cref="CXCompletionResult"/></param>
        internal CompletionChunkList(IntPtr pCompletionString)
        {
            this.m_value = pCompletionString;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="CompletionChunk"/></returns>
        protected override CompletionChunk EnsureItemAt(int index)
        {
            return new CompletionChunk(this.m_value, (uint)index);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return (int)clang.clang_getNumCompletionChunks(this.m_value);
        }
    }
}
