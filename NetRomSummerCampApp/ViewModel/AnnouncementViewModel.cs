using NetRomSummerCampApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetRomSummerCampApp.ViewModel
{
    public class AnnouncementViewModel
    {
        [Required]
        [StringLength(16)]
        [Display(Name ="Phone Number")]
        public string Phonenumber { get; set; }

        [Required]
        [StringLength(64)]
        public string Email { get; set; }

        public string Description { get; set; }

        [Required]
        [StringLength(64)]
        public string Title { get; set; }

        public List<Category> Categorys { get; } = CategoryContext.GetCategory();


        public int CategoryId { get; set; }
    }
}