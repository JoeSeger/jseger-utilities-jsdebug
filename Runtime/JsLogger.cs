using System;
using System.Text;
using JSeger.Utilities.Colors.Runtime;
using JSeger.Utilities.Stringtools.Runtime;
using UnityEngine;
using Color = JSeger.Utilities.Colors.Runtime.Color;
using JSeger.Utilities.Enumtools.Runtime;

namespace JSeger.Utilities.JSdebug.Runtime
{
    public static class JsLogger
    {
        public enum LogLevel
        {
            Normal,
            Warning,
            Error,
            Success
        }

        private static readonly StringBuilder StringBuilder = new();

        private static void LogInternal(
            StringConstructor message,
            LogType logType,
            Color color,
            bool bold,
            bool italic,
            bool separateEachStringWithNewLine = false)
        {
            var hexColor = ColorTools.GetHexColor(color);

            StringBuilder.Clear();

            if (color != Color.White)
            {
                StringBuilder.Append("<color=#");
                StringBuilder.Append(hexColor);
                StringBuilder.Append('>');
            }

            if (bold)
            {
                StringBuilder.Append("<b>");
            }

            if (italic)
            {
                StringBuilder.Append("<i>");
            }

            StringBuilder.Append(message);

            if (italic)
            {
                StringBuilder.Append("</i>");
            }

            if (bold)
            {
                StringBuilder.Append("</b>");
            }

            if (color != Color.White)
            {
                StringBuilder.Append("</color>");
            }

            if (separateEachStringWithNewLine)
            {
                StringBuilder.Append('\n');
            }

            var finalMessage = StringBuilder.ToString();

            switch (logType)
            {
                case LogType.Log:
                    Debug.Log(finalMessage);
                    break;
                case LogType.Warning:
                    Debug.LogWarning(finalMessage);
                    break;
                case LogType.Error:
                    Debug.LogError(finalMessage);
                    break;
                case LogType.Assert:
                    Debug.LogAssertion(finalMessage);
                    break;
                case LogType.Exception:
                    Debug.LogException(new Exception(finalMessage));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static void LogInternal(string message, LogType logType, Color color, bool bold,
            bool italic) => LogInternal(new StringConstructor(message), logType, color, bold, italic);

        private static void LogInternal(LogType logType, Color color, bool bold,
            bool italic, bool separateEachStringWithNewLine = false, params string[] messages) => LogInternal(
            new StringConstructor(messages), logType, color, bold, italic, separateEachStringWithNewLine);


        /// <summary>
        /// Logs a message at the specified log level, with optional formatting.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="color">The color to use for the message text.</param>
        /// <param name="bold">Whether to bold the message text.</param>
        /// <param name="italic">Whether to italicize the message text.</param>
        public static void Log(string message, Color color = Color.White, bool bold = false, bool italic = false) =>
            LogInternal(message, LogType.Log, color, bold, italic);

        public static void Log(Color color = Color.White, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Log, color, bold, italic, separateEachStringWithNewLine, message);

        public static void Log(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Log, Color.White, false, false, separateEachStringWithNewLine, message);

        public static void Log(params string[] message) =>
            LogInternal(LogType.Log, Color.White, false, false, false, message);

        public static void Log(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Log, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);

        public static void LogWarning(StringConstructor message, Color color = Color.Yellow, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Warning, color, bold, italic);

        public static void LogWarning(string message, Color color = Color.Yellow, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Warning, color, bold, italic);

        public static void LogWarning(Color color = Color.Yellow, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Warning, color, bold, italic, separateEachStringWithNewLine, message);

        public static void LogWarning(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Warning, Color.Yellow, false, false, separateEachStringWithNewLine, message);

        public static void LogWarning(params string[] message) =>
            LogInternal(LogType.Warning, Color.Yellow, false, false, false, message);

        public static void LogWarning(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Warning, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);

        public static void LogError(StringConstructor message, Color color = Color.Red, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Error, color, bold, italic);

        public static void LogError(string message, Color color = Color.Red, bool bold = false, bool italic = false) =>
            LogInternal(message, LogType.Error, color, bold, italic);

        public static void LogError(Color color = Color.Red, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Error, color, bold, italic, separateEachStringWithNewLine, message);

        public static void LogError(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Error, Color.Red, false, false, separateEachStringWithNewLine, message);

        public static void LogError(params string[] message) =>
            LogInternal(LogType.Error, Color.Red, false, false, false, message);


        public static void LogError(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Error, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);

        public static void LogSuccess(StringConstructor message, Color color = Color.Green, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Log, color, bold, italic);


        public static void LogSuccess(string message, Color color = Color.Green, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Log, color, bold, italic);

        public static void LogSuccess(Color color = Color.Green, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Log, color, bold, italic, separateEachStringWithNewLine, message);

        public static void LogSuccess(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Log, Color.Green, false, false, separateEachStringWithNewLine, message);

        public static void LogSuccess(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Log, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);

        public static void LogAssertion(StringConstructor message, Color color = Color.Magenta, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Assert, color, bold, italic);

        public static void LogAssertion(string message, Color color = Color.Magenta, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Assert, color, bold, italic);

        public static void LogAssertion(Color color = Color.Magenta, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Assert, color, bold, italic, separateEachStringWithNewLine, message);

        public static void LogAssertion(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Assert, Color.Magenta, false, false, separateEachStringWithNewLine, message);

        public static void LogAssertion(params string[] message) =>
            LogInternal(LogType.Assert, Color.Magenta, false, false, false, message);

        public static void LogAssertion(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Assert, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);

        public static void LogException(StringConstructor message, Color color = Color.Blue, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Exception, color, bold, italic);

        public static void LogException(string message, Color color = Color.Blue, bool bold = false,
            bool italic = false) =>
            LogInternal(message, LogType.Exception, color, bold, italic);

        public static void LogException(Color color = Color.Blue, bool bold = false,
            bool separateEachStringWithNewLine = false, bool italic = false, params string[] message) =>
            LogInternal(LogType.Exception, color, bold, italic, separateEachStringWithNewLine, message);

        public static void LogException(bool separateEachStringWithNewLine = false, params string[] message) =>
            LogInternal(LogType.Exception, Color.Blue, false, false, separateEachStringWithNewLine, message);

        public static void LogException(params string[] message) =>
            LogInternal(LogType.Exception, Color.Blue, false, false, false, message);

        public static void LogException(int color, bool bold = false, bool italic = false,
            bool separateEachStringWithNewLine = false, params string[] message)
            => LogInternal(LogType.Exception, EnumExtensions.FromInt<Color>(color), bold, italic,
                separateEachStringWithNewLine, message);
    }
}