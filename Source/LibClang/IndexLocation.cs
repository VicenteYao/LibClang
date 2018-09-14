using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexLocation : ClangObject
    {
        internal IndexLocation(CXIdxLoc value)
        {
            this.m_value = value;
        }

        private SourceLocation _sourceLocation;
        private CXIdxLoc m_value;

        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation==null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_indexLoc_getCXSourceLocation(this.m_value));
                }
                return this._sourceLocation;
            }
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        public override string ToString()
        {
            return this.SourceLocation.ToString();
        }
    }
}
