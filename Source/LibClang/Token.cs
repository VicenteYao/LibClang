namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Defines the <see cref="Token" />
    /// </summary>
    [DebuggerDisplay("[{TokenKind},{SourceRange},{Spelling}]")]
    public class Token : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="translationUnit">The translationUnit<see cref="TranslationUnit"/></param>
        /// <param name="token">The token<see cref="CXToken"/></param>
        internal Token(TranslationUnit translationUnit, CXToken token)
        {
            this._translationUnit = translationUnit;
            this.m_value = token;
        }

        /// <summary>
        /// Defines the _translationUnit
        /// </summary>
        private TranslationUnit _translationUnit;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXToken m_value;

        /// <summary>
        /// Defines the tokenKind
        /// </summary>
        private CXTokenKind? tokenKind;

        /// <summary>
        /// Gets the TokenKind
        /// </summary>
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

        /// <summary>
        /// Defines the sourceLocation
        /// </summary>
        private SourceLocation sourceLocation;

        /// <summary>
        /// Gets the SourceLocation
        /// </summary>
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

        /// <summary>
        /// Defines the sourceRange
        /// </summary>
        private SourceRange sourceRange;

        /// <summary>
        /// Gets the SourceRange
        /// </summary>
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

        /// <summary>
        /// Defines the _spelling
        /// </summary>
        private string _spelling;

        /// <summary>
        /// Gets the Spelling
        /// </summary>
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

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2}]", this.TokenKind, this.SourceRange, this.Spelling);
        }
    }
}
