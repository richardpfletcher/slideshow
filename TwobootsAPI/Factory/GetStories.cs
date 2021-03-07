using Dapper;
//using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Stories.Models;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using System.Text;
using System.Web.Http;

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

            var AnimalType = myStory.AnimalType;

            AnimalType = AnimalType.Trim();

            if (AnimalType.EndsWith(","))
            {
                AnimalType = AnimalType.Remove(AnimalType.Length - 1, 1);
                myStory.AnimalType = AnimalType;
            }



            p.Add("@JakataID", myStory.JakataID);
            p.Add("@StoryCategorytName", myStory.StoryCategorytName);
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


        public int UpdateRoles(useRoles myStory)
        {
            var p = new DynamicParameters();

            var motherhelpers = myStory.motherhelpers;

            motherhelpers = motherhelpers.Trim();

            if (motherhelpers.EndsWith(","))
            {
                motherhelpers = motherhelpers.Remove(motherhelpers.Length - 1, 1);
                myStory.motherhelpers = motherhelpers;
            }

            int total = 0;

            if (myStory.UserID !="0")
            {
       

            //update MothersHelpers table

            p.Add("@Email", myStory.email);
            p.Add("@Name", myStory.userName);
            p.Add("@ID", myStory.UserID);
            p.Add("@motherhelpers", myStory.motherhelpers);

            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;


            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.UpdateRoles";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

            }
            else
            {
                p.Add("@Email", myStory.email);
                p.Add("@Name", myStory.userName);
                p.Add("@motherhelpers", myStory.motherhelpers);

                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.InsertRoles";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
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
            p.Add("@UseID", myStory.UseID);
            

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

        public int InsertCategoryName(string category)
        {
            var p = new DynamicParameters();

            p.Add("@StoryCategorytName", category);




            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = 0;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.InsertStoryCategorytName";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

            return total;






        }


        public int DeleteURL(youTubeModel myStory)
        {
            var p = new DynamicParameters();

            p.Add("@JakataID", myStory.JakataID);
            p.Add("@UseID", myStory.UseID);


            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = 0;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.DeleteURL";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

            return total;






        }



        public int updateAnimal(int id, string AnimalType)
        {
            
            int total = 0;

            if (id > 0)
            {
                var p = new DynamicParameters();

                p.Add("@id", id);
                p.Add("@AnimalType", AnimalType);


                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.updateAnimal";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;
            }
            else
            {
                var p = new DynamicParameters();

                p.Add("@AnimalType", AnimalType);


                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.insertAnimal";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;

            }






        }

        public int updateMoralType(int id, string MoralType)
        {

            int total = 0;

            if (id > 0)
            {
                var p = new DynamicParameters();

                p.Add("@id", id);
                p.Add("@MoralType", MoralType);


                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.updateMoraltype";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;
            }
            else
            {
                var p = new DynamicParameters();

                p.Add("@MoralType", MoralType);


                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.InserMoralType";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;

            }






        }

        public int JakataMaster(JakataMaster myJakataMaster)
        {

            int total = 0;

            if (myJakataMaster.JakataID > 0)
            {
                var p = new DynamicParameters();

                p.Add("@JakataID", myJakataMaster.JakataID);
                p.Add("@Title", myJakataMaster.Title);


                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.updateJakataMaster";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;
            }
            else
            {
                var p = new DynamicParameters();

                myJakataMaster.Comments = "";
                myJakataMaster.Roman = "";

                p.Add("@Title", myJakataMaster.Title);
                p.Add("@JakataID", myJakataMaster.JakataID);
                p.Add("@Comments", myJakataMaster.Comments);
                p.Add("@StoryImported", myJakataMaster.StoryImported);

                p.Add("@Roman", myJakataMaster.Roman);





                var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
                string strConnString = conString.ConnectionString;


                using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
                {
                    sqlConnection.Open();
                    const string storedProcedure = "dbo.InsertJakataMaster";
                    var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                    foreach (var el in values)
                    {
                        total = el.totalReceipesInt;
                    }
                }

                return total;

            }






        }

        /// <summary>
        /// Inserts a new account
        /// </summary>
        /// <param name="myStory"></param>
        /// <returns></returns>

        public int Update(Story myStory)
        {
            var p = new DynamicParameters();

            var AnimalType = myStory.AnimalType;

            AnimalType = AnimalType.Trim();

            if (AnimalType.EndsWith(","))
            {
                AnimalType = AnimalType.Remove(AnimalType.Length - 1, 1);
                myStory.AnimalType = AnimalType;
            }

            p.Add("@ID", myStory.ID);
            p.Add("@JakataID", myStory.JakataID);
            p.Add("@StoryCategorytName", myStory.StoryCategorytName);
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
            dataTable = new DataTable { TableName = "Dish" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetLatest", con))
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
                    //foreach (DataRow row in dataTable.Rows)
                    //{
                    //    animalType myprod = new animalType();
                    //    myprod.ID = row["ID"].ToString();
                    //    myprod.AnimalType = row["AnimalType"].ToString();


                    //    list.animalTypeLists.Add(myprod);
                    //}
                    response.AddAnimalTypeList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetMothersHelpers()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MothersHelpers" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMothersHelpers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpers myprod = new mothersHelpers();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();


                        list.mothersHelpersLists.Add(myprod);
                    }
                    response.AddMothersHelpersList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetMothersHelpersTypeUsers(int id)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MothersHelpers" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMothersHelpersTypeUsers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpers myprod = new mothersHelpers();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();


                        list.mothersHelpersLists.Add(myprod);
                    }
                    response.AddMothersHelpersList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }


        public response GetDishTitle()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Dish" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetDishTitle", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpers myprod = new mothersHelpers();
                        myprod.ID = row["ID"].ToString();
                        myprod.Title = row["Title"].ToString();


                        list.mothersHelpersLists.Add(myprod);
                    }
                    response.AddMothersHelpersList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetMothersHelpersTypeSpecific(int id)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MothersHelpers" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMothersHelpersTypeSpecific", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@userID", SqlDbType.NVarChar).Value = id;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersSpecificList list = new MothersHelpersSpecificList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpersSpecific myprod = new mothersHelpersSpecific();
                        myprod.UserID = row["UserID"].ToString();
                        myprod.MothersHelpersType = row["MothersHelpersType"].ToString();


                        list.mothersHelpersSpecificLists.Add(myprod);
                    }
                    response.AddMothersHelpersSpecificList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetMothersEmail(int id)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MothersHelpers" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMothersEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpers myprod = new mothersHelpers();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();
                        myprod.Email = row["Email"].ToString();


                        list.mothersHelpersLists.Add(myprod);
                    }
                    response.AddMothersHelpersList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }


        public response GetMothersHelpersType()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "MothersHelpers" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetMothersHelpersType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersTypeList list = new MothersHelpersTypeList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpersType myprod = new mothersHelpersType();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();
                      
                        list.mothersHelpersTypeLists.Add(myprod);
                    }
                    response.AddMothersHelpersTypeList(list);

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

        public response GetPosted()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Posted" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetPosted", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    PostedList list = new PostedList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        posted myprod = new posted();
                        myprod.ID = row["ID"].ToString();
                        myprod.Posted = row["Posted"].ToString();


                        list.postedLists.Add(myprod);
                    }
                    response.AddPostedList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetReadersSpecificStory(int ID)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Project" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetReadersSpecificStory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@JakataID", SqlDbType.NVarChar).Value = ID;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        mothersHelpers myprod = new mothersHelpers();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();


                        list.mothersHelpersLists.Add(myprod);
                    }
                    response.AddMothersHelpersList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public response GetReadersStory(int JakataID, int userID)
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Project" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetReadersStory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@JakataID", SqlDbType.NVarChar).Value = JakataID;
                    cmd.Parameters.Add("@userID", SqlDbType.NVarChar).Value = userID;
                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    ReadersStoryList list = new ReadersStoryList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        readersStory myprod = new readersStory();
                        myprod.ID = row["ID"].ToString();
                        myprod.Name = row["Name"].ToString();
                        myprod.UserID = row["UserID"].ToString();
                        myprod.JakataID = row["JakataID"].ToString();
                        myprod.Comments = row["Comments"].ToString();
                        myprod.Title = row["Title"].ToString();
                        myprod.Illustrations = row["Illustrations"].ToString();
                        myprod.Readers = row["Readers"].ToString();
                        myprod.Music = row["Music"].ToString();
                        myprod.Dance = row["Dance"].ToString();
                        myprod.Admin = row["Admin"].ToString();
                        myprod.Posted = row["Posted"].ToString();
                        myprod.illustrationStartDate = row["illustrationStartDate"].ToString();
                        myprod.illustrationStopDate = row["illustrationStopDate"].ToString();
                        myprod.ReadersStartDate = row["ReadersStartDate"].ToString();
                        myprod.ReadersStopDate = row["ReadersStopDate"].ToString();
                        myprod.MusicStartDate = row["MusicStartDate"].ToString();
                        myprod.MusicStopDate = row["MusicStoptDate"].ToString();
                        myprod.DanceStartDate = row["DanceStartDate"].ToString();
                        myprod.DanceStopDate = row["DanceStopDate"].ToString();
                        myprod.postedDate = row["postedDate"].ToString();


                        list.readersStory.Add(myprod);
                    }
                    response.AddReadersStoryList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        public int Save(readersStory myStory)
        {

            var p = new DynamicParameters();


            if (myStory.Illustrations != null)
            {



                var Illustrations = myStory.Illustrations;

                Illustrations = Illustrations.Trim();

                if (Illustrations.EndsWith(","))
                {
                    Illustrations = Illustrations.Remove(Illustrations.Length - 1, 1);
                    myStory.Illustrations = Illustrations;
                }
            }

            if (myStory.Music != null)
            {

                var Music = myStory.Music;

                Music = Music.Trim();

                if (Music.EndsWith(","))
                {
                    Music = Music.Remove(Music.Length - 1, 1);
                    myStory.Music = Music;
                }
            }

            if (myStory.Dance != null)
            {

                var Dance = myStory.Dance;

                Dance = Dance.Trim();

                if (Dance.EndsWith(","))
                {
                    Dance = Dance.Remove(Dance.Length - 1, 1);
                    myStory.Dance = Dance;
                }
            }





            p.Add("@JakataID", myStory.JakataID);
            p.Add("@UserID", myStory.UserID);
            p.Add("@Title", myStory.Title);
            p.Add("@Comments", myStory.Comments);
            p.Add("@Illustrations", myStory.Illustrations);


            p.Add("@Music", myStory.Music);
            p.Add("@Dance", myStory.Dance);
            p.Add("@Admin", myStory.Admin);
            p.Add("@posted", myStory.Posted);

            p.Add("@illustrationStartDate", myStory.illustrationStartDate);
            p.Add("@illustrationStopDate", myStory.illustrationStopDate);
            p.Add("@ReadersStartDate", myStory.ReadersStartDate);
            p.Add("@ReadersStopDate", myStory.ReadersStopDate);


            p.Add("@MusicStartDate", myStory.MusicStartDate);
            p.Add("@MusicStoptDate", myStory.MusicStopDate);
            p.Add("@DanceStartDate", myStory.DanceStartDate);
            p.Add("@DanceStopDate", myStory.DanceStopDate);
            p.Add("@Mode", myStory.Mode);
            p.Add("@Readers", "");





            var conString = ConfigurationManager.ConnectionStrings["LocalStory"];
            string strConnString = conString.ConnectionString;

            int total = 0;

            using (System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(strConnString))
            {
                sqlConnection.Open();
                const string storedProcedure = "dbo.SaveProject";
                var values = sqlConnection.Query<ReceipeTotalModel>(storedProcedure, p, commandType: CommandType.StoredProcedure);
                foreach (var el in values)
                {
                    total = el.totalReceipesInt;
                }
            }

            return total;

        }



        public response GetStoryCategorytName()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Project" };
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

        public response GetStoryCategorytNameFilter()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "Project" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetStoryCategorytNameFilter", con))
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

        public response GetSpecificStoryDropdownByCategory(int id)
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
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetSpecificStoryDropdownByCategory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = id;
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

        public response GetYouTube(int JakataID,int UserID)
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

                    if (UserID != 0)
                    { 
                    cmd.Parameters.Add("@UserID", SqlDbType.NVarChar).Value = UserID;
                    }
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

        public response GetStoryCategoryNameByID(int id)
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



        public response GetSpecificStory(int ID, string mode)
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
                    cmd.Parameters.Add("@Mode", SqlDbType.NVarChar).Value = mode;
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

                        if (row["UserID"].ToString()!=null)
                        {
                            myprod.UserID = row["UserID"].ToString();
                        }

                        else
                        {

                            myprod.UserID = "0";
                        }

                        


                        list.specificStory.Add(myprod);
                    }
                    response.AddSpecificStoryList(list);

                    response.log.Add(numberOfRecords + " Records found");

                }
            }
            return response;
        }

        //public response GetSpecificStory(Story myStoryies)
        public String GetSpecificStory(Story myStoryies)
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
            string resultstring = "";

            SpecificStoryList list = new SpecificStoryList();

            if (myStoryies.AnimalType != null)
            {

                var AnimalType = myStoryies.AnimalType;

                AnimalType = AnimalType.Trim();

                if (AnimalType.EndsWith(","))
                {
                    AnimalType = AnimalType.Remove(AnimalType.Length - 1, 1);
                    myStoryies.AnimalType = AnimalType;
                }
            }


            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("GetSearchStory", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;



                    //cmd.Add("@JakataID", myStory.JakataID);
                    //cmd.Add("@StoryCategorytName", 1);
                    //cmd.Add("@Title", myStory.Title);
                    //cmd.Add("@AnimalType", myStory.AnimalType);


                    if (myStoryies.Title > 0)
                    {
                        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = myStoryies.Title;
                    }

                    if (myStoryies.JakataID > 0)
                    {
                        cmd.Parameters.Add("@JakataID", SqlDbType.Int).Value = myStoryies.JakataID;
                    }

                    if (myStoryies.UserID > 0)
                    {
                        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = myStoryies.UserID;
                    }

                    if (myStoryies.AnimalType != "0")
                    {
                        cmd.Parameters.Add("@AnimalType", SqlDbType.NVarChar).Value = myStoryies.AnimalType;
                    }

                    if (myStoryies.MoralType > 0)
                    {
                        cmd.Parameters.Add("@MoralType", SqlDbType.Int).Value = myStoryies.MoralType;

                    }

                    if (myStoryies.StoryCategorytName > 0)
                    {
                        cmd.Parameters.Add("@StoryCategorytName", SqlDbType.Int).Value = myStoryies.StoryCategorytName;

                    }



                    if (myStoryies.Comments != "0")
                    {
                        cmd.Parameters.Add("@Comments", SqlDbType.NVarChar).Value = myStoryies.Comments;
                    }

                    if (myStoryies.Stories != "0")
                    {
                        cmd.Parameters.Add("@Stories", SqlDbType.NVarChar).Value = myStoryies.Stories;
                    }


                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();

                    //return returnString;
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    //SpecificStoryList list = new SpecificStoryList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        //specificStory myprod = new specificStory();
                        resultstring = resultstring + row["ID"].ToString() + "|";


                        //list.specificStory.Add(myprod);
                    }
                    //response.AddSpecificStoryList(list);

                    //response.log.Add(numberOfRecords + " Records found");

                }
            }

            //return list;
            return resultstring;
            //return response;
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


        public response GetJakataMasterFilter()
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
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetJakataMasterFilter", con))
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