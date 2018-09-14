namespace LibClang
{
    /// <summary>
    /// Defines the <see cref="TemplateArgument" />
    /// </summary>
    public class TemplateArgument
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateArgument"/> class.
        /// </summary>
        /// <param name="type">The type<see cref="Type"/></param>
        internal TemplateArgument(Type type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateArgument"/> class.
        /// </summary>
        /// <param name="uintValue">The uintValue<see cref="uint"/></param>
        internal TemplateArgument(uint uintValue)
        {
            this.UIntValue = uintValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TemplateArgument"/> class.
        /// </summary>
        /// <param name="longValue">The longValue<see cref="long"/></param>
        internal TemplateArgument(long longValue)
        {
            this.LongValue = longValue;
        }

        /// <summary>
        /// Gets the Type
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the UIntValue
        /// </summary>
        public uint UIntValue { get; private set; }

        /// <summary>
        /// Gets the LongValue
        /// </summary>
        public long LongValue { get; private set; }
    }
}
