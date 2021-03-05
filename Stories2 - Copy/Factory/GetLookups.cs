using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Stories.Factory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.Xml.XPath;
using Stories.Models;
using System.Configuration;

namespace Stories.Factory
{
    public class GetLookups
    {
        public DropdownModel GeLookupAnimal()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/AnimalType/");
                
                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/AnimalType/");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/AnimalType/");

                }


                //var uri = new Uri("http://api.storyteller.today/api/AnimalType/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                //Model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("animalTypeLists"))
                {
                    string ID = el.Element("ID").Value;
                    string AnimalType = el.Element("AnimalType").Value;
                    model.items.Add(new SelectListItem { Text = AnimalType, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }

        public DropdownModel GeLookupMoral()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/MoralType/");

                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/MoralType/");
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/MoralType/");

                }

                //var uri = new Uri("http://api.storyteller.today/api/MoralType/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("moralTypeLists"))
                {
                    string ID = el.Element("ID").Value;
                    string AnimalType = el.Element("MoralType").Value;
                    model.items.Add(new SelectListItem { Text = AnimalType, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }

        public DropdownModel GeLookupStorySource()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/StorySource/");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/StorySource/");
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/StorySource/");

                }


                //var uri = new Uri("http://api.storyteller.today/api/StorySource/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("storySourceLists"))
                {
                    string ID = el.Element("ID").Value;
                    string AnimalType = el.Element("StorySource").Value;
                    model.items.Add(new SelectListItem { Text = AnimalType, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }

        }

        public DropdownModel GeLookupJakataMaster()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/JakataMaster/");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/JakataMaster/");
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/JakataMaster/");

                }

                //var uri = new Uri("http://api.storyteller.today/api/JakataMaster/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("jakataMasterLists"))
                {
                    string ID = el.Element("ID").Value;
                    string title = el.Element("Title").Value;
                    model.items.Add(new SelectListItem { Text = title, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }

        public DropdownModel GeLookupCatUsers(int id)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);

                }

                //var uri = new Uri(settings+"api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);
                //var uri = new Uri("http://api.storyteller.today/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                //Model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("mothersHelpersLists"))
                {
                    string ID = el.Element("ID").Value;
                    string Name = el.Element("Name").Value;
                    Name = Name.Trim();
                    model.items.Add(new SelectListItem { Text = Name, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }

        public DropdownModel GeLookupSpecificStoryDropdown()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/SpecificStoryDropdown/");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/SpecificStoryDropdown/");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/SpecificStoryDropdown/");


                }

                //var uri = new Uri("http://api.storyteller.today/api/SpecificStoryDropdown/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();
                model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("jakataMasterLists"))
                {
                    string ID = el.Element("ID").Value;
                    string title = el.Element("Title").Value;
                    model.items.Add(new SelectListItem { Text = title, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }


        public DropdownModel GetStatus(int status1)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/Storiesapi/ToDo/" + status1);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/Storiesapi/ToDo/" + status1);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/Storiesapi/ToDo/" + status1);


                }

                //var uri = new Uri(settings+"api/ToDo/" + status1);
                //var uri = new Uri("http://api.storyteller.today/api/Storiesapi/ToDo/" + status1);
                //var uri = new Uri("http://localhost:5199/api/JakataMaster/");

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                DropdownModel model = new DropdownModel();

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("toDoLists"))
                {
                    string ID = el.Element("ID").Value;
                    string title = el.Element("Title").Value;
                    model.items.Add(new SelectListItem { Text = title, Value = ID });
                }

                var animalType = "";

                foreach (SelectListItem s in model.items)
                {
                    if (s.Value == animalType)
                    {
                        s.Selected = true;
                    }
                }

                return model;
                //ViewData["animalTypeData"] = model.items;

            }
        }


        public Story GetSpecificStory(int row)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/Stories/" + row);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/Stories/" + row);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/Stories/" + row);


                }

                //var uri = new Uri("http://api.storyteller.today/api/Stories/" + row);
                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");


                Story modelStory = new Story();

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("specificStory"))
                {
                    modelStory.ID = Convert.ToInt16(el.Element("ID").Value);
                    modelStory.JakataID = Convert.ToInt16(el.Element("JakataID").Value);
                    modelStory.AnimalType = el.Element("AnimalType").Value;
                    modelStory.Comments = el.Element("Comments").Value; ;
                    modelStory.MoralType = Convert.ToInt16(el.Element("MoralType").Value);
                    modelStory.Stories = el.Element("Stories").Value;
                    modelStory.StoryCategorytName = Convert.ToInt16(el.Element("StoryCategorytName").Value);
                    modelStory.Title = Convert.ToInt16(el.Element("Title").Value);
                }



                return modelStory;

            }

        }

        public DropdownModel GetYouTube(int row)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/YouTube/" + row);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/YouTube/" + row);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/YouTube/" + row);


                }

                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;


                var x = JObject.Parse(responseString);

                XNode node = JsonConvert.DeserializeXNode(x.ToString(), "data");

                string a = node.ToString();
                string trima = a.Replace("\r\n", "");
                trima = a.Replace("{", "");
                trima = a.Replace("}", "");

                DropdownModel model = new DropdownModel();

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("youTubeLists"))
                {
                    string ID = el.Element("JakataID").Value;
                    string title = el.Element("URL").Value;
                    model.items.Add(new SelectListItem { Text = title, Value = ID });
                }

                return model;

            }
        }

    }
}