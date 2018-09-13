using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public enum CXIndexOptFlags
    {
        /**
         * Used to indicate that no special indexing options are needed.
         */
        CXIndexOpt_None = 0x0,

        /**
         * Used to indicate that IndexerCallbacks#indexEntityReference should
         * be invoked for only one reference of an entity per source file that does
         * not also include a declaration/definition of the entity.
         */
        CXIndexOpt_SuppressRedundantRefs = 0x1,

        /**
         * Function-local symbols should be indexed. If this is not set
         * function-local symbols will be ignored.
         */
        CXIndexOpt_IndexFunctionLocalSymbols = 0x2,

        /**
         * Implicit function/class template instantiations should be indexed.
         * If this is not set, implicit instantiations will be ignored.
         */
        CXIndexOpt_IndexImplicitTemplateInstantiations = 0x4,

        /**
         * Suppress all compiler warnings when parsing for indexing.
         */
        CXIndexOpt_SuppressWarnings = 0x8,

        /**
         * Skip a function/method body that was already parsed during an
         * indexing session associated with a \c CXIndexAction object.
         * Bodies in system headers are always skipped.
         */
        CXIndexOpt_SkipParsedBodiesInSession = 0x10

    }
}
