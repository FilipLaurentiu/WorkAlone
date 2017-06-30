using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NetRomSummerCampApp.Models
{
     public static class CategoryContext
    {
         public static List<Category> GetCategory()
        {
            string content = string.Empty;
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/categories";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse res = req.GetResponse() as HttpWebResponse)
            {
                using (Stream stream = res.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        content = reader.ReadToEnd();
                    }
                }
            }


            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<Category> result = javaScriptSerializer.Deserialize<List<Category>>(content);


           
           
            return result;
        }
    }
}