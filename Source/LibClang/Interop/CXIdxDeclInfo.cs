using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang.Intertop
{
    public unsafe struct CXIdxDeclInfo
    {
        public CXIdxEntityInfo entityInfo;
        public CXCursor cursor;
        public CXIdxLoc loc;
        public CXIdxContainerInfo semanticContainer;
        /**
     * Generally same as #semanticContainer but can be different in
     * cases like out-of-line C++ member functions.
     */
        public CXIdxContainerInfo lexicalContainer;
        public int isRedeclaration;
        public int isDefinition;
        public int isContainer;
        public CXIdxContainerInfo declAsContainer;
        /**
    * Whether the declaration exists in code or was created implicitly
       * by the compiler, e.g. implicit Objective-C methods for properties.
       */
        public int isImplicit;
        public CXIdxAttrInfo* attributes;
        public uint numAttributes;
        public uint flags;
    }
}
