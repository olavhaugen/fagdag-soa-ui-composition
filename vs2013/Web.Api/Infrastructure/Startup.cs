using System.Net.Http.Headers;
using System.Web.Cors;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace Web.Api.Infrastructure
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            
            var jsonFormatter = config.Formatters.JsonFormatter;

            jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            appBuilder.UseCors(CorsOptions.AllowAll);

            appBuilder.Use<ResponseLogger>();
            appBuilder.Use<RequestLogger>();

            appBuilder.UseWebApi(config);
        } 
    }
}