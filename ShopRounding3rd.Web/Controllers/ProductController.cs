using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopRounding3rd.Domain.Interfaces;

namespace ShopRounding3rd.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _productRepo;

        public ProductController(IProductsRepository productRepo)
        {
            this._productRepo = productRepo;
        }

        public ViewResult List()
        {
            return View(_productRepo.Products);
        }
    }
}