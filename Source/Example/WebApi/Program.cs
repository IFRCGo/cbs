using Infrastructure.AspNet;

namespace WebApi
{
    public class Program
    {
        public static int Main(string[] args)
        {
            return Initialization.BuildAndRun<Startup>(args);
        }
    }
}
