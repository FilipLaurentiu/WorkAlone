using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace NetRomSummerCampApp.Models
{
    public static class ReviewContext
    {
        public static List<Review> GetReviews(int announcementId)
        {
            string content = string.Empty;
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/reviews/GetByAnnouncementId?announcementId=" + announcementId;
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
            List<Review> result = javaScriptSerializer.Deserialize<List<Review>>(content);


            return result;
        }
    }
}