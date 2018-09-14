using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class IndexEntityInfo : ClangObject
    {
        internal IndexEntityInfo(IntPtr entityInfo)
        {
            this.m_value = entityInfo;
        }

        public CXIdxEntityKind Kind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->kind;
            }
        }

        public CXIdxEntityCXXTemplateKind TemplateKind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->templateKind;
            }
        }

        public CXIdxEntityLanguage Language
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->lang;
            }
        }
        private string name;

        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    if (pIndexEntityInfo!=(CXIdxEntityInfo*)0)
                    {
                        this.name = Marshal.PtrToStringAnsi(pIndexEntityInfo->name);
                    }
                }
                return this.name;
            }
        }

        private string usr;
        public string USR
        {
            get
            {
                if (this.usr == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    if (pIndexEntityInfo != (CXIdxEntityInfo*)0)
                    {
                        this.usr = Marshal.PtrToStringAuto(pIndexEntityInfo->USR);
                    }
                }
                return this.usr;
            }
        }

        private Cursor cursor;

        public Cursor Cursor
        {
            get
            {

                if (this.cursor == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    this.cursor = new Cursor(pIndexEntityInfo->cursor);
                }
                return this.cursor;
            }
        }

        private IndexAttributeInfoList attributeInfoList;
        private IntPtr m_value;

        public IndexAttributeInfoList Attributes
        {
            get
            {
                if (this.attributeInfoList == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    this.attributeInfoList = new IndexAttributeInfoList(pIndexEntityInfo->attributes, (int)pIndexEntityInfo->numAttributes);
                }
                return this.attributeInfoList;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", this.Language, this.Kind, this.Name);
        }

    }
}
