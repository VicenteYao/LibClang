using System;
using System.Collections.Generic;
using System.Text;
using CXFile = System.IntPtr;

namespace LibClang.Intertop
{
    /**
           * Data for ppIncludedFile callback.
           */
    public unsafe struct CXIdxIncludedFileInfo
    {
        /**
         * Location of '#' in the \#include/\#import directive.
         */
        public CXIdxLoc hashLoc;
        /**
         * Filename as written in the \#include/\#import directive.
         */
        public sbyte* filename;
        /**
         * The actual file that the \#include/\#import directive resolved to.
         */
        CXFile file;
        public int isImport;
        public int isAngled;
        /**
         * Non-zero if the directive was automatically turned into a module
         * import.
         */
        public int isModuleImport;
    }
}
