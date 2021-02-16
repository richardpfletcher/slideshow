using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Cook.API
{
    public class HttpService
    {
        public HttpService()
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(AcceptCertificate);
        }

        public XDocument Post(Uri host, string path, Dictionary<string, string> headers, string payload, NetworkCredential credential)
        {
            try
            {
                //Uri url = new Uri(host.Url, path);
                Uri url = new Uri(path);
                MvcHtmlString encodedPayload = MvcHtmlString.Create(payload);
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] data = encoding.GetBytes(encodedPayload.ToHtmlString());
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "POST";
                request.Credentials = credential;
                request.ContentLength = data.Length;
                request.KeepAlive = false;
                request.ContentType = "application/xml";
                MvcHtmlString htmlString1;
                MvcHtmlString htmlString2;
                foreach (KeyValuePair<string, string> header in headers)
                {
                    htmlString1 = MvcHtmlString.Create(header.Key);
                    htmlString2 = MvcHtmlString.Create(header.Value);
                    request.Headers.Add(htmlString1.ToHtmlString(), htmlString2.ToHtmlString());
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                    {
                        throw new HttpException((int)response.StatusCode, response.StatusDescription);
                    }
                    XDocument xmlDoc = XDocument.Load(responseStream);
                    responseStream.Close();
                    response.Close();
                    return xmlDoc;
                }
            }
            catch
            {
                throw;
            }
        }

        public XDocument Get(System.Uri host, string path, Dictionary<string, string> parameters, NetworkCredential credential)
        {
            try
            {
                Uri url;
                StringBuilder parameterString = new StringBuilder();
                if (parameters == null || parameters.Count <= 0)
                {
                    parameterString.Clear();
                }
                else
                {
                    parameterString.Append("?");
                    foreach (KeyValuePair<string, string> parameter in parameters)
                    {
                        parameterString.Append(parameter.Key + "=" + parameter.Value + "&");
                    }
                }

                url = new Uri(host, path + parameterString.ToString().TrimEnd(new char[] { '&' }));
                //url = new Uri(host.Url, path + parameterString.ToString().TrimEnd(new char[] { '&' }));

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Credentials = credential;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new HttpException((int)response.StatusCode, response.StatusDescription);
                    }
                    XDocument xmlDoc = XDocument.Load(response.GetResponseStream());
                    return xmlDoc;
                }
            }
            catch
            {
                throw;
            }
        }

        /*         I use this class for internal web services.  For external web services, you'll want         to put some logic in here to determine whether or not you should accept a certificate         or not if the domain name in the cert doesn't match the url you are accessing.         */

        private static bool AcceptCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}