using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class GetPhotoController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        //[OutputCache(CacheProfile = "SliderImages")]
        public FileResult Car(int id)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Car/" + id + ".jpg");
            return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
        }

        [AcceptVerbs(HttpVerbs.Get)]
        //[OutputCache(CacheProfile = "SliderImages")]
        public FileResult SliderIcon(string name, string extension)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Slider/" + name + "." + extension);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name + "." + extension);
        }
    }
}