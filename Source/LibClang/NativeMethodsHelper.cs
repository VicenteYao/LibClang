using LibClang.Intertop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibClang
{
    internal static unsafe class NativeMethodsHelper
    {

        internal static  string ToStringAndDispose(this CXString cxString)
        {
            var pString = clang.clang_getCString(cxString);
            string result= new string(pString);
            clang.clang_disposeString(cxString);
            return result;
        }

        internal static string[] ToStringArrayAndDispose(CXStringSet* pStringSet)
        {
            if (pStringSet == (CXStringSet*)0)
            {
                return null;
            }
            string[] stringArray = new string[pStringSet->Count];
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = pStringSet->Strings[i].ToStringAndDispose();
            }
            clang.clang_disposeStringSet(pStringSet);
            return stringArray;
        }



    }
}
