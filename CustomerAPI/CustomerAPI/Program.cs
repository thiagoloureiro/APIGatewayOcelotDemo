using Megaphone.Core;
using Megaphone.Core.ClusterProviders;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;


namespace CustomerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var name = Dns.GetHostName(); // get container id
            var ip = Dns.GetHostEntry(name).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);

            var uri = Cluster.Bootstrap(new WebApiProvider(), new ConsulProvider(), "customerservice", "v1", host: ip.ToString(), port: 80);
            CreateWebHostBuilder(args, uri).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args, Uri uri) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddEnvironmentVariables();
                })
                .UseStartup<Startup>()
                .UseUrls($"http://0.0.0.0:{uri.Port}");
    }
}
