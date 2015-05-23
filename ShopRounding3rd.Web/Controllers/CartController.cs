using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopRounding3rd.Domain.Entities;
using ShopRounding3rd.Domain.Interfaces;
using ShopRounding3rd.Web.Models;

namespace ShopRounding3rd.Web.Controllers
{
    public class CartController : Controller
    {
        #region Private Fields
        private readonly IProductsRepository _productsRepository;

        #endregion

        #region Constructors
        public CartController(IProductsRepository productsRepository)
        {
            this._productsRepository = productsRepository;
        }
        #endregion

        #region Methods

        public ViewResult ViewCart(string returnUrl)
        {
            return View(new CartIndexViewModel { Cart = GetCart(), ReturnUrl = returnUrl });
        }

        
        [HttpPost]
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = _productsRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                // add an item to the cart here
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("ViewCart","Cart", new {returnUrl});
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _productsRepository.Products.FirstOrDefault(p => p.ProductId == productId);

            if (product != null)
            {
                // remove the product from the cart
                GetCart().RemoveLine(product);
            }

            return RedirectToAction("ViewCart","Cart", new { returnUrl});
        }

        public PartialViewResult Summary()
        {
            var cart = GetCart();
            return PartialView("_Summary", cart);
        }
        #endregion


        #region Private Methods
        /// <summary>
        /// Gets the current users Cart session, or creates a new Cart session if their isn't one
        /// </summary>
        /// <returns>The Cart session</returns>
        private Cart GetCart()
        {
            var cart = (Cart) Session["Cart"];
            if (cart != null) return cart;

            cart = new Cart();
            Session["Cart"] = cart;
            return cart;
        }
        #endregion
    }
}