namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="EvalResult" />
    /// </summary>
    public class EvalResult : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EvalResult"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal EvalResult(IntPtr value)
        {
            this.m_value = value;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the _intValue
        /// </summary>
        private int _intValue;

        /// <summary>
        /// Gets the IntValue
        /// </summary>
        public int IntValue
        {
            get
            {
                this._intValue = clang.clang_EvalResult_getAsInt(this.m_value);
                return this._intValue;
            }
        }

        /// <summary>
        /// Defines the _doubleValue
        /// </summary>
        private double _doubleValue;

        /// <summary>
        /// Gets the DoubleValue
        /// </summary>
        public double DoubleValue
        {
            get
            {
                this._doubleValue = clang.clang_EvalResult_getAsDouble(this.m_value);
                return this._doubleValue;
            }
        }

        /// <summary>
        /// Defines the _longValue
        /// </summary>
        private long _longValue;

        /// <summary>
        /// Gets the LongValue
        /// </summary>
        public long LongValue
        {
            get
            {
                this._longValue = clang.clang_EvalResult_getAsLongLong(this.m_value);
                return this._longValue;
            }
        }

        /// <summary>
        /// Defines the _stringValue
        /// </summary>
        private string _stringValue;

        /// <summary>
        /// Gets the StringValue
        /// </summary>
        public unsafe string StringValue
        {
            get
            {
                this._stringValue = Marshal.PtrToStringAnsi(clang.clang_EvalResult_getAsStr(this.m_value));
                return this._stringValue;
            }
        }

        /// <summary>
        /// Defines the _ulongValue
        /// </summary>
        private ulong _ulongValue;

        /// <summary>
        /// Gets the ULongValue
        /// </summary>
        public unsafe ulong ULongValue
        {
            get
            {
                this._ulongValue = clang.clang_EvalResult_getAsuint(this.m_value);
                return this._ulongValue;
            }
        }

        /// <summary>
        /// Defines the evalResultKind
        /// </summary>
        private CXEvalResultKind evalResultKind;

        /// <summary>
        /// Gets the EvalResultKind
        /// </summary>
        public CXEvalResultKind EvalResultKind
        {
            get
            {
                this.evalResultKind = clang.clang_EvalResult_getKind(this.m_value);
                return this.evalResultKind;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_EvalResult_dispose(this.m_value);
        }
    }
}
