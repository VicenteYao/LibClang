using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public delegate CXVisitorResult visit(IntPtr context, CXCursor cXCursor, CXSourceRange cXSourceRange);
    public unsafe struct CXCursorAndRangeVisitor
    {
        public void* context;
        public visit Visit;
    }
}
