using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoCommando;

namespace PathCmd.Commands
{
    [Command("delete")]
    [Description("Deletes a value from PATH variable, then saves it.")]
    internal class DeleteCommand : CommandBase, ICommand
    {
        [Parameter("value", "v")]
        public string Value { get; set; } = null!;

        public void Run()
        {
            if (!UseCorrectEnvService(Scope))
                return;

            var currentPath = _envVarService!.Read();

            var paths = currentPath.Split(';');

            var newPath = string.Join(";", paths.Where(x => !string.Equals(x, Value, StringComparison.OrdinalIgnoreCase)));

            if (!_envVarService.Write(newPath))
                Console.WriteLine("Something went wrong, new PATH was not saved.");
        }
    }
}
