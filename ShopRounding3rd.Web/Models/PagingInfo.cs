using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRounding3rd.Web.Models
{
    /// <summary>
    /// PagingInfo View Model
    /// Model that is used to for paging
    /// </summary>
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/ItemsPerPage); }
        }
    }
}
