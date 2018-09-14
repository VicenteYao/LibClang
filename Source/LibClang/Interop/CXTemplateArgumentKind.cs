namespace LibClang.Intertop
{
    /**
            * Describes the kind of a template argument.
            *
            * See the definition of llvm::clang::TemplateArgument::ArgKind for full
            * element descriptions.
            */
    enum CXTemplateArgumentKind
    {
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Null
        /// </summary>
        CXTemplateArgumentKind_Null,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Type
        /// </summary>
        CXTemplateArgumentKind_Type,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Declaration
        /// </summary>
        CXTemplateArgumentKind_Declaration,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_NullPtr
        /// </summary>
        CXTemplateArgumentKind_NullPtr,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Integral
        /// </summary>
        CXTemplateArgumentKind_Integral,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Template
        /// </summary>
        CXTemplateArgumentKind_Template,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_TemplateExpansion
        /// </summary>
        CXTemplateArgumentKind_TemplateExpansion,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Expression
        /// </summary>
        CXTemplateArgumentKind_Expression,
        /// <summary>
        /// Defines the CXTemplateArgumentKind_Pack
        /// </summary>
        CXTemplateArgumentKind_Pack,
        /* Indicates an error case, preventing the kind from being deduced. */
        CXTemplateArgumentKind_Invalid
    }
}
