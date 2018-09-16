namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="TranslationUnitResourceUsages" />
    /// </summary>
    internal class TranslationUnitResourceUsages : ClangList<TranslationUnitResourceUsageEntry>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXTUResourceUsage m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationUnitResourceUsages"/> class.
        /// </summary>
        /// <param name="tuResourceUsage">The cXTUResourceUsage<see cref="CXTUResourceUsage"/></param>
        internal TranslationUnitResourceUsages(CXTUResourceUsage tuResourceUsage)
        {
            this.m_value = tuResourceUsage;
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_disposeCXTUResourceUsage(this.m_value);
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="TranslationUnitResourceUsageEntry"/></returns>
        protected unsafe override TranslationUnitResourceUsageEntry EnsureItemAt(int index)
        {
            return new TranslationUnitResourceUsageEntry(this.m_value.entries[index]);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return (int)this.m_value.numEntries;
        }
    }
}
