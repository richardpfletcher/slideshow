using Dapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Mvc;
using Stories.Factory;
using Stories.Models;
using System;

namespace Jataka.Controllers
{
    public class MyFavortiesController : Controller
    {
        // GET: MyFavorties
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PdfResultsView(string all)
        {

            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();
                Story modelStory = new Story();
                DropdownModel model = new DropdownModel();

                //Create a single column table
                var t = new PdfPTable(1);

                //Tell it to fill the page horizontally
                t.WidthPercentage = 100;

                //Create a single cell
                var c = new PdfPCell();

                //Tell the cell to vertically align in the middle
                c.VerticalAlignment = Element.ALIGN_MIDDLE;

                //Tell the cell to fill the page vertically
                c.MinimumHeight = document.PageSize.Height - (document.BottomMargin + document.TopMargin);

                //Create a test paragraph
                //var p = new Paragraph("                    EBook Custom Favorite Recipes from whatscookingtreasures.com");
                //Add it a couple of times
                //c.AddElement(p);

                var imagePath1 = Server.MapPath("~/content/album.jpg");

                iTextSharp.text.Image pic1 = iTextSharp.text.Image.GetInstance(imagePath1);
                //pic1.BorderWidth = 0;
                pic1.BorderColor = Color.WHITE;

                c.AddElement(pic1);

                //Add the cell to the paragraph
                t.AddCell(c);

                //Add the table to the document
                document.Add(t);
                document.NewPage();



                string[] rowschosen = all.Split('|');
                int length = rowschosen.Length;

                for (int i = 0; i < length; i++)
                {
                    var jatakaID = Convert.ToInt16(rowschosen[i]);
                    GetLookups myGetLookups = new GetLookups();

                    modelStory = myGetLookups.GetSpecificStory(jatakaID);
                    var Stories = modelStory.Stories;

                    Paragraph para = new Paragraph(Stories);
                    para.Font = FontFactory.GetFont(FontFactory.HELVETICA, 14f);
                    document.Add(para);
                    if (i != length-1)
                    {
                        document.NewPage();
                    }
                    
                }

             

                document.Close();
                byte[] bytes = memoryStream.ToArray();
                memoryStream.Close();
                Response.Clear();
                Response.ContentType = "application/pdf";

                string pdfName = "User";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + pdfName + ".pdf");
                Response.ContentType = "application/pdf";
                Response.Buffer = true;
                Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
                Response.BinaryWrite(bytes);
                Response.End();
                Response.Close();
            }

            //using (MemoryStream ms = new MemoryStream())
            //using (Document document = new Document(PageSize.A4, 25, 25, 30, 30))
            //using (PdfWriter writer = PdfWriter.GetInstance(document, ms))
            //{
            //    document.Open();

            //    document.NewPage();


            //    //Create a single column table
            //    var t = new PdfPTable(1);

            //    //Tell it to fill the page horizontally
            //    t.WidthPercentage = 100;

            //    //Create a single cell
            //    var c = new PdfPCell();

            //    //Tell the cell to vertically align in the middle
            //    c.VerticalAlignment = Element.ALIGN_MIDDLE;

            //    //Tell the cell to fill the page vertically
            //    c.MinimumHeight = document.PageSize.Height - (document.BottomMargin + document.TopMargin);

            //    //Create a test paragraph
            //    //var p = new Paragraph("                    EBook Custom Favorite Recipes from whatscookingtreasures.com");
            //    //Add it a couple of times
            //    //c.AddElement(p);

            //    var imagePath1 = Server.MapPath("~/images/worldmap3.jpg");
            //    iTextSharp.text.Image pic1 = iTextSharp.text.Image.GetInstance(imagePath1);
            //    c.AddElement(pic1);

            //    //Add the cell to the paragraph
            //    t.AddCell(c);

            //    //Add the table to the document
            //    document.Add(t);

            //    var rows = all;

            //    rows = all.Trim();

            //    if (rows.EndsWith("|"))
            //    {
            //        rows = rows.Remove(rows.Length - 1, 1);
            //    }
            //    //ViewData["all"] = rows;
            //    Story modelStory = new Story();
            //    DropdownModel model = new DropdownModel();


            //    string[] rowschosen = rows.Split('|');
            //    int length = rowschosen.Length;

            //    for (int i = 0; i < length; i++)
            //    {
            //        var jatakaID = Convert.ToInt16(rowschosen[i]);
            //        GetLookups myGetLookups = new GetLookups();

            //        modelStory = myGetLookups.GetSpecificStory(jatakaID);
            //        var Stories = modelStory.Stories;

            //        document.NewPage();
            //        //define a bold font to be used
            //        Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            //        var phrase = new Phrase();
            //        phrase.Add(new Chunk(s.Title, boldFont));
            //        Paragraph paragraph1 = new Paragraph();

            //        paragraph1.Add(phrase);

            //        document.Add(paragraph1);

            //        PdfPTable table = new PdfPTable(2);
            //        table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;




            //        Paragraph paragraphBreak = new Paragraph();
            //        paragraphBreak.Add("   ");
            //        document.Add(paragraphBreak);
            //        //document.Add(paragraphBreak);




            //        string comments = Stories;
            //        //comments = HttpUtility.HtmlDecode(comments);

            //        if (comments.Length > 0)
            //        {
            //            StringWriter myWriter = new StringWriter();

            //            // Decode the encoded string.
            //            HttpUtility.HtmlDecode(comments, myWriter);
            //            comments = myWriter.ToString();

            //            MemoryStream memStream = new MemoryStream();
            //            TextReader xmlString = new StringReader(comments);
            //            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(comments);
            //            MemoryStream msComments = new MemoryStream(byteArray);
            //            XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, msComments, System.Text.Encoding.UTF8);
            //        }

            //        document.Add(paragraphBreak);
            //        //document.Add(paragraphBreak);


            //            document.Add(table);
            //            //document.Add(new Paragraph(IngredHTML));
            //        }




            //    }

            //    document.Close();
            //    writer.Close();
            //    ms.Close();
            //    Response.ContentType = "pdf/application";
            //    Response.AddHeader("content-disposition", "attachment;filename=whatscookingtreasures_PDF_document.pdf");
            //    Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            //}

            //return View("PdfResultsView");
            return View();



        }
    }
}
