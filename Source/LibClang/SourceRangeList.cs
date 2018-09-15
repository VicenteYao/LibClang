namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="SourceRangeList" />
    /// </summary>
    public class SourceRangeList : ClangList<SourceRange>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXSourceRangeList m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceRangeList"/> class.
        /// </summary>
        /// <param name="sourceRangeList">The sourceRangeList<see cref="CXSourceRangeList"/></param>
        internal SourceRangeList(CXSourceRangeList sourceRangeList)
        {
            this.m_value = sourceRangeList;
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
        protected unsafe override void Dispose()
        {
            clang.clang_disposeSourceRangeList((IntPtr)this.m_value.ranges);
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="SourceRange"/></returns>
        protected unsafe override SourceRange EnsureItemAt(int index)
        {
            return new SourceRange(this.m_value.ranges[index]);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return (int)this.m_value.count;
        }
    }
}
