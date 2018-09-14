namespace LibClang
{
    using LibClang.Intertop;
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Defines the <see cref="TranslationUnitResourceUsageEntry" />
    /// </summary>
    public class TranslationUnitResourceUsageEntry : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationUnitResourceUsageEntry"/> class.
        /// </summary>
        /// <param name="resourceUsageEntry">The resourceUsageEntry<see cref="CXTUResourceUsageEntry"/></param>
        internal TranslationUnitResourceUsageEntry(CXTUResourceUsageEntry resourceUsageEntry)
        {
            this.m_value = resourceUsageEntry;
        }

        /// <summary>
        /// Gets the Kind
        /// </summary>
        public CXTUResourceUsageKind Kind
        {
            get
            {
                return this.m_value.kind;
            }
        }

        /// <summary>
        /// Defines the _name
        /// </summary>
        private string _name;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXTUResourceUsageEntry m_value;

        /// <summary>
        /// Gets the Name
        /// </summary>
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

        /// <summary>
        /// Gets the Amount
        /// </summary>
        public int Amount
        {
            get
            {
                return (int)this.m_value.amount;
            }
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get
            {
                return this.m_value;
            }
        }
    }
}
