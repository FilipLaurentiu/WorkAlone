﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace NetRomSummerCampApp.Models
{
    public static class AnnouncementsContext
    {
        public static List<Announcement> GetAnnouncement()
        {
            string content = string.Empty;
            string url = "http://localhost:61005/api/announcements/";
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
            List<Announcement> result = javaScriptSerializer.Deserialize<List<Announcement>>(content);


            return result;
        }
    }
}