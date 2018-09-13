using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{


    /**
     * Data for IndexerCallbacks#indexEntityReference.
     *
     * This may be deprecated in a future version as this duplicates
     * the \c CXSymbolRole_Implicit bit in \c CXSymbolRole.
     */
    public enum CXIdxEntityRefKind
    {
        /**
         * The entity is referenced directly in user's code.
         */
        CXIdxEntityRef_Direct = 1,
        /**
         * An implicit reference, e.g. a reference of an Objective-C method
         * via the dot syntax.
         */
        CXIdxEntityRef_Implicit = 2
    }
}
