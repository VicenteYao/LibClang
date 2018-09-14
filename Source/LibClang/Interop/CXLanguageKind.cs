namespace LibClang.Intertop
{
    /**
     * Describe the "language" of the entity referred to by a cursor.
     */
    public enum CXLanguageKind
    {
        /// <summary>
        /// Defines the CXLanguage_Invalid
        /// </summary>
        CXLanguage_Invalid = 0,
        /// <summary>
        /// Defines the CXLanguage_C
        /// </summary>
        CXLanguage_C,
        /// <summary>
        /// Defines the CXLanguage_ObjC
        /// </summary>
        CXLanguage_ObjC,
        /// <summary>
        /// Defines the CXLanguage_CPlusPlus
        /// </summary>
        CXLanguage_CPlusPlus
    }
}
