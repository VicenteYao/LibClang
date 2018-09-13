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
            var cString = clang.clang_getCString(cxString);
            string result= new string(cString);
            clang.clang_disposeString(cxString);
            return result;
        }

        internal static string[] ToStringArrayAndDispose(CXStringSet* pStringSet)
        {
            if (pStringSet == (CXStringSet*)0)
            {
                return new string[0];
            }
            string[] stringArray = new string[pStringSet->Count];
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = pStringSet->Strings[i].ToStringAndDispose();
            }
            clang.clang_disposeStringSet(pStringSet);
            return stringArray;
        }

        public static sbyte** ToPointer(this string[] cmdArgs )
        {
            sbyte** pCmdArgs = (sbyte**)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(sbyte*)) * cmdArgs.Length);
            for (int i = 0; i < cmdArgs.Length; i++)
            {
                *pCmdArgs = (sbyte*)Marshal.StringToHGlobalUni(cmdArgs[i]);
            }

            return pCmdArgs;
        }

        internal static CXUnsavedFile* ToPointer(this UnsavedFile[] unsavedFiles)
        {
            if (unsavedFiles==null||unsavedFiles.Length==0)
            {
                return (CXUnsavedFile*)IntPtr.Zero;
            }
            CXUnsavedFile* pUnsavedFile = (CXUnsavedFile*)Marshal.AllocHGlobal(Marshal.SizeOf(typeof(CXUnsavedFile)) * unsavedFiles.Length);
            for (int i = 0; i < unsavedFiles.Length; i++)
            {
                (*pUnsavedFile) = unsavedFiles[i].Value;
            }

            return pUnsavedFile;
        }

    }
}
