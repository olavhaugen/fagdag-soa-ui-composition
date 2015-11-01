using System;
using Microsoft.Owin.Hosting;
using Web.Api.SelfHost.Infrastructure;

namespace Web.Api.SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            const string baseAddress = "http://localhost:9000/";
            
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Serving {0}", baseAddress);
                Console.ReadLine(); 
            }
        }
    }
}
