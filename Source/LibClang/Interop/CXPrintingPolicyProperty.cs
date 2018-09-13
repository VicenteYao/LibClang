using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
           * Properties for the printing policy.
           *
           * See \c clang::PrintingPolicy for more information.
           */
    public enum CXPrintingPolicyProperty
    {
        CXPrintingPolicy_Indentation,
        CXPrintingPolicy_SuppressSpecifiers,
        CXPrintingPolicy_SuppressTagKeyword,
        CXPrintingPolicy_IncludeTagDefinition,
        CXPrintingPolicy_SuppressScope,
        CXPrintingPolicy_SuppressUnwrittenScope,
        CXPrintingPolicy_SuppressInitializers,
        CXPrintingPolicy_ConstantArraySizeAsWritten,
        CXPrintingPolicy_AnonymousTagLocations,
        CXPrintingPolicy_SuppressStrongLifetime,
        CXPrintingPolicy_SuppressLifetimeQualifiers,
        CXPrintingPolicy_SuppressTemplateArgsInCXXConstructors,
        CXPrintingPolicy_Bool,
        CXPrintingPolicy_Restrict,
        CXPrintingPolicy_Alignof,
        CXPrintingPolicy_UnderscoreAlignof,
        CXPrintingPolicy_UseVoidForZeroParams,
        CXPrintingPolicy_TerseOutput,
        CXPrintingPolicy_PolishForDeclaration,
        CXPrintingPolicy_Half,
        CXPrintingPolicy_MSWChar,
        CXPrintingPolicy_IncludeNewlines,
        CXPrintingPolicy_MSVCFormatting,
        CXPrintingPolicy_ConstantsAsWritten,
        CXPrintingPolicy_SuppressImplicitBase,
        CXPrintingPolicy_FullyQualifiedName,

        CXPrintingPolicy_LastProperty = CXPrintingPolicy_FullyQualifiedName
    }

}
