namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="CursorTemplateArguments" />
    /// </summary>
    public class CursorTemplateArguments : ClangObjectList<TemplateArgument>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXCursor m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="CursorTemplateArguments"/> class.
        /// </summary>
        /// <param name="cursor">The cursor<see cref="CXCursor"/></param>
        internal CursorTemplateArguments(CXCursor cursor)
        {
            this.m_value = cursor;
        }

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
        /// <returns>The <see cref="TemplateArgument"/></returns>
        protected override TemplateArgument EnsureItemAt(int index)
        {
            var kind = clang.clang_Cursor_getTemplateArgumentKind(this.m_value, (uint)index);
            if (kind == CXTemplateArgumentKind.CXTemplateArgumentKind_Integral)
            {
                long longValue = clang.clang_Cursor_getTemplateArgumentValue(this.m_value, (uint)index);
                return new TemplateArgument(longValue);
            }
            Type type = new Type(clang.clang_Cursor_getTemplateArgumentType(this.m_value, (uint)index));
            return new TemplateArgument(type);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return clang.clang_Cursor_getNumTemplateArguments(this.m_value);
        }
    }
}
