using Dapper;
//using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using Stories.Models;
using System.Data.SqlClient;


namespace Stories.Factory
{
    public class GetStories
    {
        public static List<string> romanNumerals = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public static List<int> numerals = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        // Maps letters to numbers.
        private Dictionary<char, int> CharValues = null;



        /// <summary>
        /// Inserts a new account
        /// </summary>
        /// <param name="myStory"></param>
        /// <returns></returns>

        public int Insert(Story myStory)
        {
            var p = new DynamicParameters();

            p.Add("@JakataID", myStory.JakataID);
            p.Add("@StoryCategorytName", 1);
            p.Add("@Title", myStory.Title);
            p.Add("@AnimalType", myStory.AnimalType);
            p.Add("@MoralType", myStory.MoralType);
            p.Add("@Comments", myStory.Comments);
            p.Add("@Stories", myStory.Stories);


            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = 0;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.InsertStory";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

             return total;

        }


        /// <summary>
        /// Inserts a new account
        /// </summary>
        /// <param name="myStory"></param>
        /// <returns></returns>

        public int InsertURL(youTubeModel myStory)
        {
            var p = new DynamicParameters();

            p.Add("@JakataID", myStory.JakataID);
            p.Add("@URL", myStory.URL);
          
            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = 0;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.InsertURL";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

            return total;






        }

        /// <summary>
        /// Inserts a new account
        /// </summary>
        /// <param name="myStory"></param>
        /// <returns></returns>

        public int Update(Story myStory)
        {
            var p = new DynamicParameters();

            p.Add("@ID", myStory.ID);
            p.Add("@JakataID", myStory.JakataID);
            p.Add("@StoryCategorytName", 1);
            p.Add("@Title", myStory.Title);
            p.Add("@AnimalType", myStory.AnimalType);
            p.Add("@MoralType", myStory.MoralType);
            p.Add("@Comments", myStory.Comments);
            p.Add("@Stories", myStory.Stories);


            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = myStory.ID;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.UpdateStory";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                //foreach (var el in values)
                //{
                //    total = el.totalReceipesInt;
                //}
            }

            

            return total;

        }






            public response GetAnimal()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "AnimalType" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetAnimalType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    AnimalTypeList list = new AnimalTypeList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        animalType myprod = new animalType();
                        myprod.ID = row["ID"].ToString();
                        myprod.AnimalType = row["AnimalType"].ToString();


