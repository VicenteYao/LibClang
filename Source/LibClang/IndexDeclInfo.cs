﻿using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexDeclInfo : ClangObject<CXIdxDeclInfo>
    {
        internal IndexDeclInfo(CXIdxDeclInfo cXIdxDeclInfo)
        {
            this.Value = cXIdxDeclInfo;
        }

        private IndexEntityInfo entityInfo;
        public IndexEntityInfo EntityInfo
        {
            get
            {
                if (this.entityInfo == null)
                {
                    this.entityInfo = new IndexEntityInfo(this.Value.entityInfo);
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
                if (this.indexLocation==null)
                {
                    this.indexLocation = new IndexLocation(this.Value.loc);
                }
                return this.indexLocation;
            }
        }

        public bool IsRedeclaration
        {
            get { return this.Value.isRedeclaration > 0; }

        }

        public bool IsDefinition
        {
            get
            {
                return this.Value.isDefinition > 0;
            }
        }

        public bool IsContainer
        {
            get
            {
                return this.Value.isContainer > 0;
            }
        }

        public bool IsImplicit
        {
            get
            {
                return this.Value.isImplicit > 0;
            }
        }

        public CXIdxDeclInfoFlags Flags
        {
            get
            {
                return (CXIdxDeclInfoFlags)this.Value.flags;
            }
        }

        public IndexAttributeInfo[] Attributes
        {
            get;
        }




    }
}
