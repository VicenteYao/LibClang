using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    [DebuggerDisplay("[{TokenKind},{SourceRange},{Spelling}]")]
    public class Token : ClangObject
    {
        internal Token(TranslationUnit translationUnit, CXToken token)
        {
            this._translationUnit = translationUnit;
            this.m_value = token;
        }

        private TranslationUnit _translationUnit;
        private CXToken m_value;
        private CXTokenKind? tokenKind;

        public CXTokenKind TokenKind
        {
            get
            {
                if (!this.tokenKind.HasValue)
                {
                    this.tokenKind = clang.clang_getTokenKind(this.m_value);
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
                    var cxLocation = clang.clang_getTokenLocation((IntPtr)this._translationUnit.Value, this.m_value);
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
                    this.sourceRange = new SourceRange(clang.clang_getTokenExtent((IntPtr)this._translationUnit.Value, this.m_value));
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
                    this._spelling = clang.clang_getTokenSpelling((IntPtr)this._translationUnit.Value, this.m_value).ToStringAndDispose();
                }
                return this._spelling;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]", this.TokenKind, this.SourceRange, this.Spelling);
        }
    }
}
