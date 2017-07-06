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
        [Required(ErrorMessage = "Please enter a title for announcement")]
        [StringLength(64)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Plese enter a phone number")]
        [StringLength(16)]
        [Display(Name ="Phone Number")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage ="This field is required")]
        [StringLength(64)]
        public string Email { get; set; }

        public string Description { get; set; }

     

        public List<Category> Categorys { get; set; } 


        public int CategoryId { get; set; }
    }


}