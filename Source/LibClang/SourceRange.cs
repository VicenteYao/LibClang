namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="SourceRange" />
    /// </summary>
    public class SourceRange : ClangObject
    {
        /// <summary>
        /// Initializes static members of the <see cref="SourceRange"/> class.
        /// </summary>
        static SourceRange()
        {
            SourceRange.Null = new SourceRange(clang.clang_getNullRange());
        }

        /// <summary>
        /// Gets the Null
        /// </summary>
        public static SourceRange Null { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceRange"/> class.
        /// </summary>
        /// <param name="sourceRange">The sourceRange<see cref="CXSourceRange"/></param>
        internal SourceRange(CXSourceRange sourceRange)
        {
            this.m_value = sourceRange;
        }

        /// <summary>
        /// Gets a value indicating whether IsNull
        /// </summary>
        public bool IsNull
        {
            get
            {
                return clang.clang_Range_isNull(this.m_value) > 0;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceRange"/> class.
        /// </summary>
        /// <param name="begin">The begin<see cref="SourceLocation"/></param>
        /// <param name="end">The end<see cref="SourceLocation"/></param>
        public SourceRange(SourceLocation begin, SourceLocation end)
        {
            this.m_value = clang.clang_getRange((CXSourceLocation)begin.Value, (CXSourceLocation)end.Value);
        }

        /// <summary>
        /// Defines the begin
        /// </summary>
        private SourceLocation begin;

        /// <summary>
        /// Gets the Begin
        /// </summary>
        public SourceLocation Begin
        {
            get
            {
                if (this.begin == null)
                {
                    this.begin = new SourceLocation(clang.clang_getRangeStart(this.m_value));
                }
                return this.begin;
            }
        }

        /// <summary>
        /// Defines the end
        /// </summary>
        private SourceLocation end;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXSourceRange m_value;

        /// <summary>
        /// Gets the End
        /// </summary>
        public SourceLocation End
        {
            get
            {
                if (this.end == null)
                {
                    this.end = new SourceLocation(clang.clang_getRangeEnd(this.m_value));
                }
                return this.end;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        /// <summary>
        /// The EqualsCore
        /// </summary>
        /// <param name="clangObject">The clangObject<see cref="ClangObject"/></param>
        /// <returns>The <see cref="bool"/></returns>
        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalRanges(this.m_value, (CXSourceRange)clangObject.Value) > 0;
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.Begin, this.End);
        }
    }
}
