using Cook.Models;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace Cook.API
{
    public class LatestPageRepository
    {
        private HttpService _httpService;

        public LatestPageRepository()
        {
            _httpService = new HttpService();
        }

        public List<MyFavoritesModel> GetModel()
        {
            try
            {
                Uri host = new Uri(ConfigurationManager.ConnectionStrings["LocalURI"].ConnectionString);
                string path = "";
                path = "/RestServiceImpl.svc/GetLatestGreek/";

               
                //string path = "/CookRestDeploy/RestServiceImpl.svc/GetLatest/";
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

        private List<MyFavoritesModel> ConvertModelXmlToList(System.Xml.Linq.XDocument xml)
        {
            try
            {
                System.Xml.Linq.XNamespace ns = "http://schemas.datacontract.org/2004/07/RestService.Entity";

                List<MyFavoritesModel> items = new List<MyFavoritesModel>();

                foreach (var el in xml.Descendants(ns + "MyFavoritesEntity"))
                {
                    MyFavoritesModel model = new MyFavoritesModel();
                    model.RECEIPTNO = Convert.ToInt16(el.Element(ns + "RECEIPTNO").Value);
                    model.Title = el.Element(ns + "Title").Value;
                    model.picture = el.Element(ns + "picture").Value;
                    model.comments = el.Element(ns + "comments").Value;

                    items.Add(model);
                }

                return items;
            }
            catch
            {
                throw;
            }
        }
    }
}