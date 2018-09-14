namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CompletionResultList" />
    /// </summary>
    public class CompletionResultList : ClangObjectList<CompletionResult>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CompletionResultList"/> class.
        /// </summary>
        /// <param name="pCompleteResults">The pCompleteResults<see cref="CXCodeCompleteResults*"/></param>
        internal unsafe CompletionResultList(CXCodeCompleteResults* pCompleteResults)
        {
            this.m_value = (IntPtr)pCompleteResults;
        }

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
        /// <returns>The <see cref="CompletionResult"/></returns>
        protected unsafe override CompletionResult EnsureItemAt(int index)
        {
            CXCodeCompleteResults* pCXCodeCompleteResults = (CXCodeCompleteResults*)this.m_value;
            uint fixitCount = clang.clang_getCompletionNumFixIts(pCXCodeCompleteResults, (uint)index);
            FixIt[] fixIts = new FixIt[fixitCount];
            for (uint J = 0; J < fixitCount; J++)
            {
                CXSourceRange xSourceRange;
                string text = clang.clang_getCompletionFixIt(pCXCodeCompleteResults, (uint)index, J, out xSourceRange).ToStringAndDispose();
                SourceRange sourceRange = new SourceRange(xSourceRange);
                fixIts[J] = new FixIt(text, sourceRange);
            }
            return new CompletionResult(pCXCodeCompleteResults->Results[index], fixIts);
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
