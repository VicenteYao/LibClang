using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public class IndexBaseClassInfo : ClangObject
    {
        private CXIdxBaseClassInfo m_value;

        internal IndexBaseClassInfo(CXIdxBaseClassInfo baseClassInfo)
        {
            this.m_value = baseClassInfo;
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        public IndexEntityInfo Base
        {
            get
            {
                if (this._base==null)
                {
                    this._base = new IndexEntityInfo(this.m_value.baseInfo);
                }
                return this._base;
            }
        }

        private IndexEntityInfo _base;
        
    }
}
