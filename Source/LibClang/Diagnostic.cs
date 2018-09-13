using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Diagnostic : ClangObject<IntPtr>
    {
        internal Diagnostic(IntPtr value)
        {
            this.Value = value;
        }

        private SourceLocation _sourceLocation;

        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation == null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_getDiagnosticLocation(this.Value));
                }
                return _sourceLocation;
            }
        }

        private DiagnosticSet _diagnosticSet;

        public DiagnosticSet DiagnosticSet
        {
            get
            {
                if (this._diagnosticSet==null)
                {
                    this._diagnosticSet = new DiagnosticSet(clang.clang_getChildDiagnostics(this.Value));
                }
                return this._diagnosticSet;
            }
        }

        private string categoryText;
        public string CategoryText
        {
            get
            {
                if (this.categoryText == null)
                {
                    this.categoryText = clang.clang_getDiagnosticCategoryText(this.Value).ToStringAndDispose();
                }
                return this.categoryText;
            }
        }

        

        private string spelling;
        public string Spelling
        {
            get
            {
                if (this.spelling == null)
                {
                    this.spelling = clang.clang_getDiagnosticSpelling(this.Value).ToStringAndDispose();
                }
                return this.spelling;
            }
        }


        protected override void Dispose()
        {
            clang.clang_disposeDiagnostic(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
