namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="IndexEntityInfo" />
    /// </summary>
    public unsafe class IndexEntityInfo : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexEntityInfo"/> class.
        /// </summary>
        /// <param name="entityInfo">The entityInfo<see cref="IntPtr"/></param>
        internal IndexEntityInfo(IntPtr entityInfo)
        {
            this.m_value = entityInfo;
        }

        /// <summary>
        /// Gets the Kind
        /// </summary>
        public CXIdxEntityKind Kind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->kind;
            }
        }

        /// <summary>
        /// Gets the TemplateKind
        /// </summary>
        public CXIdxEntityCXXTemplateKind TemplateKind
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->templateKind;
            }
        }

        /// <summary>
        /// Gets the Language
        /// </summary>
        public CXIdxEntityLanguage Language
        {
            get
            {
                CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                return pIndexEntityInfo->lang;
            }
        }

        /// <summary>
        /// Defines the name
        /// </summary>
        private string name;

        /// <summary>
        /// Gets the Name
        /// </summary>
        public string Name
        {
            get
            {
                if (this.name == null)
                {
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    if (pIndexEntityInfo != (CXIdxEntityInfo*)0)
                    {
                        this.name = Marshal.PtrToStringAnsi(pIndexEntityInfo->name);
                    }
                }
                return this.name;
            }
        }

        /// <summary>
        /// Defines the usr
        /// </summary>
        private string usr;

        /// <summary>
        /// Gets the USR
        /// </summary>
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
                    CXIdxEntityInfo* pIndexEntityInfo = (CXIdxEntityInfo*)this.m_value;
                    this.cursor = new Cursor(pIndexEntityInfo->cursor);
                }
                return this.cursor;
            }
        }

        /// <summary>
        /// Defines the attributeInfoList
        /// </summary>
        private IndexAttributeInfoList attributeInfoList;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the Attributes
        /// </summary>
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
            return string.Format("{0},{1},{2}", this.Language, this.Kind, this.Name);
        }
    }
}
