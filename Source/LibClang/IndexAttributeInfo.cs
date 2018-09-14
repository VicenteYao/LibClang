namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexAttributeInfo" />
    /// </summary>
    public class IndexAttributeInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexAttributeInfo"/> class.
        /// </summary>
        /// <param name="attrInfo">The attrInfo<see cref="CXIdxAttrInfo"/></param>
        internal IndexAttributeInfo(CXIdxAttrInfo attrInfo)
        {
            this.m_value = attrInfo;
        }

        /// <summary>
        /// Defines the cursor
        /// </summary>
        private Cursor cursor;

        /// <summary>
        /// Gets the Cursor
        /// </summary>
        public Cursor Cursor
        {
            get
            {
                if (this.cursor == null)
                {
                    this.cursor = new Cursor(this.m_value.cursor);
                }
                return this.cursor;
            }
        }

        /// <summary>
        /// Defines the indexLocation
        /// </summary>
        private IndexLocation indexLocation;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxAttrInfo m_value;

        /// <summary>
        /// Gets the IndexLocation
        /// </summary>
        public IndexLocation IndexLocation
        {
            get
            {
                if (this.indexLocation == null)
                {
                    this.indexLocation = new IndexLocation(this.m_value.loc);
                }
                return this.indexLocation;
            }
        }

        /// <summary>
        /// Gets the Kind
        /// </summary>
        public CXIdxAttrKind Kind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
