using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class EvalResult:ClangObject<IntPtr>
    {
        internal EvalResult(IntPtr value)
        {
            this.Value = value;
        }

        private int? _intValue;
        public int IntValue
        {
            get
            {
                if (!this._intValue.HasValue)
                {
                    this._intValue = clang.clang_EvalResult_getAsInt(this.Value);
                }
                return this._intValue.Value;
            }
        }

        private double? _doubleValue;
        public double DoubleValue
        {
            get
            {
                if (!this._doubleValue.HasValue)
                {
                    this._doubleValue = clang.clang_EvalResult_getAsDouble(this.Value);
                }
                return this._doubleValue.Value;
            }
        }

        private long? _longValue;
        public long LongValue
        {
            get
            {
                if (!this._longValue.HasValue)
                {
                    this._longValue = clang.clang_EvalResult_getAsLongLong(this.Value);
                }
                return this._longValue.Value;
            }
        }

        private string _stringValue;
        public unsafe string StringValue
        {
            get
            {
                if (this._stringValue ==null)
                {
                    this._stringValue = new string(clang.clang_EvalResult_getAsStr(this.Value));
                }
                return this._stringValue;
            }
        }

        private ulong? _ulongValue;
        public unsafe ulong ULongValue
        {
            get
            {
                if (!this._ulongValue.HasValue)
                {
                    this._ulongValue = clang.clang_EvalResult_getAsuint(this.Value);
                }
                return this._ulongValue.Value;
            }
        }


        private CXEvalResultKind? evalResultKind;
        public CXEvalResultKind EvalResultKind
        {
            get
            {
                if (!this.evalResultKind.HasValue)
                {
                    this.evalResultKind = clang.clang_EvalResult_getKind(this.Value);
                }
                return this.evalResultKind.Value;
            }
        }


        protected override void Dispose()
        {
            clang.clang_EvalResult_dispose(this.Value);
        }

        protected override bool EqualsCore(ClangObject<IntPtr> clangObject)
        {
            return this.Value == clangObject.Value;
        }
    }
}
