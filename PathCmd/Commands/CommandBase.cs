using PathCmd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace PathCmd.Commands
{
    internal class CommandBase
    {
        protected IEnvVarService? _envVarService;

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
