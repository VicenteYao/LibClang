using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRange : ClangObject
    {

        static SourceRange()
        {
            SourceRange.Null = new SourceRange(clang.clang_getNullRange());
        }

        public static  SourceRange Null { get; private set; }

        internal SourceRange(CXSourceRange sourceRange)
        {
            this.m_value = sourceRange;
        }


        public bool IsNull
        {
            get
            {
                return clang.clang_Range_isNull(this.m_value) > 0;
            }
        }

        public SourceRange(SourceLocation begin, SourceLocation end)
        {
            this.m_value = clang.clang_getRange((CXSourceLocation)begin.Value, (CXSourceLocation)end.Value);
        }

        private SourceLocation begin;

        public SourceLocation Begin
        {
            get
            {
                if (this.begin==null)
                {
                    this.begin = new SourceLocation(clang.clang_getRangeStart(this.m_value));
                }
                return this.begin;
            }
        }

        private SourceLocation end;
        private CXSourceRange m_value;

        public SourceLocation End
        {
            get
            {
                if (this.end == null)
                {
                    this.end = new SourceLocation(clang.clang_getRangeEnd(this.m_value));
                }
                return this.end;
            }
        }

        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        protected override bool EqualsCore(ClangObject clangObject)
        {
            return clang.clang_equalRanges(this.m_value, (CXSourceRange)clangObject.Value) > 0;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.Begin, this.End);
        }
    }
}
