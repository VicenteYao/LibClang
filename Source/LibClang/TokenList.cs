using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TokenList : ClangObjectList<Token,IntPtr>
    {
        internal unsafe TokenList(TranslationUnit translationUnit, CXToken* pTokens, int tokensCount)
        {
            this._translationUnit = translationUnit;
            this.Value = (IntPtr)pTokens;
            this._tokensCount = tokensCount;
        }

        private TranslationUnit _translationUnit;

        private int _tokensCount;

        protected override int GetCountCore()
        {
            return this._tokensCount;
        }

        protected unsafe override Token EnsureItemAt(int index)
        {
            CXToken* pTokens = (CXToken*)this.Value;
            return new Token(this._translationUnit, pTokens[index]);
        }
    }
}
