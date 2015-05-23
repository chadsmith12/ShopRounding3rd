using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopRounding3rd.Domain.Entities;

namespace ShopRounding3rd.Web.Models
{
    public class CartIndexViewModel
    {
        /// <summary>
        /// our current shopping cart
        /// </summary>
        public Cart Cart { get; set; }

        /// <summary>
        /// The URL we need to return too when clicking "Continue Shopping"
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}