using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWSS {
    public class Logger {
        public enum LogLevel { 
            warning,
            error,
            info,
            debug,
            red,
            green,
            blue
        }

        public static void Log(LogLevel log, string msg) {
            switch(log){
                case LogLevel.warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.error:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.info:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.debug:
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.red:
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.green:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                case LogLevel.blue:
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(msg);
                Console.ResetColor();
                break;
                default:
                Console.WriteLine(msg);
                break;

            }

        }
    }
}
