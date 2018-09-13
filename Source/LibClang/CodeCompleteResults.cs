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



        [StructLayout(LayoutKind.Sequential)]
        private class CXCodeCompleteResultsObject
        {
            public CXCompletionResult* Results;

            /**
             * The number of code-completion results stored in the
             * \c Results array.
             */
            public uint NumResults;
        }

        private CompletionResult[] completionResults = null;
        public CompletionResult[] CompletionResults
        {
            get
            {
                if (this.completionResults == null)
                {
                    CXCodeCompleteResultsObject codeCompleteResults = new CXCodeCompleteResultsObject();
                    Pointer<CXCodeCompleteResultsObject>.FromPointer(this.Value, codeCompleteResults);
                    uint resultsCount = codeCompleteResults.NumResults;
                    this.completionResults = new CompletionResult[resultsCount];
                    var pCXCodeCompleteResults = (CXCodeCompleteResults*)this.Value;
                    for (uint i = 0; i < resultsCount; i++)
                    {
                        CXCompletionResult completionResult = codeCompleteResults.Results[i];
                        uint fixitCount = clang.clang_getCompletionNumFixIts(pCXCodeCompleteResults, i);
                        FixIt[] fixIts = new FixIt[fixitCount];
                        for (uint J = 0; J < fixitCount; J++)
                        {
                            CXSourceRange xSourceRange;
                            string text = clang.clang_getCompletionFixIt(pCXCodeCompleteResults, i, J, out xSourceRange).ToStringAndDispose();
                            SourceRange sourceRange = new SourceRange(xSourceRange);
                            fixIts[i] = new FixIt(text, sourceRange);
                        }
                        this.completionResults[i] = new CompletionResult(completionResult, fixIts);
                    }
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
