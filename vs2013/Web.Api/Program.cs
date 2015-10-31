using System;
using Microsoft.Owin.Hosting;
using Sales;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var zzz = new BooksProvider().AllBooks();

            const string baseAddress = "http://localhost:9000/";
            
            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine("Serving {0}", baseAddress);
                Console.ReadLine(); 
            }
        }
    }
}
