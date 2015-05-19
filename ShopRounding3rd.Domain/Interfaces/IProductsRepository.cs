using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopRounding3rd.Domain.Entities;

namespace ShopRounding3rd.Domain.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
