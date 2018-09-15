namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="IndexAttributeInfoList" />
    /// </summary>
    public class IndexAttributeInfoList : ClangList<IndexAttributeInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexAttributeInfoList"/> class.
        /// </summary>
        /// <param name="pAttrInfo">The pAttrInfo<see cref="CXIdxAttrInfo*"/></param>
        /// <param name="count">The count<see cref="int"/></param>
        internal unsafe IndexAttributeInfoList(CXIdxAttrInfo* pAttrInfo, int count)
        {
            this.m_value = (IntPtr)pAttrInfo;
            this._count = count;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Defines the _count
        /// </summary>
        private int _count;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="IndexAttributeInfo"/></returns>
        protected unsafe override IndexAttributeInfo EnsureItemAt(int index)
        {
            CXIdxAttrInfo* pAttrInfo = (CXIdxAttrInfo*)this.m_value;
            return new IndexAttributeInfo(pAttrInfo[index]);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
