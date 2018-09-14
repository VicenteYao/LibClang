namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="DiagnosticSet" />
    /// </summary>
    public class DiagnosticSet : ClangObjectList<Diagnostic>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticSet"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal DiagnosticSet(IntPtr value)
        {
            this.m_value = value;
            this._count = (int)clang.clang_getNumDiagnosticsInSet(this.m_value);
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the _count
        /// </summary>
        private int _count;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The TryLoadDiagnostics
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <param name="diagnosticSet">The diagnosticSet<see cref="DiagnosticSet"/></param>
        /// <param name="error">The error<see cref="CXLoadDiag_Error"/></param>
        /// <returns>The <see cref="bool"/></returns>
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

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_disposeDiagnosticSet(this.m_value);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return this._count;
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="Diagnostic"/></returns>
        protected override Diagnostic EnsureItemAt(int index)
        {
            IntPtr pDiagnostic = clang.clang_getDiagnosticInSet(this.m_value, (uint)index);
            return new Diagnostic(pDiagnostic);
        }
    }
}
