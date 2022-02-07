using System;

namespace usersetx
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1) {
                Console.WriteLine($"unset {args[0]}");
                SetVariable(args[0], null);
            } else if (args.Length == 2) {
                Console.WriteLine($"set {args[0]}={args[1]}");
                SetVariable(args[0], args[1]);
            }
        }

        static void SetVariable(string name, string value)
        {
            Environment.SetEnvironmentVariable(name, value, EnvironmentVariableTarget.User);
        }
    }
}
