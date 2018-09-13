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

        private CompletionResult[] completionResults = null;
        public CompletionResult[] CompletionResults
        {
            get
            {
                if (this.completionResults==null)
                {
                    CXCodeCompleteResults* pCodeCompleteResults = (CXCodeCompleteResults*)this.Value;
                    uint resultsCount = pCodeCompleteResults->NumResults;
                    this.completionResults = new CompletionResult[resultsCount];
                    for (uint i = 0; i < resultsCount; i++)
                    {
                        CXCursorKind cursorKind = pCodeCompleteResults->Results[i].CursorKind;
                        CXCompletionResult* pCompletionResult = (CXCompletionResult*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CXCompletionResult)));
                        Marshal.StructureToPtr(pCodeCompleteResults->Results[i], (IntPtr)pCompletionResult, false);
                        this.completionResults[i] = new CompletionResult(cursorKind, (IntPtr)pCompletionResult);
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

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }

    }
}
