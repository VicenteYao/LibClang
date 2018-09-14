using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexCXXClassDeclInfo : ClangObject
    {
        private CXIdxCXXClassDeclInfo m_value;

        internal IndexCXXClassDeclInfo(CXIdxCXXClassDeclInfo classDeclInfo)
        {
            this.m_value = classDeclInfo;
        }

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
