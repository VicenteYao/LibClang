namespace LibClang
{
    using LibClang.Intertop;

    /// <summary>
    /// Defines the <see cref="NativeMethodsHelper" />
    /// </summary>
    internal static unsafe class NativeMethodsHelper
    {
        /// <summary>
        /// The ToStringAndDispose
        /// </summary>
        /// <param name="cxString">The cxString<see cref="CXString"/></param>
        /// <returns>The <see cref="string"/></returns>
        internal static string ToStringAndDispose(this CXString cxString)
        {
            var pString = clang.clang_getCString(cxString);
            string result = new string(pString);
            clang.clang_disposeString(cxString);
            return result;
        }

        /// <summary>
        /// The ToStringArrayAndDispose
        /// </summary>
        /// <param name="pStringSet">The pStringSet<see cref="CXStringSet*"/></param>
        /// <returns>The <see cref="string[]"/></returns>
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
