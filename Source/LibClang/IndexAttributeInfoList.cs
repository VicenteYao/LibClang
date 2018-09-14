using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class IndexAttributeInfoList : ClangObjectList<IndexAttributeInfo, IntPtr>, IReadOnlyList<IndexAttributeInfo>
    {
        internal unsafe IndexAttributeInfoList(CXIdxAttrInfo* pAttrInfo, int count)
        {
            this.Value = (IntPtr)pAttrInfo;
            this._count = count;
        }

        private int _count;

        protected unsafe override IndexAttributeInfo EnsureItemAt(int index)
        {
            CXIdxAttrInfo* pAttrInfo = (CXIdxAttrInfo*)this.Value;
            return new IndexAttributeInfo(pAttrInfo[index]);
        }

        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
