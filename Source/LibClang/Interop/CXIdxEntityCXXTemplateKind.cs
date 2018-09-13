using System;
using System.Collections.Generic;
using System.Text;

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
        CXIdxEntity_NonTemplate = 0,
        CXIdxEntity_Template = 1,
        CXIdxEntity_TemplatePartialSpecialization = 2,
        CXIdxEntity_TemplateSpecialization = 3
    }
}
