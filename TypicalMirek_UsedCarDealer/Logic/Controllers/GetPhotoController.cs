using System.IO;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class GetPhotoController : Controller
    {
        private readonly IWebsiteContextManager websiteContextManager;

        public GetPhotoController(IManagerFactory managerFactory)
        {
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult GetCarImage(string imageName)
        {
            var path = getImagePath(imageName);
            return File(path, "image/jpeg/png/PNG/jpg");
        }

        private string getImagePath(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                imageName = "empty";
            }
            var path = Path.Combine(Server.MapPath("~/App_Data/Images"), imageName);
            return Path.GetFullPath(path);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public FileResult SliderIcon(string name, string extension)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Slider/" + name + "." + extension);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name + "." + extension);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public FileResult HeaderImage(string name, string extension)
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Header/" + name + "." + extension);
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, name + "." + extension);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public FileResult Favicon()
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Favicon/favicon.ico");
            byte[] fileBytes = System.IO.File.ReadAllBytes(path);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, "favicon.ico");
        }
    }
}