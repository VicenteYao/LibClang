namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexBaseClassInfo" />
    /// </summary>
    public class IndexBaseClassInfo : ClangObject
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXIdxBaseClassInfo m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexBaseClassInfo"/> class.
        /// </summary>
        /// <param name="baseClassInfo">The baseClassInfo<see cref="CXIdxBaseClassInfo"/></param>
        internal IndexBaseClassInfo(CXIdxBaseClassInfo baseClassInfo)
        {
            this.m_value = baseClassInfo;
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// Gets the Base
        /// </summary>
        public IndexEntityInfo Base
        {
            get
            {
                if (this._base == null)
                {
                    this._base = new IndexEntityInfo(this.m_value.baseInfo);
                }
                return this._base;
            }
        }

        /// <summary>
        /// Defines the _base
        /// </summary>
        private IndexEntityInfo _base;
    }
}
