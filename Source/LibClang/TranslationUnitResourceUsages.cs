using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TranslationUnitResourceUsages : ClangObjectList <TranslationUnitResourceUsageEntry>
    {
        private CXTUResourceUsage m_value;

        internal TranslationUnitResourceUsages(CXTUResourceUsage cXTUResourceUsage)
        {
            this.m_value = cXTUResourceUsage;
        }

        protected internal override ValueType Value { get { return this.m_value; } }

        protected override void Dispose()
        {
            clang.clang_disposeCXTUResourceUsage(this.m_value);
        }

        protected unsafe override TranslationUnitResourceUsageEntry EnsureItemAt(int index)
        {
            return new TranslationUnitResourceUsageEntry(this.m_value.entries[index]);
        }

        protected override int GetCountCore()
        {
            return (int)this.m_value.numEntries;
        }
    }
}
