using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Services
{
    internal class PathUserService : EnvVarService
    {
        public PathUserService() : base("PATH", EnvironmentVariableTarget.User) { }
    }
}
