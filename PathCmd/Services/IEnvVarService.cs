using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PathCmd.Services
{
    internal interface IEnvVarService
    {
        public string Read();

        public bool Write(string value);
    }
}
