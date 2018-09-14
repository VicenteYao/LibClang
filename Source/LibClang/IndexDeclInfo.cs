namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexDeclInfo" />
    /// </summary>
    public class IndexDeclInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexDeclInfo"/> class.
        /// </summary>
        /// <param name="cXIdxDeclInfo">The cXIdxDeclInfo<see cref="CXIdxDeclInfo"/></param>
        internal IndexDeclInfo(CXIdxDeclInfo cXIdxDeclInfo)
        {
            this.m_value = cXIdxDeclInfo;
        }

        /// <summary>
        /// Defines the entityInfo
        /// </summary>
        private IndexEntityInfo entityInfo;

        /// <summary>
        /// Gets the EntityInfo
        /// </summary>
        public unsafe IndexEntityInfo EntityInfo
        {
            get
            {
                if (this.entityInfo == null)
                {
                    this.entityInfo = new IndexEntityInfo(*this.m_value.entityInfo);
                }
                return this.entityInfo;
            }
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
        /// Gets a value indicating whether IsRedeclaration
        /// </summary>
        public bool IsRedeclaration
        {
            get { return this.m_value.isRedeclaration > 0; }
        }

        /// <summary>
        /// Gets a value indicating whether IsDefinition
        /// </summary>
        public bool IsDefinition
        {
            get
            {
                return this.m_value.isDefinition > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsContainer
        /// </summary>
        public bool IsContainer
        {
            get
            {
                return this.m_value.isContainer > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsImplicit
        /// </summary>
        public bool IsImplicit
        {
            get
            {
                return this.m_value.isImplicit > 0;
            }
        }

        /// <summary>
        /// Gets the Flags
        /// </summary>
        public CXIdxDeclInfoFlags Flags
        {
            get
            {
                return (CXIdxDeclInfoFlags)this.m_value.flags;
            }
        }

        /// <summary>
        /// Defines the attributes
        /// </summary>
        private IndexAttributeInfoList attributes;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxDeclInfo m_value;

        /// <summary>
        /// Gets the Attributes
        /// </summary>
        public unsafe IndexAttributeInfoList Attributes
        {
            get
            {
                if (this.attributes == null)
                {

                    this.attributes = new IndexAttributeInfoList(this.m_value.attributes, (int)this.m_value.numAttributes);
                }
                return this.attributes;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return string.Format("{0}{1}", this.IndexLocation, this.EntityInfo);
        }
    }
}
