using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TranslationUnitResourceUsage : ClangObject<CXTUResourceUsage>
    {
        internal TranslationUnitResourceUsage(CXTUResourceUsage cXTUResourceUsage)
        {
            this.Value = cXTUResourceUsage;
        }


        protected override void Dispose()
        {
            clang.clang_disposeCXTUResourceUsage(this.Value);
        }

    }
}
