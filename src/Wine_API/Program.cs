using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace WineAPI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .ConfigureLogging(logging =>
                 {
                     logging.AddEventLog(settings =>
                     {
                         settings.SourceName = "Wine API Logs";
                     });
                 })
                .UseStartup<Startup>()
                .Build();
    }
}
