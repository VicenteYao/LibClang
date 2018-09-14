using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    /**
            * Data for IndexerCallbacks#indexEntityReference.
            */
    public unsafe struct CXIdxEntityRefInfo
    {
      public   CXIdxEntityRefKind kind;
        /**
         * Reference cursor.
         */
        public CXCursor cursor;
        public CXIdxLoc loc;
        /**
         * The entity that gets referenced.
         */

        public  CXIdxEntityInfo* referencedEntity;
        /**
         * Immediate "parent" of the reference. For example:
         *
         * \code
         * Foo *var;
         * \endcode
         *
         * The parent of reference of type 'Foo' is the variable 'var'.
         * For references inside statement bodies of functions/methods,
         * the parentEntity will be the function/method.
         */
        public CXIdxEntityInfo* parentEntity;
        /**
         * Lexical container context of the reference.
         */
        public CXIdxContainerInfo* container;
        /**
         * Sets of symbol roles of the reference.
         */
        public CXSymbolRole role;
    }
}
