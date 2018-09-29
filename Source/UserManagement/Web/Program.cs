using Infrastructure.AspNet;

namespace Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // while(!System.Diagnostics.Debugger.IsAttached)
            //     System.Threading.Thread.Sleep(19);
            return Initialization.BuildAndRun<Startup>("UserManagement", args);
        }
    }
}
