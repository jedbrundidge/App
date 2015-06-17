using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewTry.Models;
using iTextSharp.text;

namespace NewTry.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        /// <summary>
        /// I have made dummy table accordinng to fields
        /// then getthat data base in visual studio by adding connection to that data base
        /// I have generated entity model using entity frame work from  that table
        /// gets data from that table using entity query
        ///  and then set fields and output file is ewfw4.pdf which contains  filled fields
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {

           Models.ApplicationEntities cx = new Models.ApplicationEntities();
            Models.W4 obj = new Models.W4();

            string template = @"c:\users\carisch\documents\visual studio 2013\Projects\NewTry\NewTry\fw4.pdf";
            string newFile = @"c:\users\carisch\documents\visual studio 2013\Projects\NewTry\NewTry\Newfw4.pdf";

            PdfReader reader = new PdfReader(template);
            Document document = new Document();
            MemoryStream ms = new MemoryStream();
            // PdfWriter writer = new PdfWriter(newFile, template);

            PdfStamper stamper = new PdfStamper(reader, new FileStream(newFile, FileMode.Create));
            AcroFields fields = stamper.AcroFields;

            //NewTryContext context = new NewTryContext();


            //getting data from tables
            var query = (from c in cx.W4
                         where c.ID == 4
                         select c);

            foreach (var x in query)
            {
                obj = x;
            }

            //setting data to fields
            fields.SetExtraMargin((float)10.5, (float)0);
            fields.SetFieldProperty("f1_09_0_", "textcolor", Color.BLACK, null);
           // fields.SetField("f1_09_0_", obj.First_Name_Differs.ToString() + " " + obj.Middle_Name_Differs.ToString());

            fields.SetField("f1_10_0_", obj.Last_Name_Differs.ToString());
            bool chek = fields.SetFieldProperty("f1_10_0_", "textcolor", 0, null);
            //fields.SetField("f1_11_0_", obj.Address.ToString());
            fields.SetFieldProperty("f1_11_0_", "textcolor", Color.BLACK, null);
            //fields.SetField("f1_12_0_", obj.city.ToString() + ", " + obj.code.ToString() + ", " + obj.state.ToString());
            fields.SetFieldProperty("f1_12_0_", "textcolor", Color.BLACK, null);
            fields.SetField("f1_13_0_", obj.Applicant_ID.ToString());
            fields.SetFieldProperty("f1_13_0_", "textcolor", Color.BLACK, null);
            fields.SetFieldProperty("f1_15_0_", "textcolor", Color.BLACK, null);
            fields.SetField("f1_15_0_", obj.Additional_Amount.ToString());
            fields.SetField("f1_14_0_", obj.Number_Of_Allowances.ToString());

            //fields.SetFieldProperty("f1_09_0_","FontColor",0)
            stamper.FormFlattening = false;
            stamper.Close();

            File(@"c:\users\carisch\documents\visual studio 2013\Projects\NewTry\NewTry\Newfw4.pdf", "application/pdf");
            return View();

        }
    }
}