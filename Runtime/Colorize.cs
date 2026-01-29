using UnityEngine;

namespace ProDebug.Runtime
{
    /// <summary>
    /// Represents a color that can be applied to a string in Unity.
    /// </summary>
    public sealed class Colorize
    {
        #region Constants
        private const string Suffix = "</color>";
        #endregion
        
        #region Fields
        private readonly string _prefix;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Colorize"/> class with a specified color.
        /// </summary>
        /// <param name="color">The color to be applied.</param>
        public Colorize(Color color) => _prefix = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Colorize"/> class with a specified hex color string.
        /// </summary>
        /// <param name="hexColor">The hex color string (e.g., "#FFFFFF").</param>
        public Colorize(string hexColor) => _prefix = $"<color={hexColor}>";
        #endregion

        #region Operators
        /// <summary>
        /// Applies the color to the provided text.
        /// </summary>
        /// <param name="text">The text to be colored.</param>
        /// <param name="color">The color to be applied to the text.</param>
        /// <returns>A string with the color applied.</returns>
        public static string operator %(string text, Colorize color) => color._prefix + text + Suffix;
        #endregion
    }
}