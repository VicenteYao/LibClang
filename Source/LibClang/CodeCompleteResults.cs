using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;
using System.Runtime.InteropServices;

namespace LibClang
{
    public unsafe class CodeCompleteResults : ClangObject
    {
        internal CodeCompleteResults(CXCodeCompleteResults* completeResults)
        {
            this.m_value = completeResults;
        }

        private CXCodeCompleteResults* m_value;

        private CompletionResultList completionResults;
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

        protected override void Dispose()
        {
            clang.clang_disposeCodeCompleteResults((CXCodeCompleteResults*)(IntPtr)this.m_value);
        }

        private Diagnostic[] _diagnostics;
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

        private CXCompletionContext? context;
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

        protected internal override ValueType Value { get { return (IntPtr)this.m_value; } }


    }
}
