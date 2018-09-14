namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CodeCompleteResults" />
    /// </summary>
    public unsafe class CodeCompleteResults : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCompleteResults"/> class.
        /// </summary>
        /// <param name="completeResults">The completeResults<see cref="CXCodeCompleteResults*"/></param>
        internal CodeCompleteResults(CXCodeCompleteResults* completeResults)
        {
            this.m_value = completeResults;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCodeCompleteResults* m_value;

        /// <summary>
        /// Defines the completionResults
        /// </summary>
        private CompletionResultList completionResults;

        /// <summary>
        /// Gets the CompletionResults
        /// </summary>
        public unsafe CompletionResultList CompletionResults
        {
            get
            {
                if (this.completionResults == null)
                {
                    this.completionResults = new CompletionResultList(this.m_value);
                }
                return this.completionResults;
            }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_disposeCodeCompleteResults((CXCodeCompleteResults*)(IntPtr)this.m_value);
        }

        /// <summary>
        /// Defines the _diagnostics
        /// </summary>
        private Diagnostic[] _diagnostics;

        /// <summary>
        /// Gets the Diagnostics
        /// </summary>
        public Diagnostic[] Diagnostics
        {
            get
            {
                if (this._diagnostics == null)
                {
                    uint diagnosticCount = clang.clang_codeCompleteGetNumDiagnostics(this.m_value);
                    this._diagnostics = new Diagnostic[diagnosticCount];
                    for (uint i = 0; i < diagnosticCount; i++)
                    {
                        this._diagnostics[i] = new Diagnostic(clang.clang_codeCompleteGetDiagnostic(this.m_value, i));
                    }
                }
                return this._diagnostics;
            }
        }

        /// <summary>
        /// Defines the context
        /// </summary>
        private CXCompletionContext? context;

        /// <summary>
        /// Gets the Context
        /// </summary>
        public CXCompletionContext Context
        {
            get
            {
                if (!this.context.HasValue)
                {

                    this.context = (CXCompletionContext)clang.clang_codeCompleteGetContexts(this.m_value);
                }
                return this.context.Value;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return (IntPtr)this.m_value; }
        }

        /// <summary>
        /// The Sort
        /// </summary>
        public void Sort()
        {
            clang.clang_sortCodeCompletionResults(this.m_value->Results, this.m_value->NumResults);
        }
    }
}
