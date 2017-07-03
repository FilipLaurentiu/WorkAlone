using NetRomSummerCampApp.Models;
using NetRomSummerCampApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NetRomSummerCampApp.Controllers
{
    public class EditAnnouncementController : Controller
    {
   
       [HttpGet]
        public ActionResult Close(int id)
        {
            return View();
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Close(AnnouncementAuthViewModel vm)
        {
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/CloseAnnouncement?announcementId=" + vm.Id;
            using (HttpClient httpClient = new HttpClient())
            {
                AnnouncementAuthDTO entity = new AnnouncementAuthDTO();
                entity.Email = vm.Email;


                JavaScriptSerializer serialize = new JavaScriptSerializer();
                serialize.Serialize(entity);
                var json = new JavaScriptSerializer().Serialize(entity);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.PostAsync(url, content);
                return RedirectToAction("Index","Home",null);
            }
            return View("Error");
        }



        [HttpGet]
        public ActionResult Extend(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Extend(AnnouncementAuthViewModel vm)
        {
            string url = "http://api.summercamp.stage02.netromsoftware.ro/api/announcements/ExtendAnnouncement?announcementId=" + vm.Id;

            
            using (HttpClient httpClient = new HttpClient())
            {
                AnnouncementAuthDTO entity = new AnnouncementAuthDTO();
                entity.Email = vm.Email;


                JavaScriptSerializer serialize = new JavaScriptSerializer();
                serialize.Serialize(entity);
                var json = new JavaScriptSerializer().Serialize(entity);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.PostAsync(url, content);
                return RedirectToAction("Index","Home",null);
            }
            return View("Error");
        }
    }
}