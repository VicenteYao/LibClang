namespace LibClang.Intertop
{
    /**
     * Extra C++ template information for an entity. This can apply to:
     * CXIdxEntity_Function
     * CXIdxEntity_CXXClass
     * CXIdxEntity_CXXStaticMethod
     * CXIdxEntity_CXXInstanceMethod
     * CXIdxEntity_CXXConstructor
     * CXIdxEntity_CXXConversionFunction
     * CXIdxEntity_CXXTypeAlias
     */
    public enum CXIdxEntityCXXTemplateKind
    {
        /// <summary>
        /// Defines the CXIdxEntity_NonTemplate
        /// </summary>
        CXIdxEntity_NonTemplate = 0,
        /// <summary>
        /// Defines the CXIdxEntity_Template
        /// </summary>
        CXIdxEntity_Template = 1,
        /// <summary>
        /// Defines the CXIdxEntity_TemplatePartialSpecialization
        /// </summary>
        CXIdxEntity_TemplatePartialSpecialization = 2,
        /// <summary>
        /// Defines the CXIdxEntity_TemplateSpecialization
        /// </summary>
        CXIdxEntity_TemplateSpecialization = 3
    }
}
