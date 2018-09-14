using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TokenList : ClangObjectList<Token>
    {
        internal unsafe TokenList(TranslationUnit translationUnit, CXToken* pTokens, int tokensCount)
        {
            this._translationUnit = translationUnit;
            this.m_value = (IntPtr)pTokens;
            this._tokensCount = tokensCount;
        }

        private TranslationUnit _translationUnit;
        private IntPtr m_value;
        private int _tokensCount;

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override int GetCountCore()
        {
            return this._tokensCount;
        }

        protected unsafe override Token EnsureItemAt(int index)
        {
            CXToken* pTokens = (CXToken*)this.m_value;
            return new Token(this._translationUnit, pTokens[index]);
        }
    }
}
