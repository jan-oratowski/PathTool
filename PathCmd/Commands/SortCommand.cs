using GoCommando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Commands
{
    [Command("sort")]
    [Description("Sorts all values from PATH variable in alphabetical order, then saves it.")]
    internal class SortCommand : CommandBase, ICommand
    {
        [Parameter("pretend", "p", true, "false")]
        public bool Pretend { get; set; }

        public void Run()
        {
            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            var paths = currentPath.Split(';');

            var sortedPaths = paths.OrderBy(x => x);

            var newPath = string.Join(";", sortedPaths);

            if (Pretend)
            {
                Console.WriteLine("Sorted PATH variables:");
                foreach (var path in sortedPaths)
                    Console.WriteLine(" " + path);

                return;
            }

            if (!_envVarService.Write(newPath))
                Console.WriteLine("Something went wrong, new PATH was not saved.");
        }
    }
}
