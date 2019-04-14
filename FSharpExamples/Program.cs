using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Domain;

namespace FSharpExamples
{
    public class Program
    {
        public static void Main(string[] args)
        {
              new Usages().SomeMethod();
              Console.Read();
            //CreateWebHostBuilder(args).Build().Run();
        }


        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}