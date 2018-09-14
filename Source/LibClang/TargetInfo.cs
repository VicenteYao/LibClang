namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="TargetInfo" />
    /// </summary>
    public class TargetInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TargetInfo"/> class.
        /// </summary>
        /// <param name="value">The value<see cref="IntPtr"/></param>
        internal unsafe TargetInfo(IntPtr value)
        {
            this.m_value = value;
            this.PointerWidth = clang.clang_TargetInfo_getPointerWidth(value);
            CXString tripleString = clang.clang_TargetInfo_getTriple(value);
            this.Triple = NativeMethodsHelper.ToStringAndDispose(tripleString);
        }

        /// <summary>
        /// Gets the Triple
        /// </summary>
        public string Triple { get; private set; }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void Dispose()
        {
            clang.clang_TargetInfo_dispose(this.m_value);
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the PointerWidth
        /// </summary>
        public int PointerWidth { get; private set; }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
