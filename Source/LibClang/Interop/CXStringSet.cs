namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXStringSet" />
    /// </summary>
    public unsafe struct CXStringSet
    {
        /// <summary>
        /// Defines the Strings
        /// </summary>
        public CXString* Strings;

        /// <summary>
        /// Defines the Count
        /// </summary>
        public uint Count;
    }
}