                        list.animalTypeLists.Add(myprod);
                    }
                    response.AddAnimalTypeList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetMoralType()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MoralType" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMoralType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MoralTypeList list = new MoralTypeList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        moralType myprod = new moralType();
                        myprod.ID = row["ID"].ToString();
                        myprod.MoralType = row["MoralType"].ToString();


                        list.moralTypeLists.Add(myprod);
                    }
                    response.AddMoralTypeList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }


        public response GetStoryCategorytName()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "StoryCategorytName" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetStoryCategorytName", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    StoryCategorytNameList list = new StoryCategorytNameList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        storyCategorytName myprod = new storyCategorytName();
                        myprod.ID = row["ID"].ToString();
                        myprod.StoryCategorytName = row["StoryCategorytName"].ToString();


                        list.storyCategorytNameLists.Add(myprod);
                    }
                    response.AddStoryCategorytNameList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }


        //public string GetStoryCategoryNameByID(int id)
        //{

        //    var dataTable = new DataTable();
        //    dataTable = new DataTable { TableName = "StoryCategorytName" };
        //    //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
        //    //string connString = conString1.ConnectionString;
        //    string connString = URLInfo.GetDataBaseConnectionString();


        //    System.IO.StringWriter writer = new System.IO.StringWriter();
        //    string returnString = "";
        //    response response = new response();
        //    response.result = 0;
        //    string StoryCategorytName = "";





        //    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
        //    {
        //        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetStoryCategoryNameByID", con))                 {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
        //            con.Open();
        //            var dataReader = cmd.ExecuteReader();
        //            dataTable.Load(dataReader);
        //            dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
        //            returnString = writer.ToString();
        //            int numberOfRecords = dataTable.Rows.Count;
        //            response.result = numberOfRecords;





        //            foreach (DataRow row in dataTable.Rows)
        //            {
        //                StoryCategorytName = row["StoryCategorytName"].ToString();

        //            }

        //        }
        //    }
        //    return StoryCategorytName;
        //}

        public string GetStoryCategoryNameByID(int id)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "StoryCategorytName" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;

            string StoryCategorytName = "";


            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetStoryCategoryNameByID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    foreach (DataRow row in dataTable.Rows)
                    {
                        StoryCategorytName = row["StoryCategorytName"].ToString();

                    }
                  
                }
            }
            return StoryCategorytName;
        }


        public string ToRomanNumeral(int number)
        {
            var romanNumeral = string.Empty;
            while (number > 0)
            {
                // find biggest numeral that is less than equal to number
                var index = numerals.FindIndex(x => x <= number);
                // subtract it's value from your number
                number -= numerals[index];
                // tack it onto the end of your roman numeral
                romanNumeral += romanNumerals[index];
            }
            return romanNumeral;
        }

        // Convert Roman numerals to an integer.
        public int RomanToArabic(string roman)
        {
            // Initialize the letter map.
            if (CharValues == null)
            {
                CharValues = new Dictionary<char, int>();
                CharValues.Add('I', 1);
                CharValues.Add('V', 5);
                CharValues.Add('X', 10);
                CharValues.Add('L', 50);
                CharValues.Add('C', 100);
                CharValues.Add('D', 500);
                CharValues.Add('M', 1000);
            }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

            // See if the number begins with (.
            if (roman[0] == '(')
            {
                // Find the closing parenthesis.
                int pos = roman.LastIndexOf(')');

                // Get the value inside the parentheses.
                string part1 = roman.Substring(1, pos - 1);
                string part2 = roman.Substring(pos + 1);
                return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

            // The number doesn't begin with (.
            // Convert the letters' values.
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {
                int new_value = CharValues[roman[i]];

                // See if we should add or subtract.
                if (new_value < last_value)
                    total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

            // Return the result.
            return total;
        }

        public response GetStorySource()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "StorySource" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetStorySource", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    StorySourceList list = new StorySourceList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        storySource myprod = new storySource();
                        myprod.ID = row["ID"].ToString();
                        myprod.StorySource = row["StorySource"].ToString();


                        list.storySourceLists.Add(myprod);
                    }
                    response.AddStorySourceList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetSpecificStoryDropdown()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "JakataMaster" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetSpecificStoryDropdown", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    JakataMasterList list = new JakataMasterList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        jakataMaster myprod = new jakataMaster();
                        myprod.ID = row["ID"].ToString();
                        myprod.Title = row["Title"].ToString();


                        list.jakataMasterLists.Add(myprod);
                    }
                    response.AddJakataMasterList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetSpecificStoryDropdownStatus(int ID)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "JakataMaster" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetSpecificStoryDropdownStatus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@StoryImported", SqlDbType.NVarChar).Value = ID;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;

                    //JakataMasterList list = new JakataMasterList();
                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    jakataMaster myprod = new jakataMaster();
                    //    myprod.ID = row["JakataID"].ToString();
                    //    myprod.Title = row["Title"].ToString();


                    //    list.jakataMasterLists.Add(myprod);
                    //}


                    ToDoList list = new ToDoList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        toDo myprod = new toDo();
                        myprod.ID = row["JakataID"].ToString();
                        myprod.Title = row["Title"].ToString();


                        list.toDoLists.Add(myprod);
                    }
                    //response.AddJakataMasterList(list);
                    response.AddToDoList(list);
                    //response.AddToDoList(list);



                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetYouTube(int JakataID)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "YouTube" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();

            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("GetYouTube", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@JakataID", SqlDbType.NVarChar).Value = JakataID;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    YouTubeList list = new YouTubeList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        youTube myprod = new youTube();
                        myprod.ID = row["ID"].ToString();
                        myprod.JakataID = row["JakataID"].ToString();
                        myprod.URL = row["URL"].ToString();


                        list.youTubeLists.Add(myprod);
                    }
                    response.AddYouTubeList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetSpecificStory(int ID)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Stories" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();

            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSpecificStory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = ID;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    SpecificStoryList list = new SpecificStoryList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        specificStory myprod = new specificStory();
                        myprod.ID = row["ID"].ToString();
                        myprod.JakataID = row["JakataID"].ToString();
                        myprod.AnimalType = row["AnimalType"].ToString();
                        myprod.Comments = row["Comments"].ToString();
                        myprod.MoralType = row["MoralType"].ToString();
                        myprod.Stories = row["Stories"].ToString();
                        myprod.StoryCategorytName = row["StoryCategorytName"].ToString();
                        myprod.Title = row["Title"].ToString();


                        list.specificStory.Add(myprod);
                    }
                    response.AddSpecificStoryList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetJakataMaster()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "JakataMaster" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetJakataMaster", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    JakataMasterList list = new JakataMasterList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        jakataMaster myprod = new jakataMaster();
                        myprod.ID = row["ID"].ToString();
                        myprod.Title = row["Title"].ToString();


                        list.jakataMasterLists.Add(myprod);
                    }
                    response.AddJakataMasterList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }
    }
}