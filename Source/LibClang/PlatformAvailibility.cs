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
        /// Initializes a new instance of the <see cref="PlatformAvailibility"/> class.
        /// </summary>
        /// <param name="platformAvailability">The platformAvailability<see cref="CXPlatformAvailability"/></param>
        internal PlatformAvailibility(CXPlatformAvailability platformAvailability)
        {
            this.m_value = platformAvailability;
        }

        /// <summary>
        /// Defines the m_value
        /// </summary>
        private CXPlatformAvailability m_value;

        /// <summary>
        /// Defines the platform
        /// </summary>
        private string platform;

        /// <summary>
        /// Gets the Platform
        /// Defines the Platform
        /// </summary>
        public string Platform
        {
            get
            {
                if (this.platform == null)
                {
                    this.platform = this.m_value.Platform.ToStringAndDispose();
                }
                return this.platform;
            }
        }

        /// <summary>
        /// Defines the introduced
        /// </summary>
        private Version introduced;

        /// <summary>
        /// Gets the Introduced
        /// Defines the Introduced
        /// </summary>
        public Version Introduced
        {
            get
            {
                if (this.introduced == null)
                {
                    this.introduced = new Version(this.m_value.Introduced.Major, this.m_value.Introduced.Minor);
                }
                return this.introduced;
            }
        }

        /// <summary>
        /// Defines the deprecated
        /// </summary>
        private Version deprecated;

        /// <summary>
        /// Gets the Deprecated
        /// Defines the Deprecated
        /// </summary>
        public Version Deprecated
        {
            get
            {
                if (this.deprecated == null)
                {
                    this.deprecated = new Version(this.m_value.Deprecated.Major, this.m_value.Deprecated.Minor);
                }
                return this.deprecated;
            }
        }

        /// <summary>
        /// Defines the obsoleted
        /// </summary>
        private Version obsoleted;

        /// <summary>
        /// Gets the Obsoleted
        /// Defines the Obsoleted
        /// </summary>
        public Version Obsoleted
        {

            get
            {
                if (this.obsoleted == null)
                {
                    this.obsoleted = new Version(this.m_value.Obsoleted.Major, this.m_value.Obsoleted.Minor);
                }
                return this.obsoleted;
            }
        }

        /// <summary>
        /// Gets a value indicating whether Unavailable
        /// Defines the Unavailable
        /// </summary>
        public bool Unavailable
        {
            get
            {
                return this.m_value.Unavailable > 0;
            }
        }

        /// <summary>
        /// Defines the message
        /// </summary>
        private string message;

        /// <summary>
        /// Gets the Message
        /// Defines the Message
        /// </summary>
        public string Message
        {
            get
            {
                if (this.message == null)
                {
                    this.message = this.m_value.Message.ToStringAndDispose();
                }
                return this.message;
            }
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
