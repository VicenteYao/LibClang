namespace LibClang
{
    /// <summary>
    /// Defines the <see cref="FixIt" />
    /// </summary>
    public class FixIt
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FixIt"/> class.
        /// </summary>
        /// <param name="text">The text<see cref="string"/></param>
        /// <param name="sourceRange">The sourceRange<see cref="SourceRange"/></param>
        internal FixIt(string text, SourceRange sourceRange)
        {
            this.Text = text;
            this.SourceRange = sourceRange;
        }

        /// <summary>
        /// Gets the Text
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Gets the SourceRange
        /// </summary>
        public SourceRange SourceRange { get; private set; }
    }
}
