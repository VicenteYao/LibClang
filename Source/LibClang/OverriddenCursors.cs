namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="OverriddenCursors" />
    /// </summary>
    public unsafe class OverriddenCursors : ClangObjectList<Cursor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OverriddenCursors"/> class.
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        internal OverriddenCursors(CXCursor cursor)
        {
            this.m_value = cursor;
            uint cursorsCount = 0;
            clang.clang_getOverriddenCursors(this.m_value, out pCursors, out cursorsCount);
            this._count = (int)cursorsCount;
        }

        /// <summary>
        /// Defines the pCursors
        /// </summary>
        private CXCursor* pCursors;

        /// <summary>
        /// Defines the _count
        /// </summary>
        private int _count;

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCursor m_value;

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
            clang.clang_disposeOverriddenCursors(this.pCursors);
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="Cursor"/></returns>
        protected unsafe override Cursor EnsureItemAt(int index)
        {
            return new Cursor(this.pCursors[index]);
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
