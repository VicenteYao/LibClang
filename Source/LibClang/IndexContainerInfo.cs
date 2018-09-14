namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexContainerInfo" />
    /// </summary>
    public class IndexContainerInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexContainerInfo"/> class.
        /// </summary>
        /// <param name="pIndexContainerInfo">The pIndexContainerInfo<see cref="IntPtr"/></param>
        internal IndexContainerInfo(IntPtr pIndexContainerInfo)
        {
            this.m_value = pIndexContainerInfo;
        }

        /// <summary>
        /// Defines the cursor
        /// </summary>
        private Cursor cursor;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the Cursor
        /// </summary>
        public unsafe Cursor Cursor
        {
            get
            {
                if (this.cursor == null)
                {
                    CXIdxContainerInfo* pIndexContainerInfo = (CXIdxContainerInfo*)this.m_value;
                    this.cursor = new Cursor(pIndexContainerInfo->cursor);
                }
                return this.cursor;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.Value; }
        }
    }
}
