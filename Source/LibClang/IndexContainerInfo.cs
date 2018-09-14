using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexContainerInfo:ClangObject<IntPtr>
    {
        internal IndexContainerInfo(IntPtr pIndexContainerInfo)
        {
            this.Value = pIndexContainerInfo;
        }

        private Cursor cursor;

        public unsafe Cursor Cursor
        {
            get
            {
                if (this.cursor == null)
                {
                    CXIdxContainerInfo* pIndexContainerInfo = (CXIdxContainerInfo*)this.Value;
                    this.cursor = new Cursor(pIndexContainerInfo->cursor);
                }
                return this.cursor;
            }
        }

    }
}
