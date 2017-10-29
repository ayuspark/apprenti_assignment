using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace asp_identity_core_ef
{
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        var host = new WebHostBuilder()
    //            .UseKestrel()
    //            .UseContentRoot(Directory.GetCurrentDirectory())
    //            .UseStartup<Startup>()
    //            .Build();

    //        host.Run();
    //    }
    //}
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
