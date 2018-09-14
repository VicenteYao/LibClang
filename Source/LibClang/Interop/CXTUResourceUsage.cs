namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXTUResourceUsage" />
    /// </summary>
    public unsafe struct CXTUResourceUsage
    {
        /// <summary>
        /// Defines the data
        /// </summary>
        public void* data;

        /// <summary>
        /// Defines the numEntries
        /// </summary>
        public uint numEntries;

        /// <summary>
        /// Defines the entries
        /// </summary>
        public CXTUResourceUsageEntry* entries;
    }
}
