namespace LibClang.Intertop
{
    /**
     * Describe the linkage of the entity referred to by a cursor.
     */
    public enum CXLinkageKind
    {
        /** This value indicates that no linkage information is available
                         * for a provided CXCursor. */
        CXLinkage_Invalid,
        /**
         * This is the linkage for variables, parameters, and so on that
         *  have automatic storage.  This covers normal (non-extern) local variables.
         */
        CXLinkage_NoLinkage,
        /** This is the linkage for internal staticvariables and internal staticfunctions. */
        CXLinkage_Internal,
        /** This is the linkage for entities with external linkage that live
         * in C++ anonymous namespaces.*/
        CXLinkage_UniqueExternal,
        /** This is the linkage for entities with true, external linkage. */
        CXLinkage_External
    }
}
