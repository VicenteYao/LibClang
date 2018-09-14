using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexContainerInfo:ClangObject
    {
        internal IndexContainerInfo(IntPtr pIndexContainerInfo)
        {
            this.m_value = pIndexContainerInfo;
        }

        private Cursor cursor;
        private IntPtr m_value;

        public unsafe Cursor Cursor
        {
            get
            {
                if (this.cursor == null)
                {
                    CXIdxContainerInfo* pIndexContainerInfo = (CXIdxContainerInfo*)this.m_value;
                    this.cursor = new Cursor(pIndexContainerInfo->cursor);
                }
                return this.cursor;
            }
        }

        protected internal override ValueType Value { get { return this.Value; } }
    }
}
