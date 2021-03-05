using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Web.Http;
//using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web.Http.Cors;
namespace Stories
{

    public class CorsHandler : DelegatingHandler
    {
        const string Origin = "Origin";
        const string AccessControlRequestMethod = "Access-Control-Request-Method";
        const string AccessControlRequestHeaders = "Access-Control-Request-Headers";
        const string AccessControlAllowOrigin = "Access-Control-Allow-Origin";
        const string AccessControlAllowMethods = "Access-Control-Allow-Methods";
        const string AccessControlAllowHeaders = "Access-Control-Allow-Headers";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            bool isCorsRequest = request.Headers.Contains(Origin);
            bool isPreflightRequest = request.Method == HttpMethod.Options;
            if (isCorsRequest)
            {
                if (isPreflightRequest)
                {
                    return Task.Factory.StartNew<HttpResponseMessage>(() =>
                    {
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                        response.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());

                        string accessControlRequestMethod = request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();
                        if (accessControlRequestMethod != null)
                        {
                            response.Headers.Add(AccessControlAllowMethods, accessControlRequestMethod);
                        }

                        string requestedHeaders = string.Join(", ", request.Headers.GetValues(AccessControlRequestHeaders));
                        if (!string.IsNullOrEmpty(requestedHeaders))
                        {
                            response.Headers.Add(AccessControlAllowHeaders, requestedHeaders);
                        }

                        return response;
                    }, cancellationToken);
                }
                else
                {
                    return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(t =>
                    {
                        HttpResponseMessage resp = t.Result;
                        resp.Headers.Add(AccessControlAllowOrigin, request.Headers.GetValues(Origin).First());
                        return resp;
                    });
                }
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }
    }




    //Our custom Content Negotiator handles incoming Content-type requets (for either application/xml or application/json) and channels to the appropriate formatter
    public class CustomContentNegotiator : DefaultContentNegotiator
    {
        private MediaTypeFormatter FindFormatter(IEnumerable<MediaTypeFormatter> formatters, MediaTypeHeaderValue acceptType)
        {

            foreach (MediaTypeFormatter formatter in formatters)
            {
                var foundMediaType = formatter.SupportedMediaTypes.Where(mt => mt.MediaType == acceptType.MediaType).SingleOrDefault();
                if (foundMediaType != null)
                {
                    return formatter;
                }
            }

            return null;
        }

        public override ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
        {

            MediaTypeFormatter formatter = FindFormatter(formatters, request.Content.Headers.ContentType);

            if (formatter != null)
            {
                return new ContentNegotiationResult(formatter, request.Content.Headers.ContentType);
            }
            else
            {
                return base.Negotiate(type, request, formatters);
            }

        }
    }

    //Our simple JSON Formatter, does nothing special as it is based on the built-in formatter. We have it here in order to add it back in when resetting the formatters
    public class BrowserJsonFormatter : JsonMediaTypeFormatter
    {
        public BrowserJsonFormatter()
        {
            //We don't need this line as it is already set by the base.SetDefaultContentHeaders which automatically derives the content type
            //this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            this.SerializerSettings.Formatting = Formatting.Indented;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            //We don't need this line as it is already set by the base.SetDefaultContentHeaders which automatically derives the content type
            //headers.ContentType = new MediaTypeHeaderValue("application/json");
            base.SetDefaultContentHeaders(type, headers, mediaType);
        }
    }

    //Our Custom XMLFormatter is basically the old-school XML Serializers that gives us naturally named XML nodes instead of dp2 etc. for custom and derived classes
    public class CustomNamespaceXmlFormatter : XmlMediaTypeFormatter
    {
        private readonly string defaultRootNamespace;

        public CustomNamespaceXmlFormatter()
            : this(string.Empty)
        {
        }

        public CustomNamespaceXmlFormatter(string defaultRootNamespace)
        {
            //We don't need this line as it is already set by the base.SetDefaultContentHeaders which automatically derives the content type
            //this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/xml"));
            this.defaultRootNamespace = defaultRootNamespace;
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            //We don't need this line as it is already set by the base.SetDefaultContentHeaders which automatically derives the content type
            //headers.ContentType = new MediaTypeHeaderValue("application/xml");
            base.SetDefaultContentHeaders(type, headers, mediaType);
        }

        public override Task WriteToStreamAsync(
            Type type,
            object value,
            Stream writeStream,
            HttpContent content,
            TransportContext transportContext)
        {
            var xmlRootAttribute = type.GetCustomAttribute<XmlRootAttribute>(true);
            if (xmlRootAttribute == null)
                xmlRootAttribute = new XmlRootAttribute(type.Name)
                {
                    Namespace = defaultRootNamespace
                };
            else if (xmlRootAttribute.Namespace == null)
                xmlRootAttribute = new XmlRootAttribute(xmlRootAttribute.ElementName)
                {
                    Namespace = defaultRootNamespace
                };

            var xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, xmlRootAttribute.Namespace);

            return Task.Factory.StartNew(() =>
            {
                var serializer = new XmlSerializer(type, xmlRootAttribute);
                serializer.Serialize(writeStream, value, xns);
            });
        }
    }







    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            //config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
