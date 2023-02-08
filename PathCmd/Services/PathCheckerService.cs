using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCmd.Services
{
    internal class PathCheckerService
    {
        public (bool, string) CheckAndGetDirectory(string path)
        {
            if (Directory.Exists(path))
                return (true, path);

            if (!File.Exists(path))
                return (false, path);

            var parent = Path.GetDirectoryName(path);

            return parent != null ?
                (Directory.Exists(parent), parent) : (false, path);
        }
    }
}
