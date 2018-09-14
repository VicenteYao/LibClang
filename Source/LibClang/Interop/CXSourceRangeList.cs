namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXSourceRangeList" />
    /// </summary>
    public unsafe struct CXSourceRangeList
    {
        /// <summary>
        /// Defines the count
        /// </summary>
        public uint count;

        /// <summary>
        /// Defines the ranges
        /// </summary>
        public CXSourceRange* ranges;
    }
}
