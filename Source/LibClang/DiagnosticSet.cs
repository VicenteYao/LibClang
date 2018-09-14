using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class DiagnosticSet : ClangObjectList<Diagnostic>
    {
        internal DiagnosticSet(IntPtr value)
        {
            this.m_value = value;
            this._count= (int)clang.clang_getNumDiagnosticsInSet(this.m_value);
        }

        private IntPtr m_value;

        private int _count;

        protected internal override ValueType Value { get { return this.m_value; } }

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
            clang.clang_disposeDiagnosticSet(this.m_value);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }

        protected override Diagnostic EnsureItemAt(int index)
        {
            IntPtr pDiagnostic = clang.clang_getDiagnosticInSet(this.m_value, (uint)index);
            return new Diagnostic(pDiagnostic);
        }

    }
}
