using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Services
{
    internal class PathMachineService : EnvVarService
    {
        public PathMachineService() : base("PATH", EnvironmentVariableTarget.Machine) { }
    }
}
