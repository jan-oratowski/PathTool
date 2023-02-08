using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Services
{
    internal class EnvVarService : IEnvVarService
    {
        private readonly string _name = null!;
        private readonly EnvironmentVariableTarget _scope;

        public EnvVarService(string name, EnvironmentVariableTarget scope)
        {
            _name = name;
            _scope = scope;
        }

        public string Read() => Environment.GetEnvironmentVariable(_name, _scope) ?? string.Empty;

        public bool Write(string value)
        {
            try
            {
                Environment.SetEnvironmentVariable(_name, value, _scope);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
