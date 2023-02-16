using GoCommando;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Commands
{
    [Command("import")]
    [Description("Imports all values from a file to PATH variable, then saves it.")]
    internal class ImportCommand : CommandBase, ICommand
    {
        [Parameter("file", "f")]
        public string FileName { get; set; } = null!;

        [Parameter("force", "F", true)]
        public bool Force { get; set; }

        public void Run()
        {
            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            var paths = currentPath.ToLower().Split(';');

            if (!File.Exists(FileName))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            var fileText = System.IO.File.ReadAllText(FileName);

            var fileLines = fileText.Split(Environment.NewLine);

            foreach (var line in fileLines)
            {
                if (paths.Contains(line.ToLower()))
                {
                    Console.WriteLine("The PATH variable already contains the path to directory you wanted to add:");
                    Console.WriteLine(line);
                    Console.WriteLine("No changes made.");
                }
                else
                {
                    currentPath += ";" + line;
                }
            }

            if (!_envVarService.Write(currentPath))
                Console.WriteLine("Something went wrong, new PATH was not saved.");
        }
    }
}
