using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopbridge_base.Domain.Models
{
    public class UpdateProduct
    {
        public string ProductName { get; set; }
        public string ProductDesciption { get; set; }
        public string ProductColour { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
