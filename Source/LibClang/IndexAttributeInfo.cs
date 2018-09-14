using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexAttributeInfo : ClangObject
    {
        internal IndexAttributeInfo(CXIdxAttrInfo attrInfo)
        {
            this.m_value = attrInfo;
        }

        private Cursor cursor;

        public  Cursor Cursor
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
        private CXIdxAttrInfo m_value;

        public  IndexLocation IndexLocation
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

        public CXIdxAttrKind Kind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
