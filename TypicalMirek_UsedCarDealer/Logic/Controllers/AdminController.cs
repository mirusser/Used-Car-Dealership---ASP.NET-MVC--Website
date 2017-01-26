using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICarManager carManager;
        private readonly IBrandManager brandManager;
        private readonly ITypeManager typeManager;

        public AdminController(IManagerFactory managerFactory)
        {
            carManager = managerFactory.Get<CarManager>();
            brandManager = managerFactory.Get<BrandManager>();
            typeManager = managerFactory.Get<TypeManager>();
        }

        public ActionResult Admin(string brandName = null, string carType = null)
        {
            var cars = carManager.GetAllCars();

            if (brandName != null)
            {
                cars = cars.Where(it => it.MainData.Model.Brand.Name == brandName);
            }

            if (carType != null)
            {
                cars = cars.Where(it => it.MainData.Type.Name == carType);
            }

            cars = cars.OrderByDescending(it => it.NumberOfViews).Take(10);

            var values = new List<Values>();
            foreach (var it in cars)
            {
                values.Add(new Values
                {
                    Name = it.Id + " " + it.MainData.Model.Brand.Name + " " + it.MainData.Model.Name,
                    Value = it.NumberOfViews
                });
            }

            var parametersToAdminMenu = new ParametersToAdminMenu
            {
                Values = values,
                BrandNames = brandManager.GetAll().Select(it => it.Name),
                Cartypes = typeManager.GetAll().Select(it => it.Name)
            };

            return View(parametersToAdminMenu);
        }
    }
}