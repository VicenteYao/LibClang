using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    [DebuggerDisplay("[{TokenKind},{SourceRange},{Spelling}]")]
    public class Token : ClangObject<CXToken>
    {
        internal Token(TranslationUnit translationUnit, CXToken token)
        {
            this.TranslationUnit = translationUnit;
            this.Value = token;
        }

        protected TranslationUnit TranslationUnit { get; private set; }


        private CXTokenKind? tokenKind;

        public CXTokenKind TokenKind
        {
            get
            {
                if (!this.tokenKind.HasValue)
                {
                    this.tokenKind = clang.clang_getTokenKind(this.Value);
                }
                return this.tokenKind.Value;
            }
        }

        private SourceLocation sourceLocation;

        public SourceLocation SourceLocation
        {
            get
            {
                if (this.sourceLocation == null)
                {
                    var cxLocation = clang.clang_getTokenLocation(this.TranslationUnit.Value, this.Value);
                    this.sourceLocation = new SourceLocation(cxLocation);
                }
                return this.sourceLocation;
            }
        }

        private SourceRange sourceRange;

        public SourceRange SourceRange
        {
            get
            {
                if (this.sourceRange == null)
                {
                    this.sourceRange = new SourceRange(clang.clang_getTokenExtent(this.TranslationUnit.Value, this.Value));
                }
                return this.sourceRange;
            }
        }

        private string _spelling;
        public string Spelling
        {
            get
            {
                if (this._spelling == null)
                {
                    this._spelling = clang.clang_getTokenSpelling(this.TranslationUnit.Value, this.Value).ToStringAndDispose();
                }
                return this._spelling;
            }
        }

        protected override bool EqualsCore(ClangObject<CXToken> clangObject)
        {
            return this.Value.Equals(clangObject.Value);
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", this.TokenKind, this.SourceRange, this.Spelling);
        }
    }
}
