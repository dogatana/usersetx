using System;
using System.Linq;

namespace usersetx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1) {
                var arg = args[0];
                if (arg == "-h" || arg == "--help") {
                    ShowUsage();
                } else if (args[0].IndexOf('=') != -1) {
                    var key_values = arg.Split('=').Select(v => v.Trim()).ToArray();
                    SetVariable(key_values[0], key_values[1]);
                } else {
                    UnsetVariable(arg);
                }
            } else if (args.Length == 2) {
                SetVariable(args[0], args[1]);
            }
        }

        static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User);
            Console.WriteLine($"set {name}={value}");
        }
        static void UnsetVariable(string name)
        {
            Environment.SetEnvironmentVariable(name, null, EnvironmentVariableTarget.User);
            Console.WriteLine($"unset {name}");
        }

        static void ShowUsage()
        {
            var message = @"usage: usersetx args
    usersetx name value - set value to name
    usersetx name=value - set value to name
    usersetx name       - delete nanme";
            Console.WriteLine(message);
        }
    }
}
