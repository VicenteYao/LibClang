namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="Diagnostic" />
    /// </summary>
    public class Diagnostic : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Diagnostic"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal Diagnostic(IntPtr value)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the _CXDiagnosticDisplayOptions
        /// </summary>
        private static CXDiagnosticDisplayOptions _CXDiagnosticDisplayOptions;

        /// <summary>
        /// Gets the DefaultDisplayOptions
        /// </summary>
        public static CXDiagnosticDisplayOptions DefaultDisplayOptions
        {
            get
            {
                _CXDiagnosticDisplayOptions = (CXDiagnosticDisplayOptions)clang.clang_defaultDiagnosticDisplayOptions();
                return _CXDiagnosticDisplayOptions;
            }
        }

        /// <summary>
        /// The Format
        /// </summary>
        /// <param name="diagnosticDisplayOptions">The diagnosticDisplayOptions<see cref="CXDiagnosticDisplayOptions"/></param>
        /// <returns>The <see cref="string"/></returns>
        public string Format(CXDiagnosticDisplayOptions diagnosticDisplayOptions)
        {
            return clang.clang_formatDiagnostic(this.m_value, (uint)diagnosticDisplayOptions).ToStringAndDispose();
        }

        /// <summary>
        /// Defines the _sourceLocation
        /// </summary>
        private SourceLocation _sourceLocation;

        /// <summary>
        /// Gets the SourceLocation
        /// </summary>
        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation == null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_getDiagnosticLocation(this.m_value));
                }
                return _sourceLocation;
            }
        }

        /// <summary>
        /// Defines the _childDiagnostics
        /// </summary>
        private ClangList<Diagnostic> _childDiagnostics;

        /// <summary>
        /// Gets the ChildDiagnostics
        /// </summary>
        public ClangList<Diagnostic> ChildDiagnostics
        {
            get
            {
                if (this._childDiagnostics == null)
                {
                    this._childDiagnostics = new DiagnosticSet(clang.clang_getChildDiagnostics(this.m_value));
                }
                return this._childDiagnostics;
            }
        }

        /// <summary>
        /// Defines the categoryText
        /// </summary>
        private string categoryText;

        /// <summary>
        /// Gets the CategoryText
        /// </summary>
        public string CategoryText
        {
            get
            {
                if (this.categoryText == null)
                {
                    this.categoryText = clang.clang_getDiagnosticCategoryText(this.m_value).ToStringAndDispose();
                }
                return this.categoryText;
            }
        }

        /// <summary>
        /// Defines the spelling
        /// </summary>
        private string spelling;

        /// <summary>
        /// Gets the Spelling
        /// </summary>
        public string Spelling
        {
            get
            {
                if (this.spelling == null)
                {
                    this.spelling = clang.clang_getDiagnosticSpelling(this.m_value).ToStringAndDispose();
                }
                return this.spelling;
            }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_disposeDiagnostic(this.m_value);
        }

        /// <summary>
        /// Defines the _category
        /// </summary>
        private int _category;

        /// <summary>
        /// Gets the Category
        /// </summary>
        public int Category
        {
            get
            {
                this._category = (int)clang.clang_getDiagnosticCategory(this.m_value);
                return this._category;
            }
        }

        /// <summary>
        /// Defines the _severity
        /// </summary>
        private CXDiagnosticSeverity _severity;

        /// <summary>
        /// Gets the Severity
        /// </summary>
        internal CXDiagnosticSeverity Severity
        {
            get
            {
                this._severity = clang.clang_getDiagnosticSeverity(this.m_value);
                return this._severity;
            }
        }

        /// <summary>
        /// Defines the _sourceRanges
        /// </summary>
        private SourceRange[] _sourceRanges;

        /// <summary>
        /// Gets the SourceRanges
        /// </summary>
        public SourceRange[] SourceRanges
        {
            get
            {
                if (this._sourceRanges == null)
                {
                    uint sourceRangesCount = clang.clang_getDiagnosticNumRanges(this.m_value);
                    this._sourceRanges = new SourceRange[(int)sourceRangesCount];
                    for (uint i = 0; i < sourceRangesCount; i++)
                    {
                        this._sourceRanges[i] = new SourceRange(clang.clang_getDiagnosticRange(this.m_value, i));
                    }
                }
                return this._sourceRanges;
            }
        }

        /// <summary>
        /// Defines the _fixIts
        /// </summary>
        private FixIt[] _fixIts;

        /// <summary>
        /// Gets the FixIts
        /// </summary>
        public FixIt[] FixIts
        {
            get
            {
                if (this._fixIts == null)
                {
                    uint fixitsCount = clang.clang_getDiagnosticNumFixIts(this.m_value);
                    this._fixIts = new FixIt[fixitsCount];
                    for (uint i = 0; i < fixitsCount; i++)
                    {
                        CXSourceRange xSourceRange;
                        string text = clang.clang_getDiagnosticFixIt(this.m_value, i, out xSourceRange).ToStringAndDispose();
                        SourceRange sourceRange = new SourceRange(xSourceRange);
                        this._fixIts[i] = new FixIt(text, sourceRange);
                    }
                }
                return this._fixIts;
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
            return string.Format("{0}:{1}", this.CategoryText, this.Spelling);
        }
    }
}
