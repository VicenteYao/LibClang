using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class DiagnosticSet : ClangObject<IntPtr>, IReadOnlyList<Diagnostic>, IEnumerable<Diagnostic>
    {
        internal DiagnosticSet(IntPtr value)
        {
            this.Value = value;
        }

        public static bool TryLoadDiagnostics(string fileName, out DiagnosticSet diagnosticSet)
        {
            CXLoadDiag_Error loadDiag_Error = CXLoadDiag_Error.CXLoadDiag_None;
            CXString cXString;
            diagnosticSet = null;
            IntPtr diagnostic = clang.clang_loadDiagnostics(fileName, out loadDiag_Error, out cXString);
            if (diagnostic != IntPtr.Zero)
            {
                diagnosticSet = new DiagnosticSet(diagnostic);
            }
            return diagnostic != IntPtr.Zero;
        }

        private ReadOnlyCollection<Diagnostic> diagnostics;

        protected ReadOnlyCollection<Diagnostic> Diagnostics
        {
            get
            {
                if (this.diagnostics == null)
                {
                    uint count = clang.clang_getNumDiagnosticsInSet(this.Value);
                    Diagnostic[] diagnosticArray = new Diagnostic[count];
                    for (uint i = 0; i < count; i++)
                    {
                        IntPtr pDiagnostic = clang.clang_getDiagnosticInSet(this.Value, i);
                        diagnosticArray[i] = new Diagnostic(pDiagnostic);
                    }
                    this.diagnostics = new ReadOnlyCollection<Diagnostic>(diagnosticArray);
                }
                return this.diagnostics;
            }
        }

        public Diagnostic this[int index]
        {
            get
            {
                return this.Diagnostics[index];
            }
        }

        public int Count
        {
            get
            {
                return this.Diagnostics.Count;
            }
        }

        public IEnumerator<Diagnostic> GetEnumerator()
        {
            return this.Diagnostics.GetEnumerator();
        }

        protected override void Dispose()
        {
            clang.clang_disposeDiagnosticSet(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
