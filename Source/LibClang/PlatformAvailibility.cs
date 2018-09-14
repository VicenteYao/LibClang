namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="PlatformAvailibility" />
    /// </summary>
    public class PlatformAvailibility : ClangObject
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXPlatformAvailability m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformAvailibility"/> class.
        /// </summary>
        /// <param name="platformAvailability">The platformAvailability<see cref="CXPlatformAvailability"/></param>
        internal PlatformAvailibility(CXPlatformAvailability platformAvailability)
        {
            this.m_value = platformAvailability;
        }

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected internal override ValueType Value
        {
            get { return this.m_value; }
        }
    }
}
