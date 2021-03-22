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

namespace Stories.Factory
{
    public class GetStories
    {
        public static List<string> romanNumerals = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
        public static List<int> numerals = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        // Maps letters to numbers.
        private Dictionary<char, int> CharValues = null;

        private void LogEntry(string text)
        {
            //var folder = @"C:\Users\Richard\Google Drive\projects\SlideShow\WebApplication2\App_Data";
            var folder = @"C:\Users\Richard\Google Drive\WebSites\kylah\App_Data";
            var logfilename = $@"{folder}\logs.txt";
            if (System.IO.Directory.Exists(folder))
                System.IO.File.AppendAllText(logfilename, $"{DateTime.Now}\t{text}\r\n");
        }

        public string GetUpdateBackgroundSound()
        {

            var dataTable = new DataTable();
            dataTable = new DataTable { TableName = "UpdateBackgroundSound" };
            //var conString1 = ConfigurationManager.ConnectionStrings["LocalEvolution"];
            //string connString = conString1.ConnectionString;
            string connString = URLInfo.GetDataBaseConnectionString();
            LogEntry("***************connString***********"+connString);//replace with something like Serilog


            System.IO.StringWriter writer = new System.IO.StringWriter();
            string returnString = "";
            response response = new response();
            response.result = 0;

            string fileName = "";
            using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connString))
            {
                using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("GetUpdateBackgroundSound", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    var dataReader = cmd.ExecuteReader();
                    dataTable.Load(dataReader);
                    dataTable.WriteXml(writer, XmlWriteMode.WriteSchema, false);
                    returnString = writer.ToString();
                    int numberOfRecords = dataTable.Rows.Count;
                    response.result = numberOfRecords;



                    //MothersHelpersList list = new MothersHelpersList();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        //mothersHelpers myprod = new mothersHelpers();
                        //myprod.ID = row["ID"].ToString();
                        //myprod.Name = row["Name"].ToString();
                        fileName = row["fileName"].ToString();


                        //list.mothersHelpersLists.Add(myprod);
                    }
                    //response.AddMothersHelpersList(list);

                    //response.log.Add(numberOfRecords + " Records found");

                }
            }
            return fileName;
        }


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

        
    }
}