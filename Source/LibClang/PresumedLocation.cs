namespace LibClang
{
    /// <summary>
    /// Defines the <see cref="PresumedLocation" />
    /// </summary>
    public class PresumedLocation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PresumedLocation"/> class.
        /// </summary>
        /// <param name="fileName">The fileName<see cref="string"/></param>
        /// <param name="line">The line<see cref="uint"/></param>
        /// <param name="column">The column<see cref="uint"/></param>
        internal PresumedLocation(string fileName, uint line, uint column)
        {
            this.FileName = fileName;
            this.Line = line;
            this.Column = column;
        }

        /// <summary>
        /// Gets the FileName
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the Column
        /// </summary>
        public uint Column { get; private set; }

        /// <summary>
        /// Gets the Line
        /// </summary>
        public uint Line { get; private set; }
    }
}
