using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRounding3rd.Domain.Entities
{
    public class Cart
    {
        #region Private Fields
        /// <summary>
        /// Actual Shopping Cart - Collection of all the products, and how many of those products we have
        /// </summary>
        private List<CartLine> shoppingCart = new List<CartLine>();
        #endregion

        #region Methods
        /// <summary>
        /// Adds a product, and how many we are buying of that product to the shopping cart
        /// </summary>
        /// <param name="product">product customer is buying</param>
        /// <param name="quantity">how many of the products the customer is buying</param>
        public void AddItem(Product product, int quantity)
        {
            // try to grab a product that is the product we are trying to add
            CartLine line = shoppingCart.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            // we didn't grab a product, add this product to the list
            if (line == null)
            {
                shoppingCart.Add(new CartLine {Product = product, Quantity = quantity});
            }
            // just update the quantity
            else
            {
                line.Quantity += quantity;
            }
        }

        /// <summary>
        /// Remove all the products from the shopping cart
        /// </summary>
        /// <param name="product">The product that we are trying to remove all</param>
        public void RemoveLine(Product product)
        {
            shoppingCart.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        /// <summary>
        /// Clears/Empties the shopping cart
        /// </summary>
        public void Clear()
        {
            shoppingCart.Clear();
        }
        #endregion

        #region Properties
        /// <summary>
        /// The total value of the shopping cart
        /// For every product we mulity it's price by how many they are buying
        /// </summary>
        public decimal Total
        {
            get { return shoppingCart.Sum(e => e.Product.Price*e.Quantity); }
        }

        /// <summary>
        /// Gets the actual shopping cart
        /// </summary>
        public IEnumerable<CartLine> ShoppingCart
        {
            get { return shoppingCart; }
        } 

        #endregion


    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
