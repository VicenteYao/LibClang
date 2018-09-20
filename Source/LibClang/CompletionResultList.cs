namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionResultList" />
    /// </summary>
    public class CompletionResultList : ClangList<CompletionResult>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private unsafe CXCodeCompleteResults* m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionResultList"/> class.
        /// </summary>
        /// <param name="pCompleteResults">The pCompleteResults<see cref="CXCodeCompleteResults*"/></param>
        internal unsafe CompletionResultList(CXCodeCompleteResults* pCompleteResults)
        {
            this.m_value = pCompleteResults;
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected unsafe internal override ValueType Value
        {
            get { return (IntPtr)this.m_value; }
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="CompletionResult"/></returns>
        protected unsafe override CompletionResult EnsureItemAt(int index)
        {
            uint fixitCount = clang.clang_getCompletionNumFixIts(this.m_value, (uint)index);
            FixIt[] fixIts = new FixIt[fixitCount];
            for (uint J = 0; J < fixitCount; J++)
            {
                CXSourceRange xSourceRange;
                string text = clang.clang_getCompletionFixIt(this.m_value, (uint)index, J, out xSourceRange).ToStringAndDispose();
                SourceRange sourceRange = new SourceRange(xSourceRange);
                fixIts[J] = new FixIt(text, sourceRange);
            }
            return new CompletionResult(this.m_value->Results[index], fixIts);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected unsafe override int GetCountCore()
        {
            CXCodeCompleteResults* pCXCodeCompleteResults = (CXCodeCompleteResults*)this.m_value;
            return (int)pCXCodeCompleteResults->NumResults;
        }
    }
}
