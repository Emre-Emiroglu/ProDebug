using System;
using System.Collections.Generic;
using ProDebug.Runtime;
using UnityEditor;
using UnityEngine;

namespace ProDebug.Editor
{
    public sealed class ProDebugEditor : EditorWindow
    {
        #region Constants
        private const string MenuItem = "Tools/ProDebug/ProDebugEditor";
        private const string Name = "Pro Debug Editor";
        private const float MinWidth = 384;
        private const float MaxWidth = 512;
        private const float MinHeight = 192;
        private const float MaxHeight = 256;
        private const string InputTextLabel = "Message";
        private const string ColorSelectionTypeEnumLabel = "Color Selection Type";
        private const string CachedColorTypeEnumLabel = "Cached Color Type";
        private const string CachedHexTypeEnumLabel = "Cached Hex Type";
        private const string CustomColorLabel = "Custom Color Picker";
        private const string CustomHexLabel = "Custom Hex";
        private const string FormatSelectionTypeEnumLabel = "Format Selection Type";
        private const string CachedFormatTypeEnumLabel = "Cached Format Type";
        private const string CustomFormatLabel = "Custom Format";
        private const string ShowLogButtonText = "Show Log";
        #endregion

        #region Fields
        private Vector2 _scroll;
        private string _inputText = "Hello Debug!";
        private ColorSelectionType _colorSelectionType = ColorSelectionType.CachedColor;
        private CachedColorType _cachedColorType = CachedColorType.White;
        private CachedHexType _cachedHexType = CachedHexType.Orange;
        private readonly List<Colorize> _cachedColors = new()
        {
            ProDebugUtilities.White,
            ProDebugUtilities.Red,
            ProDebugUtilities.Yellow,
            ProDebugUtilities.Green,
            ProDebugUtilities.Blue,
            ProDebugUtilities.Cyan,
            ProDebugUtilities.Magenta,
            ProDebugUtilities.Gray
        };
        private readonly List<Colorize> _cachedHexes = new()
        {
            ProDebugUtilities.Orange,
            ProDebugUtilities.Olive,
            ProDebugUtilities.Purple,
            ProDebugUtilities.DarkRed,
            ProDebugUtilities.DarkGreen,
            ProDebugUtilities.DarkOrange,
            ProDebugUtilities.Gold,
        };
        private Color _customColor = Color.white;
        private string _customHex = "#FFFFFF";
        private FormatSelectionType _formatSelectionType = FormatSelectionType.CachedFormat;
        private CachedFormatType _cachedFormatType = CachedFormatType.None;
        private string _customFormat = string.Empty;
        private string _logText = string.Empty;
        #endregion

        #region Core
        [MenuItem(MenuItem)]
        public static void ShowWindow()
        {
            ProDebugEditor editor = GetWindow<ProDebugEditor>(Name);
            
            editor.minSize = new Vector2(MinWidth, MinHeight);
            editor.maxSize = new Vector2(MaxWidth, MaxHeight);
        }
        private void OnGUI()
        {
            EditorGUILayout.BeginScrollView(_scroll);

            DrawInputText();

            _logText = _inputText;

            EditorGUILayout.Space();

            DrawColorSelection();

            EditorGUILayout.Space();

            DrawFormatSelection();
            
            EditorGUILayout.Space();

            if (GUILayout.Button(ShowLogButtonText))
                Debug.Log(_logText);

            EditorGUILayout.EndScrollView();
        }
        #endregion

        #region Executes
        private void DrawInputText() => _inputText = EditorGUILayout.TextField(InputTextLabel, _inputText);
        private void DrawColorSelection()
        {
            _colorSelectionType =
                (ColorSelectionType)EditorGUILayout.EnumPopup(ColorSelectionTypeEnumLabel, _colorSelectionType);

            switch (_colorSelectionType)
            {
                case ColorSelectionType.CachedColor:
                    _cachedColorType =
                        (CachedColorType)EditorGUILayout.EnumPopup(CachedColorTypeEnumLabel, _cachedColorType);

                    _logText = ProDebugUtilities.CachedColor(_logText, _cachedColors[(int)_cachedColorType]);
                    break;
                case ColorSelectionType.CachedHex:
                    _cachedHexType =
                        (CachedHexType)EditorGUILayout.EnumPopup(CachedHexTypeEnumLabel, _cachedHexType);
                    
                    _logText =  ProDebugUtilities.CachedColor(_logText, _cachedHexes[(int)_cachedHexType]);
                    break;
                case ColorSelectionType.CustomColor:
                    _customColor = EditorGUILayout.ColorField(CustomColorLabel, _customColor);
                    
                    _logText =  ProDebugUtilities.FromCustomColor(_logText, _customColor);
                    break;
                case ColorSelectionType.CustomHex:
                    _customHex = EditorGUILayout.TextField(CustomHexLabel, _customHex);
                    
                    _logText =  ProDebugUtilities.FromCustomHex(_logText, _customHex);
                    break;
                default:
                    _logText =  ProDebugUtilities.FromCustomColor(_logText, Color.white);
                    break;
            }
        }
        private void DrawFormatSelection()
        {
            _formatSelectionType =
                (FormatSelectionType)EditorGUILayout.EnumPopup(FormatSelectionTypeEnumLabel, _formatSelectionType);

            switch (_formatSelectionType)
            {
                case FormatSelectionType.CachedFormat:
                    _cachedFormatType =
                        (CachedFormatType)EditorGUILayout.EnumPopup(CachedFormatTypeEnumLabel, _cachedFormatType);

                    if (_cachedFormatType.HasFlag(CachedFormatType.Italic))
                        _logText = ProDebugUtilities.CachedFormat(_logText, ProDebugUtilities.Italic);
                    if (_cachedFormatType.HasFlag(CachedFormatType.Bold))
                        _logText = ProDebugUtilities.CachedFormat(_logText, ProDebugUtilities.Bold);
                    break;
                case FormatSelectionType.CustomFormat:
                    _customFormat = EditorGUILayout.TextField(CustomFormatLabel, _customFormat);
                    
                    _logText = ProDebugUtilities.FromCustomFormat(_logText, _customFormat);
                    break;
                default:
                    _logText = ProDebugUtilities.FromCustomFormat(_logText, string.Empty);
                    break;
            }
        }
        #endregion
    }

    internal enum ColorSelectionType
    {
        CachedColor,
        CachedHex,
        CustomColor,
        CustomHex
    }

    internal enum CachedColorType
    {
        White,
        Red,
        Yellow,
        Green,
        Blue,
        Cyan,
        Magenta,
        Gray
    }
    
    internal enum CachedHexType
    {
        Orange,
        Olive,
        Purple,
        DarkRed,
        DarkGreen,
        DarkOrange,
        Gold
    }

    internal enum FormatSelectionType
    {
        CachedFormat,
        CustomFormat,
    }

    [Flags]
    internal enum CachedFormatType
    {
        None = 0,
        Italic = 1 << 0,
        Bold = 1 << 1,
        All = Italic | Bold,
    }
}