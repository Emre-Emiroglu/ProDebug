namespace ProDebug.Runtime
{
    /// <summary>
    /// Represents a text format that can be applied to a string in Unity.
    /// </summary>
    public sealed class TextFormat
    {
        #region Fields
        private readonly string _prefix;
        private readonly string _suffix;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFormat"/> class with a specified format.
        /// </summary>
        /// <param name="format">The format type (e.g., "b" for bold, "i" for italic).</param>
        public TextFormat(string format)
        {
            _prefix = $"<{format}>";
            _suffix = $"</{format}>";
        }
        #endregion

        #region Operators
        /// <summary>
        /// Applies the text format to the provided text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <param name="textFormat">The format to be applied to the text.</param>
        /// <returns>A string with the format applied.</returns>
        public static string operator %(string text, TextFormat textFormat) =>
            textFormat._prefix + text + textFormat._suffix;
        #endregion
    }
}