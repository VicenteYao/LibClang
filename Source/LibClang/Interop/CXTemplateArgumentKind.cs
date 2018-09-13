using System;
using System.Collections.Generic;
using System.Text;

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
        CXTemplateArgumentKind_Null,
        CXTemplateArgumentKind_Type,
        CXTemplateArgumentKind_Declaration,
        CXTemplateArgumentKind_NullPtr,
        CXTemplateArgumentKind_Integral,
        CXTemplateArgumentKind_Template,
        CXTemplateArgumentKind_TemplateExpansion,
        CXTemplateArgumentKind_Expression,
        CXTemplateArgumentKind_Pack,
        /* Indicates an error case, preventing the kind from being deduced. */
        CXTemplateArgumentKind_Invalid
    }
}
