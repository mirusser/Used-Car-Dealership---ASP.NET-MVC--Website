using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderPhotoManager sliderPhotoManager;
        private readonly ICarManager carManager;
        private readonly IBrandManager brandManager;
        private readonly ISourceOfEnergyRepository sourceOfEnergyRepository;
        private readonly IEmailConfigurationManager emailConfigurationManager;
        private readonly IWebsiteContextManager websiteContextManager;

        public HomeController(IManagerFactory managerFactory)
        {
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            sourceOfEnergyRepository = new SourceOfEnergyRepository();
            emailConfigurationManager = managerFactory.Get<EmailConfigurationManager>();
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
        }

        public ActionResult Index()
        {
            var parameters = new ParametersToHome
            {
                Slider = new List<CarPhotoViewModel>(),
                HotCars = new List<CarPhotoViewModel>(),
                NewCars = new List<CarPhotoViewModel>()
            };

            foreach (var it in sliderPhotoManager.GetAllSlides())
            {
                parameters.Slider.Add(new CarPhotoViewModel
                {
                    imageName = sliderPhotoManager.GetName(it.CarPhotoId),
                    description = it.Car.MainData.Model.Brand.Name + " " + it.Car.MainData.Model.Name,
                    carId = it.Car.Id,
                    price = it.Car.Price
                });
            }

            var hotCars = carManager.GetAllCars().Where(it => it.Photos.Count > 0 && it.DeleteTime == null).OrderByDescending(it => it.NumberOfViews).Take(8);

            foreach (var it in hotCars)
            {
                parameters.HotCars.Add(new CarPhotoViewModel
                {
                    imageName = it.Photos.First().Name,
                    description = it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
                    carId = it.Id,
                    price = it.Price
                });
            }

            var newCars = carManager.GetAllCars().Where(it => it.Photos.Count > 0 && it.DeleteTime == null).OrderByDescending(it => it.AddTime).Take(8);
            foreach (var it in newCars)
            {
                parameters.NewCars.Add(new CarPhotoViewModel
                {
                    imageName = it.Photos.First().Name,
                    description = it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
                    carId = it.Id,
                    price = it.Price
                });
            }

            parameters.BrandList = brandManager.GetAll().Select(it => it.Name);

            parameters.FuelTypeList = sourceOfEnergyRepository.GetAll().Select(it => it.Name);

            return View(parameters);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string result = null)
        {
            var context = websiteContextManager.GetContextByName("Contact");
            string content = null;
            if (context != null)
            {
                content = context.Context;
            }

            var parametersToContact = new ParametersToContact
            {
                Result = result,
                Content = content
            };
            return View(parametersToContact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(EmailFormViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Contact", "Home", new { result = "Model is invalid"});
            var activeConfiguration = emailConfigurationManager.GetActive();
            if (activeConfiguration == null)
            {
                return RedirectToAction("Contact", "Home", new { result = "There is no active configurationon database" });
            }

            const string body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(activeConfiguration.To));
            message.From = new MailAddress(activeConfiguration.From);
            message.Subject = "Message from customer";
            message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = activeConfiguration.Username,
                    Password = activeConfiguration.Password
                };
                smtp.Credentials = credential;
                smtp.Host = activeConfiguration.Host;
                smtp.Port = activeConfiguration.Port;
                smtp.EnableSsl = activeConfiguration.EnableSsl;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Contact", "Home", new { result = "Your message has been sent"});
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult EditContact()
        {
            var context = websiteContextManager.GetContextByName("Contact");

            var parameters = new ParametersToWysiwyg
            {
                ActionNameForPost = "SaveContact",
                ControllerNameForPost = "Home",
                Context = context?.Context
            };

            return View(parameters);
        }

        [HttpPost]
        [ValidateInput(false)] //bo niebezieczna wartość
        public ActionResult SaveContact(string htmlmarkups)
        {
            if(!ModelState.IsValid) return RedirectToAction("EditContact", "Home");

            var context = websiteContextManager.GetContextByName("Contact");
            if (context == null)
            {
                context = new WebsiteContext
                {
                    Id = 1,
                    SiteName = "Contact",
                    Context = htmlmarkups
                };
                websiteContextManager.Add(context);
            }
            context.Context = htmlmarkups;
            websiteContextManager.Modify(context);

            return RedirectToAction("EditContact", "Home");
        }
    }
}