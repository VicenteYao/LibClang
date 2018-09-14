namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionChunkList" />
    /// </summary>
    public class CompletionChunkList : ClangObjectList<CompletionChunk>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionChunkList"/> class.
        /// </summary>
        /// <param name="completionResult">The completionResult<see cref="CXCompletionResult"/></param>
        internal CompletionChunkList(CXCompletionResult completionResult)
        {
            this.m_value = completionResult;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCompletionResult m_value;

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
            CXCompletionChunkKind chunkKind = clang.clang_getCompletionChunkKind(this.m_value.CompletionString, (uint)index);
            IntPtr pCompletionString = clang.clang_getCompletionChunkCompletionString(this.m_value.CompletionString, (uint)index);
            string text = clang.clang_getCompletionChunkText(this.m_value.CompletionString, (uint)index).ToStringAndDispose();
            return new CompletionChunk(chunkKind, text);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return (int)clang.clang_getNumCompletionChunks(this.m_value.CompletionString);
        }
    }
}
