using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCommando;

namespace PathCmd.Commands
{
    [Command("export")]
    [Description("Exports all values from PATH variable to a file.")]
    internal class ExportCommand : CommandBase, ICommand
    {
        [Parameter("file", "f")]
        public string FileName { get; set; } = null!;

        public void Run()
        {
            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            var paths = currentPath.Split(';');
            var fileText = string.Empty;

            foreach (var path in paths)
                fileText += path + Environment.NewLine;

            try
            {
                System.IO.File.WriteAllText(FileName, fileText);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
