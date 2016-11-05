using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Helpers
{
    public static class SelectListItemHelper
    {
        /// <summary>
        /// Returns the SelectListItem from repository
        /// </summary>
        /// <typeparam name="T">Model class that implements BasicModel</typeparam>
        /// <param name="repository">Repository that implements IBaseRepository</param>
        /// <returns>SelectListItem</returns>
        public static IQueryable<SelectListItem> GetSelectListItem<T>(IBaseRepository<T> repository) where T : BasicModel
        {
            return repository.GetAll().Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}