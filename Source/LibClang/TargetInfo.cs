using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TargetInfo : ClangObject<IntPtr>
    {
        internal unsafe TargetInfo(IntPtr value)
        {
            this.Value = value;
            this.PointerWidth = clang.clang_TargetInfo_getPointerWidth(value);
            CXString tripleString = clang.clang_TargetInfo_getTriple(value);
            this.Triple = NativeMethodsHelper.ToStringAndDispose(tripleString);
        }

        public string Triple { get; private set; }

        protected override void Dispose()
        {
            clang.clang_TargetInfo_dispose(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }

        public int PointerWidth
        {
            get;
            private set;
        }


    }
}
