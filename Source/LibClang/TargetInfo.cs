using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TargetInfo : ClangObject
    {
        internal unsafe TargetInfo(IntPtr value)
        {
            this.m_value = value;
            this.PointerWidth = clang.clang_TargetInfo_getPointerWidth(value);
            CXString tripleString = clang.clang_TargetInfo_getTriple(value);
            this.Triple = NativeMethodsHelper.ToStringAndDispose(tripleString);
        }

        public string Triple { get; private set; }

        protected override void Dispose()
        {
            clang.clang_TargetInfo_dispose(this.m_value);
        }

        private IntPtr m_value;

        public int PointerWidth
        {
            get;
            private set;
        }

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
