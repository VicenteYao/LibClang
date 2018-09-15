using System;
using System.Collections.Generic;
using System.Text;
using LibClang.Intertop;

namespace LibClang
{
    public class PlatformAvailibility : ClangObject
    {
        internal PlatformAvailibility(CXPlatformAvailability platformAvailability )
        {
            this.m_value = platformAvailability;
        }

        private CXPlatformAvailability m_value;

        private string platform;
        /// <summary>
        /// Defines the Platform
        /// </summary>
        public string Platform
        {
            get
            {
                if (this.platform==null)
                {
                    this.platform = this.m_value.Platform.ToStringAndDispose();
                }
                return this.platform;
            }
        }

        private Version introduced;

        /// <summary>
        /// Defines the Introduced
        /// </summary>
        public Version Introduced {
            get
            {
                if (this.introduced==null)
                {
                    this.introduced = new Version(this.m_value.Introduced.Major, this.m_value.Introduced.Minor);
                }
                return this.introduced;
            }
        }

        private Version deprecated;
        /// <summary>
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

        private Version obsoleted;
        /// <summary>
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
        /// Defines the Unavailable
        /// </summary>
        public bool Unavailable
        {
            get
            {
                return this.m_value.Unavailable > 0;
            }
        }

        private string message;
        /// <summary>
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

        protected internal override ValueType Value { get { return this.m_value; } }
    }
}
