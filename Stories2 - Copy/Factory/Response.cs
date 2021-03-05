using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;


namespace Stories.Factory
{
    public class animalType
    {
        public string ID { get; set; }
        public string AnimalType { get; set; }

    }

    public class AnimalTypeList
    {
        [XmlArray("animalType")]
        [XmlArrayItem("animalType")]
        public List<animalType> animalTypeLists { get; set; }
        public AnimalTypeList()
        {
            animalTypeLists = new List<animalType>();
        }
    }

    public class mothersHelpers
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }

    public class MothersHelpersList
    {
        [XmlArray("mothersHelpers")]
        [XmlArrayItem("mothersHelpers")]
        public List<mothersHelpers> mothersHelpersLists { get; set; }
        public MothersHelpersList()
        {
            mothersHelpersLists = new List<mothersHelpers>();
        }
    }

    public class mothersHelpersType
    {
        public string ID { get; set; }
        public string Name { get; set; }

    }

    public class MothersHelpersTypeList
    {
        [XmlArray("mothersHelpersType")]
        [XmlArrayItem("mothersHelpersType")]
        public List<mothersHelpersType> mothersHelpersTypeLists { get; set; }
        public MothersHelpersTypeList()
        {
            mothersHelpersTypeLists = new List<mothersHelpersType>();
        }
    }

    public class mothersHelpersSpecific
    {
        public string UserID { get; set; }
        public string MothersHelpersType { get; set; }
       
    }

    public class MothersHelpersSpecificList
    {
        [XmlArray("mothersHelpersSpecific")]
        [XmlArrayItem("mothersHelpersSpecific")]
        public List<mothersHelpersSpecific> mothersHelpersSpecificLists { get; set; }
        public MothersHelpersSpecificList()
        {
            mothersHelpersSpecificLists = new List<mothersHelpersSpecific>();
        }
    }

    public class storySource
    {
        public string ID { get; set; }
        public string StorySource { get; set; }

    }

    public class StorySourceList
    {
        [XmlArray("storySource")]
        [XmlArrayItem("storySource")]
        public List<storySource> storySourceLists { get; set; }
        public StorySourceList()
        {
            storySourceLists = new List<storySource>();
        }
    }

    public class jakataMaster
    {
        public string ID { get; set; }
        public string Title { get; set; }

    }

    public class JakataMasterList
    {
        [XmlArray("jakataMaster")]
        [XmlArrayItem("jakataMaster")]
        public List<jakataMaster> jakataMasterLists { get; set; }
        public JakataMasterList()
        {
            jakataMasterLists = new List<jakataMaster>();
        }
    }

    public class toDo
    {
        public string ID { get; set; }
        public string Title { get; set; }

    }

    public class ToDoList
    {
        [XmlArray(" toDo")]
        [XmlArrayItem(" toDo")]
        public List<toDo> toDoLists { get; set; }
        public ToDoList()
        {
            toDoLists = new List<toDo>();
        }
    }




    public class youTube
    {
        public string ID { get; set; }
        public string JakataID { get; set; }
        public string URL { get; set; }
    }

    public class YouTubeList
    {
        [XmlArray("youTube")]
        [XmlArrayItem("youTube")]
        public List<youTube> youTubeLists { get; set; }
        public YouTubeList()
        {
            youTubeLists = new List<youTube>();
        }
    }

    public class moralType
    {
        public string ID { get; set; }
        public string MoralType { get; set; }

    }

    public class MoralTypeList
    {
        [XmlArray("moralType")]
        [XmlArrayItem("moralType")]
        public List<moralType> moralTypeLists { get; set; }
        public MoralTypeList()
        {
            moralTypeLists = new List<moralType>();
        }
    }


    public class posted
    {
        public string ID { get; set; }
        public string Posted { get; set; }

    }

    public class PostedList
    {
        [XmlArray("posted")]
        [XmlArrayItem("posted")]
        public List<posted> postedLists { get; set; }
        public PostedList()
        {
            postedLists = new List<posted>();
        }
    }




    public class storyCategorytName
    {
        public string ID { get; set; }
        public string StoryCategorytName { get; set; }

    }

    public class StoryCategorytNameList
    {
        [XmlArray("storyCategorytName")]
        [XmlArrayItem("storyCategorytName")]
        public List<storyCategorytName> storyCategorytNameLists { get; set; }
        public StoryCategorytNameList()
        {
            storyCategorytNameLists = new List<storyCategorytName>();
        }
    }




    public class specificStory
    {
        public string ID { get; set; }
        public string JakataID { get; set; }
        public string UserID { get; set; }
        public string StoryCategorytName { get; set; }
        public string Title { get; set; }
        public string AnimalType { get; set; }
        public string MoralType { get; set; }
        public string Comments { get; set; }
        public string Stories { get; set; }



    }

    public class SpecificStoryList
    {
        [XmlArray("specificStory")]
        [XmlArrayItem("specificStory")]
        public List<specificStory> specificStory { get; set; }
        public SpecificStoryList()
        {
            specificStory = new List<specificStory>();
        }
    }


    public class readersStory
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
        public string JakataID { get; set; }
        public string Comments { get; set; }

        public string Title { get; set; }
        public string Illustrations { get; set; }
        public string Readers { get; set; }

        public string Music { get; set; }

        public string Dance { get; set; }
        public string Admin { get; set; }
        public string Posted { get; set; }
        public string postedDate { get; set; }
        public string illustrationStartDate { get; set; }
        public string illustrationStopDate { get; set; }

        public string ReadersStartDate { get; set; }
        public string ReadersStopDate { get; set; }
        public string MusicStartDate { get; set; }

        public string MusicStopDate { get; set; }

        public string DanceStartDate { get; set; }

        public string DanceStopDate { get; set; }

        
        public string Mode { get; set; }




    }

    public class ReadersStoryList
    {
        [XmlArray("readersStory")]
        [XmlArrayItem("readersStory")]
        public List<readersStory> readersStory { get; set; }
        public ReadersStoryList()
        {
            readersStory = new List<readersStory>();
        }
    }




    ////We have to include any custom derived classes using XmlInclude
    [XmlRoot("response")]
    //[XmlInclude(typeof(ProductCertificatesList))]
    [XmlInclude(typeof(AnimalTypeList))]

    public class response
    {
        [XmlElement("result")]
        public int result;
        [XmlElement("xmlData")]
        public XmlDocument xmlData;
        //data will accept any type of primitive or strictly typed class object
        [XmlElement("data")]
        public List<object> data;
        [XmlArray("log")]
        [XmlArrayItem("entry")]
        public List<string> log;
        //Constructor (even if empty) is required for XmlSerializer to work as it needs to instantiate the class in order to serialize it
        public response()
        {
            //result = -1;
            data = new List<object>();
            log = new List<string>();
        }
        //Simply
        public IList AddSpecificStoryList(SpecificStoryList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddAnimalTypeList(AnimalTypeList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddMothersHelpersList(MothersHelpersList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddMothersHelpersSpecificList(MothersHelpersSpecificList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddMothersHelpersTypeList(MothersHelpersTypeList list)
        {
            data.Add(list);
            return data;
        }


        public IList AddStorySourceList(StorySourceList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddJakataMasterList(JakataMasterList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddToDoList(ToDoList list)
        {
            data.Add(list);
            return data;
        }


        public IList AddMoralTypeList(MoralTypeList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddPostedList(PostedList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddYouTubeList(YouTubeList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddStoryCategorytNameList(StoryCategorytNameList list)
        {
            data.Add(list);
            return data;
        }

        public IList AddReadersStoryList(ReadersStoryList list)
        {
            data.Add(list);
            return data;
        }




        public IList AddStringData(string strData)
        {
            data.Add(strData);
            return data;
        }
    }
}
