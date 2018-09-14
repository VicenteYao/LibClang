namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexEntityRefInfo" />
    /// </summary>
    public class IndexEntityRefInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexEntityRefInfo"/> class.
        /// </summary>
        /// <param name="cXIdxEntityRefInfo">The cXIdxEntityRefInfo<see cref="CXIdxEntityRefInfo"/></param>
        internal IndexEntityRefInfo(CXIdxEntityRefInfo cXIdxEntityRefInfo)
        {
            this.m_value = cXIdxEntityRefInfo;
        }

        /// <summary>
        /// Gets the EntityRefKind
        /// </summary>
        public CXIdxEntityRefKind EntityRefKind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        /// <summary>
        /// Gets the SymbolRole
        /// </summary>
        public CXSymbolRole SymbolRole
        {
            get
            {
                return this.m_value.role;
            }
        }

        /// <summary>
        /// Defines the parentEntiry
        /// </summary>
        private IndexEntityInfo parentEntiry;

        /// <summary>
        /// Gets the ParentEntity
        /// </summary>
        public unsafe IndexEntityInfo ParentEntity
        {
            get
            {
                if (this.parentEntiry == null)
                {
                    if (this.m_value.referencedEntity != (CXIdxEntityInfo*)0)
                    {
                        this.parentEntiry = new IndexEntityInfo(*this.m_value.parentEntity);
                    }
                }
                return this.parentEntiry;
            }
        }

        /// <summary>
        /// Defines the referencedEntity
        /// </summary>
        private IndexEntityInfo referencedEntity;

        /// <summary>
        /// Gets the ReferencedEntity
        /// </summary>
        public unsafe IndexEntityInfo ReferencedEntity
        {
            get
            {
                if (this.referencedEntity == null)
                {
                    if (this.m_value.referencedEntity != (CXIdxEntityInfo*)0)
                    {
                        this.referencedEntity = new IndexEntityInfo(*this.m_value.referencedEntity);
                    }
                }
                return this.referencedEntity;
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
        /// Defines the m_value
        /// </summary>
        private CXIdxEntityRefInfo m_value;

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
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
