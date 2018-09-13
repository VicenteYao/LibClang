using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TokenList :ClangObject<IntPtr> ,IReadOnlyList<Token>
    {
        internal unsafe TokenList(TranslationUnit translationUnit, CXToken* pTokens, uint tokensCount)
        {
            this._translationUnit = translationUnit;
            this.Value = (IntPtr)pTokens;
            this._tokensCount = tokensCount;
        }

        private TranslationUnit _translationUnit;

        private uint _tokensCount;

        private Dictionary<int, Token> _tokens;

        public Token this[int index]
        {
            get
            {
                return this.GetToken(index);
            }
        }

        private void EnsureTokens()
        {
            if (this._tokens==null)
            {
                this._tokens = new Dictionary<int, Token>(this.Count);
            }
        }

        private unsafe Token GetToken(int index)
        {
            this.EnsureTokens();
            Token token = null;
            if (this._tokens.ContainsKey(index))
            {
                token = this._tokens[index];
            }
            else
            {
                token = new Token(this._translationUnit, ((CXToken*)this.Value)[index]);
                this._tokens.Add(index, token);
            }
            return token;
        }

        public int Count
        {
            get { return (int)this._tokensCount; }
        }

        protected unsafe override  void Dispose()
        {
            clang.clang_disposeTokens(this._translationUnit.Value, (CXToken*)this.Value, this._tokensCount);
        }

        public IEnumerator<Token> GetEnumerator()
        {
            this.EnsureTokens();
            for (int i = 0; i < this._tokensCount; i++)
            {
                this.GetToken(i);
            }
            return this._tokens.Values.GetEnumerator();
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
