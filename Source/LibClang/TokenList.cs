namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="TokenList" />
    /// </summary>
    public class TokenList : ClangObjectList<Token>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenList"/> class.
        /// </summary>
        /// <param name="translationUnit">The translationUnit<see cref="TranslationUnit"/></param>
        /// <param name="pTokens">The pTokens<see cref="CXToken*"/></param>
        /// <param name="tokensCount">The tokensCount<see cref="int"/></param>
        internal unsafe TokenList(TranslationUnit translationUnit, CXToken* pTokens, int tokensCount)
        {
            this._translationUnit = translationUnit;
            this.m_value = pTokens;
            this._tokensCount = tokensCount;
        }

        /// <summary>
        /// Defines the _translationUnit
        /// </summary>
        private TranslationUnit _translationUnit;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private unsafe CXToken* m_value;

        /// <summary>
        /// Defines the _tokensCount
        /// </summary>
        private int _tokensCount;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected unsafe internal override ValueType Value
        {
            get { return (IntPtr)this.m_value; }
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return this._tokensCount;
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="Token"/></returns>
        protected unsafe override Token EnsureItemAt(int index)
        {
            return new Token(this._translationUnit, this.m_value[index]);
        }
    }
}
