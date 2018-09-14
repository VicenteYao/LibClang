using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;
using System.Runtime.InteropServices;

namespace LibClang
{
    public unsafe class CodeCompleteResults : ClangObject<IntPtr>
    {
        internal CodeCompleteResults(IntPtr completeResults)
        {
            this.Value = completeResults;
        }

        private CompletionResultList completionResults;
        public unsafe CompletionResultList CompletionResults
        {
            get
            {
                if (this.completionResults == null)
                {
                    this.completionResults = new CompletionResultList((CXCodeCompleteResults*)this.Value);
                }
                return this.completionResults;
            }
        }

        protected override void Dispose()
        {
            clang.clang_disposeCodeCompleteResults((CXCodeCompleteResults*)this.Value);
        }

        private Diagnostic[] _diagnostics;
        public Diagnostic[] Diagnostics
        {
            get
            {
                if (this._diagnostics == null)
                {
                    uint diagnosticCount = clang.clang_codeCompleteGetNumDiagnostics((CXCodeCompleteResults*)this.Value);
                    this._diagnostics = new Diagnostic[diagnosticCount];
                    for (uint i = 0; i < diagnosticCount; i++)
                    {
                        this._diagnostics[i] = new Diagnostic(clang.clang_codeCompleteGetDiagnostic((CXCodeCompleteResults*)this.Value, i));
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
                    
                    this.context = (CXCompletionContext)clang.clang_codeCompleteGetContexts((CXCodeCompleteResults*)this.Value);
                }
                return this.context.Value;
            }
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }

    }
}
