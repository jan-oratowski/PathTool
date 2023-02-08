using GoCommando;
using PathCmd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Commands
{
    [Command("add")]
    [Description("Adds path to windows PATH.")]
    internal class AddCommand : CommandBase, ICommand
    {
        private readonly PathCheckerService _checkerService = new();

        [Parameter("path", "p")]
        public string Path { get; set; } = null!;

        [Parameter("scope", "s", true, "machine")]
        public string Scope { get; set; } = null!;
        
        [Parameter("force", "f", true)]
        public bool Force { get; set; }

        public void Run()
        {
            (var result, var path) = _checkerService.CheckAndGetDirectory(Path);
            if (!(result || Force))
            {
                Console.WriteLine("Submitted path does not exists and will be not added to PATH");
                Console.WriteLine("You can force it with \"force\" set to true");
                return;
            }

            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            if (currentPath.Contains(path))
            {
                Console.WriteLine("The PATH variable already contains the path to directory you wanted to add.");
                Console.WriteLine("No changes made.");
                return;
            }

            var newPath = currentPath + ";" + path;

            if (!_envVarService.Write(newPath))
                Console.WriteLine("Something went wrong, new PATH was not saved.");
        }
    }
}
