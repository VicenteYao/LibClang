using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexEntityRefInfo : ClangObject<CXIdxEntityRefInfo>
    {

        internal IndexEntityRefInfo(CXIdxEntityRefInfo cXIdxEntityRefInfo)
        {
            this.Value = cXIdxEntityRefInfo;
        }

        public CXIdxEntityRefKind EntityRefKind
        {
            get
            {
                return this.Value.kind;
            }
        }

        public CXSymbolRole SymbolRole
        {
            get
            {
                return this.Value.role;
            }
        }

        private IndexEntityInfo parentEntiry;
        public unsafe IndexEntityInfo ParentEntity
        {
            get
            {
                if (this.parentEntiry == null)
                {
                    this.parentEntiry = new IndexEntityInfo((IntPtr)this.Value.parentEntity);
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
                    this.referencedEntity = new IndexEntityInfo((IntPtr)this.Value.parentEntity);
                }
                return this.referencedEntity;
            }
        }

        private IndexLocation location;
        public IndexLocation Location
        {
            get
            {
                if (this.location == null)
                {
                    this.location = new IndexLocation(this.Value.loc);
                }
                return this.location;
            }
        }

        private Cursor cursor;
        public Cursor Cursor
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
        public IndexLocation IndexLocation
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


    }
}
