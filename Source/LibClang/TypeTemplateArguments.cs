namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="TypeTemplateArguments" />
    /// </summary>
    public class TypeTemplateArguments : ClangObjectList<Type>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXType m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeTemplateArguments"/> class.
        /// </summary>
        /// <param name="type">The type<see cref="CXType"/></param>
        internal TypeTemplateArguments(CXType type)
        {
            this.m_value = type;
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
        /// <returns>The <see cref="Type"/></returns>
        protected override Type EnsureItemAt(int index)
        {
            return new Type(clang.clang_Type_getTemplateArgumentAsType(this.m_value, (uint)index));
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return clang.clang_Type_getNumTemplateArguments(this.m_value);
        }
    }
}
