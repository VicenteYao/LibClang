namespace LibClang.Intertop
{
    /// <summary>
    /// Defines the <see cref="CXPlatformAvailability" />
    /// </summary>
    public struct CXPlatformAvailability
    {
        /// <summary>
        /// Defines the Platform
        /// </summary>
        public CXString Platform;

        /// <summary>
        /// Defines the Introduced
        /// </summary>
        public CXVersion Introduced;

        /// <summary>
        /// Defines the Deprecated
        /// </summary>
        public CXVersion Deprecated;

        /// <summary>
        /// Defines the Obsoleted
        /// </summary>
        public CXVersion Obsoleted;

        /// <summary>
        /// Defines the Unavailable
        /// </summary>
        public int Unavailable;

        /// <summary>
        /// Defines the Message
        /// </summary>
        public CXString Message;
    }
}
