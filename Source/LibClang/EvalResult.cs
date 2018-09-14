using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class EvalResult : ClangObject
    {
        internal EvalResult(IntPtr value)
        {
            this.m_value = value;
        }

        private IntPtr m_value;

        private int _intValue;
        public int IntValue
        {
            get
            {
                this._intValue = clang.clang_EvalResult_getAsInt(this.m_value);
                return this._intValue;
            }
        }

        private double _doubleValue;
        public double DoubleValue
        {
            get
            {
                this._doubleValue = clang.clang_EvalResult_getAsDouble(this.m_value);
                return this._doubleValue;
            }
        }

        private long _longValue;
        public long LongValue
        {
            get
            {
                this._longValue = clang.clang_EvalResult_getAsLongLong(this.m_value);
                return this._longValue;
            }
        }

        private string _stringValue;
        public unsafe string StringValue
        {
            get
            {
                this._stringValue = new string(clang.clang_EvalResult_getAsStr(this.m_value));
                return this._stringValue;
            }
        }

        private ulong _ulongValue;
        public unsafe ulong ULongValue
        {
            get
            {
                this._ulongValue = clang.clang_EvalResult_getAsuint(this.m_value);
                return this._ulongValue;
            }
        }


        private CXEvalResultKind evalResultKind;
        public CXEvalResultKind EvalResultKind
        {
            get
            {
                this.evalResultKind = clang.clang_EvalResult_getKind(this.m_value);
                return this.evalResultKind;
            }
        }

        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        protected override void Dispose()
        {
            clang.clang_EvalResult_dispose(this.m_value);
        }
    }
}
