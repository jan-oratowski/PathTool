using GoCommando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Commands
{
    [Command("list")]
    [Description("Lists all values from PATH variable in easily readable format.")]
    internal class ListCommand : CommandBase, ICommand
    {
        public void Run()
        {
            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            var paths = currentPath.Split(';');

            Console.WriteLine("Current PATH variable:");
            foreach (var path in paths)
                Console.WriteLine(" " + path);

            Console.WriteLine("Total: " + paths.Length);
        }
    }
}
