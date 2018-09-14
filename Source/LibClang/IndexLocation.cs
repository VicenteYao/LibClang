using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class IndexLocation : ClangObject<CXIdxLoc>
    {
        internal IndexLocation(CXIdxLoc value)
        {
            this.Value = value;
        }

        private SourceLocation _sourceLocation;

        public SourceLocation SourceLocation
        {
            get
            {
                if (this._sourceLocation==null)
                {
                    this._sourceLocation = new SourceLocation(clang.clang_indexLoc_getCXSourceLocation(this.Value));
                }
                return this._sourceLocation;
            }
        }
    }
}
