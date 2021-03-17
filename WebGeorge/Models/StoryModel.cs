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

        public int userID { get; set; }

        
        public int JakataID { get; set; }
        public int StoryCategorytName { get; set; }

        public string StoryCategorytNameString { get; set; }

        
        public int Title { get; set; }
        public string TitleString { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public int MoralType { get; set; }
        public string Comments { get; set; }
        public string Stories { get; set; }
        public DropdownModel animalCombo { get; set; }
        public DropdownModel MothersHelpersTypeCombo { get; set; }
        public DropdownModel moralCombo { get; set; }
        public DropdownModel StoryCategorytNameCombo { get; set; }


        public DropdownModel youTubeCombo { get; set; }
        public DropdownModel done { get; set; }
        public DropdownModel toDo { get; set; }
        public string URL { get; set; }

        public string Illustrations { get; set; }
        public string Readers { get; set; }
        public string Music { get; set; }
        public string Dance { get; set; }
        public string Admin { get; set; }



        public DropdownModel IllustrationsCombo { get; set; }
        public DropdownModel ReadersCombo { get; set; }
        public DropdownModel MusicCombo { get; set; }
        public DropdownModel DanceCombo { get; set; }
        public DropdownModel AdminCombo { get; set; }
        public string EnterDate { get; set; }

        public string illustrationStartDate { get; set; }
        public string illustrationStopDate { get; set; }
        public string ReadersStartDate { get; set; }
        public string ReadersStopDate { get; set; }
        public string MusicStartDate { get; set; }
        public string MusicStoptDate { get; set; }
        public string DanceStartDate { get; set; }
        public string DanceStopDate { get; set; }
        public string postedDate { get; set; }
        public string PostedString { get; set; }

        public DropdownModel Posted { get; set; }
        public string userName { get; set; }
        public string Mode { get; set; }






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
