using NetRomSummerCampApp.Models;
using NetRomSummerCampApp.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NetRomSummerCampApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Category> categorys = CategoryContext.GetCategory();

            List<Announcement> announcements = AnnouncementsContext.GetAnnouncement();
            Tuple<List<Category>, List<Announcement>> tup = new Tuple<List<Category>, List<Announcement>>(categorys, announcements);

            return View(tup);
        }



        public ActionResult Search(FiltredCategory id)
        {
            List<Category> categorys = CategoryContext.GetCategory();

            List<Announcement> announcements = AnnouncementsContext.GetAnnouncement().Where(x=>x.CategoryName == id.FilterCategoryId).ToList();
            FiltredCategory filter = new FiltredCategory();
            Tuple<List<Category>, List<Announcement>, FiltredCategory> tup = new Tuple<List<Category>, List<Announcement>, FiltredCategory>(categorys, announcements, filter);

            return View("Index",tup);
        }



        [HttpGet]
        public ActionResult CreateAnnouncement()
        {
            
            return View(new AnnouncementViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnnouncement(AnnouncementViewModel vm)
        {
            if (ModelState.IsValid)
            {

                AnnouncementCreateDTO entity = new AnnouncementCreateDTO
                {
                    CategoryId = vm.CategoryId,
                    Title = vm.Title,
                    Description = vm.Description,
                    Email = vm.Email,
                    Phonenumber = vm.Phonenumber
                };
                string url = "http://localhost:61005/api/announcements/NewAnnouncement";
                using (HttpClient httpClient = new HttpClient())
                {
                    JavaScriptSerializer serialize = new JavaScriptSerializer();
                    serialize.Serialize(entity);
                    var json = new JavaScriptSerializer().Serialize(entity);

                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpClient client = new HttpClient();
                   
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    
                    return RedirectToAction("Index");
                }
            }

            return View("Error");
        }

    }



}