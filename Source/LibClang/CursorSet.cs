namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CursorSet" />
    /// </summary>
    public class CursorSet : ClangObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CursorSet"/> class.
        /// </summary>
        public CursorSet()
        {
            this.m_value = clang.clang_createCXCursorSet();
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private IntPtr m_value;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value => throw new NotImplementedException();

        /// <summary>
        /// The Contains
        /// </summary>
        /// <param name="cursor">The cursor<see cref="Cursor"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool Contains(Cursor cursor)
        {
            return clang.clang_CXCursorSet_contains(this.m_value, (CXCursor)cursor.Value) > 0;
        }

        /// <summary>
        /// The Insert
        /// </summary>
        /// <param name="cursor">The cursor<see cref="Cursor"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public bool Insert(Cursor cursor)
        {
            return clang.clang_CXCursorSet_insert(this.m_value, (CXCursor)cursor.Value) > 0;
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        protected override void DisposeCore()
        {
            clang.clang_disposeCXCursorSet(this.m_value);
        }
    }
}
