using GoCommando;
using PathCmd.Services;

namespace PathCmd.Commands
{
    internal class CommandBase
    {
        protected IEnvVarService? _envVarService;

        [Parameter("scope", "s", true, "machine")]
        public string Scope { get; set; } = null!;

        protected bool UseCorrectEnvService(string scope)
        {
            switch (scope.ToLower())
            {
                case "machine":
                    _envVarService = new PathMachineService();
                    break;
                case "user":
                    _envVarService = new PathUserService();
                    break;
                default:
                    Console.WriteLine("Scope not defined correctly.");
                    return false;
            }

            return true;
        }

    }
}
