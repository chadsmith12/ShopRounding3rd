using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopRounding3rd.Domain.Interfaces;

namespace ShopRounding3rd.Web.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductsRepository _productRepo;

        #region Constructors

        public NavController(IProductsRepository productRepo)
        {
            this._productRepo = productRepo;
        }
        #endregion

        /// <summary>
        /// Returns a partial view of all the products rendered inside
        /// </summary>
        /// <param name="category">The category the user has selected</param>
        /// <returns></returns>
        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            // create a list of categories
            IEnumerable<string> categories = _productRepo.Products.Select(x => x.Category).Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}