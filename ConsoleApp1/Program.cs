using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Running demo with Kestrel.");

            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            var builder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseConfiguration(config)
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    if (config["threadCount"] != null)
                    {
                        options.ThreadCount = int.Parse(config["threadCount"]);
                    }
                })
                .UseUrls("http://*:5000");

            var host = builder.Build();
            host.Run();
        }
    }
}