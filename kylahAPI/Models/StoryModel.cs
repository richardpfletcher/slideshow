using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Stories.Models
{

    public class Story
    {

        public int ID { get; set; }
        public int JakataID { get; set; }

        public int UserID { get; set; }
        public int StoryCategorytName { get; set; }
        public int Title { get; set; }
        public string AnimalType { get; set; }
        public int MoralType { get; set; }
        public string Comments { get; set; }
        public string Stories { get; set; }
        public DropdownModel animalCombo { get; set; }
        public DropdownModel youTubeCombo { get; set; }
        public DropdownModel done { get; set; }
        public DropdownModel toDo { get; set; }
        public string URL { get; set; }

        public DropdownModel IllustrationsCombo { get; set; }
        public DropdownModel ReadersCombo { get; set; }
        public DropdownModel MusicCombo { get; set; }
        public DropdownModel DanceCombo { get; set; }
        public DropdownModel AdminCombo { get; set; }


    }

    public class JakataMaster
    {
        public int ID { get; set; }
        public int JakataID { get; set; }
        public string Comments { get; set; }
        public string Roman { get; set; }
        public string Title { get; set; }
        public int StoryImported { get; set; }
      
    }

    public class useRoles
    {
        public string userName { get; set; }

        public string UserID { get; set; }
        public string email { get; set; }
        public string motherhelpers { get; set; }


    }


    public class youTubeModel
    {
        public string ID { get; set; }
        public string JakataID { get; set; }
        public string URL { get; set; }

        public string UseID { get; set; }

        
    }

    public class ReceipeTotalModel
    {
        public string totalReceipes { get; set; }

        public int totalReceipesInt { get; set; }
    }


    public class DropdownModel
    {

        public int ID { get; set; }
        public List<SelectListItem> items = new List<SelectListItem>();

    }

    /// <summary>
    /// Holds all the animal types
    /// </summary>
    public class AnimalTypes
    {

        public int ID { get; set; }
        public string AnimalType { get; set; }

    }

    /// <summary>
    /// Holds all the animal types
    /// </summary>
    public class MoralTypes
    {

        public int ID { get; set; }
        public string MoralType { get; set; }

    }

    public class StoryCategorytNames
    {

        public int ID { get; set; }
        public string StoryCategorytName { get; set; }

    }







    /// <summary>
    /// Login class
    /// </summary>

    public class Login
    {
        public string userName { get; set; }
        public string password { get; set; }

    }

    /// <summary>
    /// 
    /// </summary>

    [Serializable]
    public partial class MyOder
    {
        private string dataField;
        public string MyData
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }




}
