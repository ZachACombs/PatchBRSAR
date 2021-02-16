using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchBRSAR
{
    class AdvConsole
    {
        public static void Write(ConsoleColor color, string format, object arg0, object arg1)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(format, arg0, arg1);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, string format, params object[] arg)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(format, arg);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, string format, object arg0)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(format, arg0);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, ulong value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, uint value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, string value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, char[] buffer, int index, int count)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(buffer, index, count);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, object value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, float value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, char value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, char[] buffer)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(buffer);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, bool value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, double value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, int value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, long value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void Write(ConsoleColor color, decimal value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(value);
            Console.ForegroundColor = currentcolor;
        }

        public static void WriteLine(ConsoleColor color)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, bool value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, char value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, char[] buffer)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(buffer);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, decimal value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, double value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, float value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, int value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, long value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, object value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, uint value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, ulong value)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string format, object arg0)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg0);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string format, params object[] arg)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, char[] buffer, int index, int count)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(buffer, index, count);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string format, object arg0, object arg1)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg0, arg1);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string format, object arg0, object arg1, object arg2)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg0, arg1, arg2);
            Console.ForegroundColor = currentcolor;
        }
        public static void WriteLine(ConsoleColor color, string format, object arg0, object arg1, object arg2, object arg3)
        {
            ConsoleColor currentcolor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg0, arg1, arg2, arg3);
            Console.ForegroundColor = currentcolor;
        }
    }
}
