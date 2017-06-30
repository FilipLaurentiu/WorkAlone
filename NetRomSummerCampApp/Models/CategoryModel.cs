using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetRomSummerCampApp.Models
{

    public class CategoryRootobject
    {
        public Category[] Categorys { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }


  
}