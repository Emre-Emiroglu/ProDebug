using UnityEngine;

namespace ProDebug.Runtime
{
    /// <summary>
    /// Provides utility functions and fields for applying text formatting and coloring.
    /// </summary>
    public static class ProDebugUtilities
    {
        #region Colors
        /// <summary>
        /// White color.
        /// </summary>
        public static readonly Colorize White = new(Color.white);
        
        /// <summary>
        /// Red color.
        /// </summary>
        public static readonly Colorize Red = new(Color.red);
        
        /// <summary>
        /// Yellow color.
        /// </summary>
        public static readonly Colorize Yellow = new(Color.yellow);
        
        /// <summary>
        /// Green color.
        /// </summary>
        public static readonly Colorize Green = new(Color.green);
        
        /// <summary>
        /// Blue color.
        /// </summary>
        public static readonly Colorize Blue = new(Color.blue);
        
        /// <summary>
        /// Cyan color.
        /// </summary>
        public static readonly Colorize Cyan = new(Color.cyan);
        
        /// <summary>
        /// Magenta color.
        /// </summary>
        public static readonly Colorize Magenta = new(Color.magenta);
        
        /// <summary>
        /// Gray color.
        /// </summary>
        public static readonly Colorize Gray = new(Color.gray);
        #endregion

        #region HexColors
        /// <summary>
        /// Orange color defined by hex value.
        /// </summary>
        public static readonly Colorize Orange = new("#FFA500");
        
        /// <summary>
        /// Olive color defined by hex value.
        /// </summary>
        public static readonly Colorize Olive = new("#808000");
        
        /// <summary>
        /// Purple color defined by hex value.
        /// </summary>
        public static readonly Colorize Purple = new("#800080");
        
        /// <summary>
        /// Dark Red color defined by hex value.
        /// </summary>
        public static readonly Colorize DarkRed = new("#8B0000");
        
        /// <summary>
        /// Dark Green color defined by hex value.
        /// </summary>
        public static readonly Colorize DarkGreen = new("#006400");
        
        /// <summary>
        /// Dark Orange color defined by hex value.
        /// </summary>
        public static readonly Colorize DarkOrange = new("#FF8C00");
        
        /// <summary>
        /// Gold color defined by hex value.
        /// </summary>
        public static readonly Colorize Gold = new("#FFD700");
        #endregion

        #region Formats
        /// <summary>
        /// Bold text format.
        /// </summary>
        public static readonly TextFormat Bold = new("b");
        
        /// <summary>
        /// Italic text format.
        /// </summary>
        public static readonly TextFormat Italic = new("i");        
        #endregion
        
        #region Executes
        /// <summary>
        /// Applies a color to the provided text.
        /// </summary>
        /// <param name="text">The text to be colored.</param>
        /// <param name="color">The color to be applied to the text.</param>
        /// <returns>A string with the color applied.</returns>
        public static string CachedColor(string text, Colorize color) => text % color;
        
        /// <summary>
        /// Applies a text format to the provided text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <param name="format">The format to be applied to the text.</param>
        /// <returns>A string with the format applied.</returns>
        public static string CachedFormat(string text, TextFormat format) => text % format;
        
        /// <summary>
        /// Applies a custom hex color to the provided text.
        /// </summary>
        /// <param name="text">The text to be colored.</param>
        /// <param name="hex">The hex color string (e.g., "#FFFFFF").</param>
        /// <returns>A string with the custom hex color applied.</returns>
        public static string FromCustomHex(string text, string hex) => text % new Colorize(hex);
        
        /// <summary>
        /// Applies a custom color to the provided text.
        /// </summary>
        /// <param name="text">The text to be colored.</param>
        /// <param name="color">The color to be applied to the text.</param>
        /// <returns>A string with the custom color applied.</returns>
        public static string FromCustomColor(string text, Color color) => text % new Colorize(color);
        
        /// <summary>
        /// Applies a custom format to the provided text.
        /// </summary>
        /// <param name="text">The text to be formatted.</param>
        /// <param name="format">The format to be applied to the text.</param>
        /// <returns>A string with the custom format applied.</returns>
        public static string FromCustomFormat(string text, string format) => text % new TextFormat(format);
        #endregion
    }
}