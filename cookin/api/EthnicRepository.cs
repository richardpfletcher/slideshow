using Cook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

namespace Cook.API
{
    public class EthnicRepository
    {
        private HttpService _httpService;

        public EthnicRepository()
        {
            _httpService = new HttpService();
        }

        public EthnicModel GetModel(string parameters1)
        {
            try
            {
                Uri host = new Uri(ConfigurationManager.ConnectionStrings["LocalURI"].ConnectionString);
                string path = "";
                path = "/RestServiceImpl.svc/ethnicxml/" + parameters1; ;

                
                //string path = "/CookRestDeploy/RestServiceImpl.svc/ethnicxml/" + parameters1; ;
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                var user = ConfigurationManager.ConnectionStrings["LocalNetworkCredentialUser"];
                string strConnStringUser = user.ConnectionString;
                var password = ConfigurationManager.ConnectionStrings["LocalNetworkCredentialPassword"];
                string strConnStringPassword = password.ConnectionString;
                System.Net.NetworkCredential credential = new System.Net.NetworkCredential(strConnStringUser, strConnStringPassword);

                System.Xml.Linq.XDocument xml = _httpService.Get(host, path, parameters, credential);
                return ConvertModelXmlToList(xml);
            }
            catch (Exception ex)
            {
                string x = ex.ToString();
                throw;
            }
        }

        private EthnicModel ConvertModelXmlToList(System.Xml.Linq.XDocument xml)
        {
            try
            {
                System.Xml.Linq.XNamespace ns = "http://schemas.datacontract.org/2004/07/RestService.Entity";

                EthnicModel model = new EthnicModel();
                model.items.Add(new SelectListItem { Text = "Please Select one", Value = "0" });

                foreach (var el in xml.Descendants(ns + "EthnicEntity"))
                {
                    string ethnic = el.Element(ns + "Ethnic").Value;
                    string ethnicID = el.Element(ns + "EthnicID").Value;

                    model.items.Add(new SelectListItem { Text = ethnic, Value = ethnicID });
                }

                return model;
            }
            catch
            {
                throw;
            }
        }
    }
}