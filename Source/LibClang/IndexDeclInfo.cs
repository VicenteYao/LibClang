using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexDeclInfo : ClangObject
    {
        internal IndexDeclInfo(CXIdxDeclInfo cXIdxDeclInfo)
        {
            this.m_value = cXIdxDeclInfo;
        }

        private IndexEntityInfo entityInfo;
        public unsafe IndexEntityInfo EntityInfo
        {
            get
            {
                if (this.entityInfo == null)
                {
                    this.entityInfo = new IndexEntityInfo((IntPtr)this.m_value.entityInfo);
                }
                return this.entityInfo;
            }
        }

        private Cursor cursor;
        public Cursor Cursor
        {
            get
            {
                if (this.cursor==null)
                {
                    this.cursor = new Cursor(this.m_value.cursor);
                }
                return this.cursor;
            }
        }

        private IndexLocation indexLocation;
        public IndexLocation IndexLocation
        {
            get
            {
                if (this.indexLocation==null)
                {
                    this.indexLocation = new IndexLocation(this.m_value.loc);
                }
                return this.indexLocation;
            }
        }

        public bool IsRedeclaration
        {
            get { return this.m_value.isRedeclaration > 0; }

        }

        public bool IsDefinition
        {
            get
            {
                return this.m_value.isDefinition > 0;
            }
        }

        public bool IsContainer
        {
            get
            {
                return this.m_value.isContainer > 0;
            }
        }

        public bool IsImplicit
        {
            get
            {
                return this.m_value.isImplicit > 0;
            }
        }

        public CXIdxDeclInfoFlags Flags
        {
            get
            {
                return (CXIdxDeclInfoFlags)this.m_value.flags;
            }
        }


        private IndexAttributeInfoList attributes;
        private CXIdxDeclInfo m_value;

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

        protected internal override ValueType Value { get { return this.m_value; } }

        public override string ToString()
        {
            return string.Format("{0}{1}", this.IndexLocation, this.EntityInfo);
        }


    }
}
