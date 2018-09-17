namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionResultAnnotationList" />
    /// </summary>
    internal class CompletionResultAnnotationList : ClangList<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionResultAnnotationList"/> class.
        /// </summary>
        /// <param name="completionResult">The completionResult<see cref="CXCompletionResult"/></param>
        internal CompletionResultAnnotationList(IntPtr completionResult)
        {
            this.m_value = completionResult;
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        protected override string EnsureItemAt(int index)
        {
            return clang.clang_getCompletionAnnotation(this.m_value, (uint)index).ToStringAndDispose();
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return (int)clang.clang_getCompletionNumAnnotations(this.m_value);
        }
    }
}
