using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class SourceRange : ClangObject<CXSourceRange>
    {

        static SourceRange()
        {
            SourceRange.Null = new SourceRange(clang.clang_getNullRange());
        }

        public static  SourceRange Null { get; private set; }

        internal SourceRange(CXSourceRange sourceRange)
        {
            this.Value = sourceRange;
        }

        public SourceRange(SourceLocation begin, SourceLocation end)
        {
            this.Value = clang.clang_getRange(begin.Value, end.Value);
        }

        private SourceLocation begin;

        public SourceLocation Begin
        {
            get
            {
                if (this.begin==null)
                {
                    this.begin = new SourceLocation(clang.clang_getRangeStart(this.Value));
                }
                return this.begin;
            }
        }

        private SourceLocation end;
        public SourceLocation End
        {
            get
            {
                if (this.end == null)
                {
                    this.end = new SourceLocation(clang.clang_getRangeEnd(this.Value));
                }
                return this.end;
            }
        }

        protected override bool EqualsCore(ClangObject<CXSourceRange> clangObject)
        {
            return clang.clang_equalRanges(this.Value, clangObject.Value) > 0;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.Begin, this.End);
        }
    }
}
