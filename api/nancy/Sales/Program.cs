namespace Sales
{
    using System;
    using System.Linq;
    using Nancy;
    using Nancy.Hosting.Self;
    using Topshelf;

    public class SalesModule : NancyModule
    {
        readonly Book[] books =
        {
            new Book { id="1", title = "Good book", description= "The very best book ever" },
            new Book { id="2", title = "Bad book", description = "The worst book ever" }
        };

        private class Book
        {
            public string id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
        }

        public SalesModule()
        {
            this.Get["/books"] = parameters => this.Response.AsJson(this.books);
            this.Get["/books/{id}"] = parameters => this.Response.AsJson(this.books.First(book => book.id == parameters.id));
        }
    }
    public class SalesSelfHost
    {
        private NancyHost nancyHost;

        public void Start()
        {
            var configuration = new HostConfiguration { UrlReservations = { CreateAutomatically = true } };
            this.nancyHost = new NancyHost(configuration, new Uri("http://localhost:5000"));
            this.nancyHost.Start();
        }

        public void Stop()
        {
            this.nancyHost.Stop();
        }
    }

    class Program
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                x.UseLinuxIfAvailable();
                x.Service<SalesSelfHost>(s =>
                {
                    s.ConstructUsing(name => new SalesSelfHost());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
                x.SetDisplayName("Sales self-host service");
                x.SetServiceName("Sales-Self-Host-Service");
            });
        }
    }
}
