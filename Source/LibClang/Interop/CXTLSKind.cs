namespace LibClang.Intertop
{
    /**
     * Describe the "thread-local storage (TLS) kind" of the declaration
     * referred to by a cursor.
     */
    public enum CXTLSKind
    {
        /// <summary>
        /// Defines the CXTLS_None
        /// </summary>
        CXTLS_None = 0,
        /// <summary>
        /// Defines the CXTLS_Dynamic
        /// </summary>
        CXTLS_Dynamic,
        /// <summary>
        /// Defines the CXTLS_Static
        /// </summary>
        CXTLS_Static
    }
}
