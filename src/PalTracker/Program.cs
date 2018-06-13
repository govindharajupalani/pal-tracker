using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Steeltoe.Extensions.Configuration.CloudFoundry;

namespace PalTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("##### Program.Main() "  + args.ToString());
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            System.Diagnostics.Debug.WriteLine("##### Program.IWebHostBuilder() "+args.ToString());
            return WebHost.CreateDefaultBuilder(args)
                    .ConfigureAppConfiguration(config => config.AddCloudFoundry())
                    .UseStartup<Startup>();
        }              
    }
}
