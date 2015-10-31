using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Web.Api.Infrastructure
{
    public class RequestLogger : OwinMiddleware
    {
        private readonly OwinMiddleware _next;

        public RequestLogger(OwinMiddleware next)
            : base(next)
        {
            _next = next;
        }

        public override async Task Invoke(IOwinContext context)
        {
            Console.WriteLine("[{0}] {1} {2}", Thread.CurrentThread.ManagedThreadId, context.Request.Method, context.Request.Uri);

            foreach (var header in context.Request.Headers)
            {
                Console.WriteLine("\t{0} {1}", header.Key, string.Join(", ", header.Value));
            }
            Console.WriteLine();

            await _next.Invoke(context);
        }
    }
}