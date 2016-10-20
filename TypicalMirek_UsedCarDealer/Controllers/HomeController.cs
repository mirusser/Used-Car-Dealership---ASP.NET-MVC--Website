using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;
using TypicalMirek_UsedCarDealer.Repositories;

namespace TypicalMirek_UsedCarDealer.Controllers
{
    public class HomeController : Controller
    {
        public BaseRepository<Category, TypicalMirekEntities> BaseRepository = new BaseRepository<Category, TypicalMirekEntities>();

        public ActionResult Index()
        {
            var category = new Category()
            {
                Name = "Testowa categoria"
            };
            BaseRepository.Add(category);
            BaseRepository.Save();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}