namespace LibClang.Intertop
{
    using System;

    /// <summary>
    /// Defines the <see cref="CXIdxEntityInfo" />
    /// </summary>
    public unsafe struct CXIdxEntityInfo
    {
        /// <summary>
        /// Defines the kind
        /// </summary>
        public CXIdxEntityKind kind;

        /// <summary>
        /// Defines the templateKind
        /// </summary>
        public CXIdxEntityCXXTemplateKind templateKind;

        /// <summary>
        /// Defines the lang
        /// </summary>
        public CXIdxEntityLanguage lang;

        /// <summary>
        /// Defines the name
        /// </summary>
        public IntPtr name;

        /// <summary>
        /// Defines the USR
        /// </summary>
        public IntPtr USR;

        /// <summary>
        /// Defines the cursor
        /// </summary>
        public CXCursor cursor;

        /// <summary>
        /// Defines the attributes
        /// </summary>
        public CXIdxAttrInfo* attributes;

        /// <summary>
        /// Defines the numAttributes
        /// </summary>
        public uint numAttributes;
    }
}
