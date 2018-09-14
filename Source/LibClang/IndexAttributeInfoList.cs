using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class IndexAttributeInfoList : ClangObjectList<IndexAttributeInfo>
    {
        internal unsafe IndexAttributeInfoList(CXIdxAttrInfo* pAttrInfo, int count)
        {
            this.m_value = (IntPtr)pAttrInfo;
            this._count = count;
        }

        private IntPtr m_value;
        private int _count;

        protected internal override ValueType Value { get { return this.m_value; } }

        protected unsafe override IndexAttributeInfo EnsureItemAt(int index)
        {
            CXIdxAttrInfo* pAttrInfo = (CXIdxAttrInfo*)this.m_value;
            return new IndexAttributeInfo(pAttrInfo[index]);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
