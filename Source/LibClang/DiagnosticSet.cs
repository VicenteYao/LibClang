using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class DiagnosticSet : ClangObjectList<Diagnostic, IntPtr>, IReadOnlyList<Diagnostic>
    {
        internal DiagnosticSet(IntPtr value)
        {
            this.Value = value;
            this._count = (int)clang.clang_getNumDiagnosticsInSet(this.Value);
        }

        private int _count;

        public static bool TryLoadDiagnostics(string fileName, out DiagnosticSet diagnosticSet, out CXLoadDiag_Error error)
        {
            error = CXLoadDiag_Error.CXLoadDiag_None;
            CXString cXString;
            diagnosticSet = null;
            IntPtr diagnostic = clang.clang_loadDiagnostics(fileName, out error, out cXString);
            if (diagnostic == IntPtr.Zero)
            {
                return false;
            }
            diagnosticSet = new DiagnosticSet(diagnostic);
            return true;
        }


        protected override void Dispose()
        {
            clang.clang_disposeDiagnosticSet(this.Value);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }

        protected override Diagnostic EnsureItemAt(int index)
        {
            IntPtr pDiagnostic = clang.clang_getDiagnosticInSet(this.Value, (uint)index);
            return new Diagnostic(pDiagnostic);
        }

    }
}
