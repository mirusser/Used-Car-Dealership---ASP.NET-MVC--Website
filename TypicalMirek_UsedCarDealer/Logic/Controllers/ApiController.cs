using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ninject.Infrastructure.Language;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class ApiController : Controller
    {
        private readonly IWebsiteContextManager websiteContextManager;
        private readonly IEmailConfigurationManager emailConfigurationManager;
        private readonly ISliderPhotoManager sliderPhotoManager;

        public ApiController(IManagerFactory managerFactory)
        {
            websiteContextManager = managerFactory.Get<WebsiteContextManager>();
            emailConfigurationManager = managerFactory.Get<EmailConfigurationManager>();
            sliderPhotoManager = managerFactory.Get<SliderPhotoManager>();
        }

        [HttpPost]
        [ValidateInput(false)] //bo niebezieczna wartość
        public ActionResult UpdateSliderPhotos(string cars, string returnUrl)
        {
            IList<int> ids = cars.Split(',').Select(int.Parse).ToEnumerable().ToList();

            //bug of Entity framwework XD must be "to_list" or "source will be open" 
            foreach (var slide in sliderPhotoManager.GetAllSlides().ToList().Where(slide => !ids.Contains(slide.CarId)))
            {
                sliderPhotoManager.Delete(slide.Id);
            }
            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateInput(false)] //bo niebezieczna wartość
        public ActionResult SavePageContent(string htmlmarkups, string site, string returnUrl)
        {
            if (!ModelState.IsValid) return Redirect(returnUrl);

            var context = websiteContextManager.GetContextByName(site);
            if (context == null)
            {
                context = new WebsiteContext
                {
                    SiteName = site,
                    Context = htmlmarkups
                };
                websiteContextManager.Add(context);
            }
            context.Context = htmlmarkups;
            websiteContextManager.Modify(context);

            return Redirect(returnUrl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendEmail(EmailFormViewModel model)
        {
            if (!ModelState.IsValid) return RedirectToAction("Contact", "Home", new { result = "Model is invalid" });
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
                return RedirectToAction("Contact", "Home", new { result = "Your message has been sent" });
            }
        }
    }
}