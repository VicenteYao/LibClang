namespace LibClang
{
    using LibClang.Intertop;
    using System;

    /// <summary>
    /// Defines the <see cref="PlatformAvailibilityList" />
    /// </summary>
    internal  class PlatformAvailibilityList : ClangList<PlatformAvailibility>
    {
        /// <summary>
        /// Defines the m_value
        /// </summary>
        private unsafe CXPlatformAvailability* m_value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlatformAvailibilityList"/> class.
        /// </summary>
        /// <param name="platformAvailability">The platformAvailability<see cref="CXPlatformAvailability"/></param>
        /// <param name="length">The length<see cref="int"/></param>
        internal unsafe PlatformAvailibilityList(CXPlatformAvailability* platformAvailability, int length)
        {
            this.m_value = platformAvailability;
            this._count = length;
        }

        /// <summary>
        /// Defines the _count
        /// </summary>
        private int _count;

        /// <summary>
        /// Gets the Value
        /// </summary>
        protected unsafe internal override ValueType Value
        {
            get { return (IntPtr)this.m_value; }
        }

        /// <summary>
        /// The EnsureItemAt
        /// </summary>
        /// <param name="index">The index<see cref="int"/></param>
        /// <returns>The <see cref="PlatformAvailibility"/></returns>
        protected unsafe override PlatformAvailibility EnsureItemAt(int index)
        {
            return new PlatformAvailibility(this.m_value[index]);
        }

        /// <summary>
        /// The GetCountCore
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        protected override int GetCountCore()
        {
            return this._count;
        }
    }
}
