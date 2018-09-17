using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibClang
{
    public static  class Clang
    {
        private static CXTranslationUnit_Flags _defaultEditingTranslationUnitOptions;
        public static CXTranslationUnit_Flags DefaultEditingTranslationUnitOptions
        {
            get
            {
                _defaultEditingTranslationUnitOptions = (CXTranslationUnit_Flags)clang.clang_defaultEditingTranslationUnitOptions();
                return _defaultEditingTranslationUnitOptions;
            }
        }

        private static CXCodeComplete_Flags _defaultCodeCompleteFlags;
        public static CXCodeComplete_Flags DefaultCodeCompleteFlags
        {
            get
            {
                _defaultCodeCompleteFlags = (CXCodeComplete_Flags)clang.clang_defaultCodeCompleteOptions();
                return _defaultCodeCompleteFlags;
            }
        }

    }
}
