using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetRomSummerCampApp.Models
{

    public class ReviewRootobject
    {
        public Review[] Reviews { get; set; }
    }

    public class Review
    {
        public int AnnouncementId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Username { get; set; }
    }

}