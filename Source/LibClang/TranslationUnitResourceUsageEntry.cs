using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class TranslationUnitResourceUsageEntry : ClangObject
    {


        internal TranslationUnitResourceUsageEntry(CXTUResourceUsageEntry resourceUsageEntry)
        {
            this.m_value = resourceUsageEntry;
        }

        public CXTUResourceUsageKind Kind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        private string _name;
        private CXTUResourceUsageEntry m_value;

        public string Name
        {
            get
            {
                if (this._name == null)
                {
                    this._name = Marshal.PtrToStringAnsi(clang.clang_getTUResourceUsageName(this.Kind));
                }
                return this._name;
            }
        }

        public int Amount
        {
            get
            {
                return (int)this.m_value.amount;
            }
        }

        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }
    }
}
