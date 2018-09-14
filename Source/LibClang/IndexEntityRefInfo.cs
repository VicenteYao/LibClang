using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexEntityRefInfo : ClangObject
    {

        internal IndexEntityRefInfo(CXIdxEntityRefInfo cXIdxEntityRefInfo)
        {
            this.m_value = cXIdxEntityRefInfo;
        }

        public CXIdxEntityRefKind EntityRefKind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        public CXSymbolRole SymbolRole
        {
            get
            {
                return this.m_value.role;
            }
        }

        private IndexEntityInfo parentEntiry;
        public unsafe IndexEntityInfo ParentEntity
        {
            get
            {
                if (this.parentEntiry == null)
                {
                    if (this.m_value.referencedEntity != (CXIdxEntityInfo*)0)
                    {
                        this.parentEntiry = new IndexEntityInfo((IntPtr)this.m_value.parentEntity);
                    }
                }
                return this.parentEntiry;
            }
        }

        private IndexEntityInfo referencedEntity;
        public unsafe IndexEntityInfo ReferencedEntity
        {
            get
            {
                if (this.referencedEntity == null)
                {
                    if (this.m_value.referencedEntity != (CXIdxEntityInfo*)0)
                    {
                        this.referencedEntity = new IndexEntityInfo((IntPtr)this.m_value.referencedEntity);
                    }
                }
                return this.referencedEntity;
            }
        }

        private Cursor cursor;
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

        private IndexLocation indexLocation;
        private CXIdxEntityRefInfo m_value;

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

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
