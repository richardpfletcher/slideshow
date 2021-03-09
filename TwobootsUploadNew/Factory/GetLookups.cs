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


        public DropdownModel GetMothersHelpersType()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/MothersHelpers/getMothersHelpersType/");

                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/MothersHelpers/getMothersHelpersType/");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/MothersHelpers/getMothersHelpersType/");


                }


                //var uri = new Uri(settings + "api/MothersHelpers/getMothersHelpersType/");

                
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

                foreach (var el in xml.Descendants("mothersHelpersTypeLists"))
                {
                    string ID = el.Element("ID").Value;
                    string AnimalType = el.Element("Name").Value;
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
                    uri = new Uri("http://localhost:5199/api/MoralType/");


                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/MoralType/");



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

        public DropdownModel GeLookupPosted()
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/Project/");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/Project/");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/Project/");


                }

                //var uri = new Uri(settings + "api/Project/");


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

                foreach (var el in xml.Descendants("postedLists"))
                {
                    string ID = el.Element("ID").Value;
                    string Posted = el.Element("Posted").Value;
                    model.items.Add(new SelectListItem { Text = Posted, Value = ID });
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
                //model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

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
                var uri = new Uri("http://api.twoboots.today/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.twoboots.today/api/MothersHelpers/getMothersHelpersTypeUsers?id=" + id);


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
                
                if (id==2 || id==0)
                {
                    model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });
                }
              

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

        public DropdownModel GetDishTitle()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("https://api.twoboots.today/api/DishTitle");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/DishTitle/get");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("https://api.twoboots.today/api/DishTitle");


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

                
                    model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });
                


                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("mothersHelpersLists"))
                {
                    string ID = el.Element("ID").Value;
                    string Name = el.Element("Title").Value;
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


        public DropdownModel GetStoryCategorytName()
        {
            using (var client = new System.Net.Http.HttpClient())
            {
                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/StoryCategorytName/");


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/StoryCategorytName/");

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/StoryCategorytName/");


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
                model.items.Add(new SelectListItem { Text = "Please Select ", Value = "0" });

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("storyCategorytNameLists"))
                {
                    string ID = el.Element("ID").Value;
                    string AnimalType = el.Element("StoryCategorytName").Value;
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
                var uri = new Uri("http://api.storyteller.today/api/ToDo/" + status1);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/ToDo/" + status1);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/ToDo/" + status1);


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


        public Story GetSpecificStory(int row,string mode)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/Stories/getSpecificStory?ID=" + row + "&Mode=JakataID");

                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/Stories/getSpecificStory?ID=" + row + "&Mode=JakataID");
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/Stories/getSpecificStory?ID=" + row + "&Mode=JakataID");

                }



                
                var response = client.GetAsync(uri).Result;

                var responseContent = response.Content;
                var responseString = responseContent.ReadAsStringAsync().Result;

                string s2 = "0 Records found";
                bool b = responseString.Contains(s2);

                if (b==true)
                {
                    uri = new Uri("http://api.storyteller.today/api/Stories/getSpecificStory?ID=" + row + "&Mode=ID");
                    response = client.GetAsync(uri).Result;
                    responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;

                }


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
                    modelStory.Stories =el.Element("Stories").Value;
                    modelStory.StoryCategorytName= Convert.ToInt16(el.Element("StoryCategorytName").Value) ;
                    modelStory.Title = Convert.ToInt16(el.Element("Title").Value);
                }



                return modelStory;
              
            }

        }

        public Story GetReaderstory(int JakataID,int userID)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/Project/getReaderstory?JakataID=" + JakataID + "&userID=" + userID);


                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/Project/getReaderstory?JakataID=" + JakataID + "&userID=" + userID);

                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/Project/getReaderstory?JakataID=" + JakataID + "&userID=" + userID);


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


                Story modelStory = new Story();

                XDocument xml = XDocument.Parse(trima);

                foreach (var el in xml.Descendants("readersStory"))
                {
                    modelStory.ID = Convert.ToInt16(el.Element("ID").Value);
                    modelStory.JakataID = Convert.ToInt16(el.Element("JakataID").Value);
                    modelStory.Comments = el.Element("Comments").Value; ;
                    modelStory.Title = Convert.ToInt16(el.Element("Title").Value);

                    modelStory.Name = el.Element("Name").Value;
                    modelStory.Illustrations = el.Element("Illustrations").Value;
                    modelStory.Music = el.Element("Music").Value;
                    modelStory.Dance = el.Element("Dance").Value; ;
                    modelStory.Admin = el.Element("Admin").Value;
                    modelStory.PostedString = el.Element("Posted").Value;
                    
                    modelStory.illustrationStartDate = el.Element("illustrationStartDate").Value; ;
                    modelStory.illustrationStopDate = el.Element("illustrationStopDate").Value; ;
                    modelStory.ReadersStartDate = el.Element("ReadersStartDate").Value; ;
                    modelStory.ReadersStopDate = el.Element("ReadersStopDate").Value; ;
                    modelStory.MusicStartDate = el.Element("MusicStartDate").Value; ;
                    modelStory.MusicStoptDate = el.Element("MusicStopDate").Value; ;
                    modelStory.DanceStartDate = el.Element("DanceStartDate").Value; ;
                    modelStory.DanceStopDate = el.Element("DanceStopDate").Value; ;
                    modelStory.postedDate = el.Element("postedDate").Value;


                }



                return modelStory;

            }

        }

        public DropdownModel GetYouTube(int row, int userID)
        {
            using (var client = new System.Net.Http.HttpClient())
            {

                var env = ConfigurationManager.AppSettings["Enviroment"];
                var settings = "";
                var uri = new Uri("http://api.storyteller.today/api/YouTube/getYouTube/?ID=" + row + "&UserID=" + userID);

                if (env == "Dev")
                {
                    settings = ConfigurationManager.AppSettings["LocalWebApi"];
                    uri = new Uri("http://localhost:5199/api/YouTube/getYouTube/?ID=" + row + "&UserID=" + userID);
                }
                else
                {
                    settings = ConfigurationManager.AppSettings["ProductionWebApi"];
                    uri = new Uri("http://api.storyteller.today/api/YouTube/getYouTube/?ID=" + row + "&UserID=" + userID);

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