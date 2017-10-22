using Infrastructure.AspNet;

namespace Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Initialization.BuildAndRun<Startup>("Alert", args);
        }
    }
}
