using System;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TypicalMirek_UsedCarDealer.Logic.Factories;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class GaragesController : Controller
    {
        #region Properties
        private readonly IGarageManager garageManager;
        private string userId => User.Identity.GetUserId();
        #endregion

        #region Controller
        public GaragesController(ManagerFactory managerFactory)
        {
            garageManager = managerFactory.Get<GarageManager>();
        }
        #endregion

        public ActionResult Index()
        {
            var userGarage = garageManager.GetGarageByUserId(userId);
            return View(userGarage);
        }

        public ActionResult OrderCar(int? carId)
        {
            if (carId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            garageManager.OrderCar(Convert.ToInt32(carId), userId);
            return RedirectToAction("Index");
        }

        public ActionResult ShowOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var order = garageManager.GetOrderById(Convert.ToInt32(id));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //[HttpPost]
        public ActionResult ConfirmOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            garageManager.ConfirmOrder(Convert.ToInt32(id));

            return RedirectToAction("Index");
        }

        // GET: Garages/Delete/5
        public ActionResult DeleteOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = garageManager.GetOrderById(Convert.ToInt32(id));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Garages/Delete/5
        [HttpPost, ActionName("DeleteOrder")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteOrderConfirmed(int id)
        {
            var order = garageManager.GetOrderById(Convert.ToInt32(id));
            garageManager.DeleteOrderByEntity(order);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                garageManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
