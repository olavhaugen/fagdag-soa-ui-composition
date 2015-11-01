using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using Web.Api.Infrastructure;

namespace Web.Api.AzureHost
{
    public class WorkerRole : RoleEntryPoint
    {
        private IDisposable _app = null;

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);

        public override void Run()
        {
            Trace.TraceInformation("Web.Api.AzureHost is running");

            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;

            var endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["Default"];

            string baseUri = String.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);

            Trace.TraceInformation(String.Format("Starting OWIN at {0}", baseUri), "Information");

            _app = WebApp.Start<Startup>(new StartOptions(url: baseUri));

            bool result = base.OnStart();

            Trace.TraceInformation("Web.Api.AzureHost has been started");

            return result;
        }

        public override void OnStop()
        {
            Trace.TraceInformation("Web.Api.AzureHost is stopping");

            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();

            if (_app != null)
            {
                _app.Dispose();
            }

            base.OnStop();

            Trace.TraceInformation("Web.Api.AzureHost has stopped");
        }

        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
}
