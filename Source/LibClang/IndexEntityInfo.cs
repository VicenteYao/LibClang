using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public unsafe class IndexEntityInfo : ClangObject<IntPtr>
    {
        internal IndexEntityInfo(IntPtr entityInfo)
        {
            this.Value = entityInfo;
        }

        public CXIdxEntityKind Kind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
                return pIndexEntityInfo->kind;
            }
        }

        public CXIdxEntityCXXTemplateKind TemplateKind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
                return pIndexEntityInfo->templateKind;
            }
        }

        public CXIdxEntityLanguage Language
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
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
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
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
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
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
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
                    this.cursor = new Cursor(pIndexEntityInfo->cursor);
                }
                return this.cursor;
            }
        }

        private IndexAttributeInfoList attributeInfoList;
        public IndexAttributeInfoList Attributes
        {
            get
            {
                if (this.attributeInfoList == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.Value;
                    this.attributeInfoList = new IndexAttributeInfoList(pIndexEntityInfo->attributes, (int)pIndexEntityInfo->numAttributes);
                }
                return this.attributeInfoList;
            }
        }

        public override string ToString()
        {
            return string.Format("{0},{1},{2}", this.Language, this.Kind, this.Name);
        }

    }
}
