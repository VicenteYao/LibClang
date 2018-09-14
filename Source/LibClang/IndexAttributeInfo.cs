using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexAttributeInfo : ClangObject<CXIdxAttrInfo>
    {
        internal IndexAttributeInfo(CXIdxAttrInfo attrInfo)
        {
            this.Value = attrInfo;
        }

        private Cursor cursor;

        public  Cursor Cursor
        {
            get
            {
                if (this.cursor == null)
                {
                    this.cursor = new Cursor(this.Value.cursor);
                }
                return this.cursor;
            }
        }

        private IndexLocation indexLocation;

        public  IndexLocation IndexLocation
        {
            get
            {
                if (this.indexLocation == null)
                {
                    this.indexLocation = new IndexLocation(this.Value.loc);
                }
                return this.indexLocation;
            }
        }

        public CXIdxAttrKind Kind
        {
            get
            {
                return this.Value.kind;
            }
        }

    }
}
