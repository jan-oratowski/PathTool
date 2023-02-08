using GoCommando;

namespace Beverage
{
    [Banner(@"
------------------------------
Path Command Line Tool
Easily add/remove/check path variables

Copyright (c) 2023 Jan Oratowski
------------------------------")]
    [SupportImpersonation]
    class Program
    {
        static void Main()
        {
            Go.Run();
        }
    }
}