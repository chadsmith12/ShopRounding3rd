﻿using System.Linq;
using System.Web.Mvc;
using ShopRounding3rd.Domain.Interfaces;
using ShopRounding3rd.Web.Models;

namespace ShopRounding3rd.Web.Controllers
{
    public class ProductController : Controller
    {
        readonly private IProductsRepository _productRepo;
        public int PageSize = 4;

        public ProductController(IProductsRepository productRepo)
        {
            this._productRepo = productRepo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category">the category we are filtering the list by</param>
        /// <param name="page">The current page we are currently on in the list</param>
        /// <returns></returns>
        public ViewResult List(string category, int page = 1)
        {
            // order products by primary key, skip over any products that occur befor the current page we are on, and take the number of products needed
            // EXAMPLE: page = 1: (1-1) * 4 = 0 means don't skip any products
            // page = 2: (2-1) * 4 = 4 means skip first the first objects, we are on page 2
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _productRepo.Products.Where(x => category == null || x.Category.ToLower() == category.ToLower()).OrderBy(p => p.ProductId).Skip((page - 1)*PageSize).Take(PageSize),
                PagingInfo =
                    new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ? _productRepo.Products.Count() : _productRepo.Products.Count(e => e.Category == category)
                    },
                    CurrentCategory = category,
                    
            };

            return View(model);
        }
    }
}