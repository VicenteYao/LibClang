﻿using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class Diagnostic : ClangObject
    {
        internal Diagnostic(IntPtr value)
        {
            this.m_value = value;
        }

        private IntPtr m_value;

        private static CXDiagnosticDisplayOptions _CXDiagnosticDisplayOptions;
        public static CXDiagnosticDisplayOptions DefaultDisplayOptions
        {
            get
            {
                _CXDiagnosticDisplayOptions = (CXDiagnosticDisplayOptions)clang.clang_defaultDiagnosticDisplayOptions();
                return _CXDiagnosticDisplayOptions;
            }
        }

        public string Format(CXDiagnosticDisplayOptions diagnosticDisplayOptions)
        {
            return clang.clang_formatDiagnostic(this.m_value, (uint)diagnosticDisplayOptions).ToStringAndDispose();
        }

        private SourceLocation _sourceLocation;

        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation == null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_getDiagnosticLocation(this.m_value));
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
                    this._diagnosticSet = new DiagnosticSet(clang.clang_getChildDiagnostics(this.m_value));
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
                    this.categoryText = clang.clang_getDiagnosticCategoryText(this.m_value).ToStringAndDispose();
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
                    this.spelling = clang.clang_getDiagnosticSpelling(this.m_value).ToStringAndDispose();
                }
                return this.spelling;
            }
        }


        protected override void Dispose()
        {
            clang.clang_disposeDiagnostic(this.m_value);
        }


        private int _category;

        public int Category
        {
            get
            {
                this._category = (int)clang.clang_getDiagnosticCategory(this.m_value);
                return this._category;
            }
        }

        private CXDiagnosticSeverity _severity;
        CXDiagnosticSeverity Severity
        {
            get
            {
                this._severity = clang.clang_getDiagnosticSeverity(this.m_value);
                return this._severity;
            }
        }

        private SourceRange[] _sourceRanges;
        public SourceRange[] SourceRanges
        {
            get
            {
                if (this._sourceRanges == null)
                {
                    uint sourceRangesCount = clang.clang_getDiagnosticNumRanges(this.m_value);
                    this._sourceRanges = new SourceRange[(int)sourceRangesCount];
                    for (uint i = 0; i < sourceRangesCount; i++)
                    {
                        this._sourceRanges[i] = new SourceRange(clang.clang_getDiagnosticRange(this.m_value, i));
                    }
                }
                return this._sourceRanges;
            }
        }

        private FixIt[] _fixIts;
        public FixIt[] FixIts
        {
            get
            {
                if (this._fixIts==null)
                {
                    uint fixitsCount = clang.clang_getDiagnosticNumFixIts(this.m_value);
                    this._fixIts = new FixIt[fixitsCount];
                    for (uint i = 0; i < fixitsCount; i++)
                    {
                        CXSourceRange xSourceRange;
                        string text = clang.clang_getDiagnosticFixIt(this.m_value, i, out xSourceRange).ToStringAndDispose();
                        SourceRange sourceRange = new SourceRange(xSourceRange);
                        this._fixIts[i] = new FixIt(text, sourceRange);
                    }
                }
                return this._fixIts;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        public override string ToString()
        {
            return string.Format("{0}:{1}", this.CategoryText, this.Spelling);
        }
    }
}
