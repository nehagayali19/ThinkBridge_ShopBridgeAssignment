using System;
using System.Collections.Generic;

#nullable disable

namespace Shopbridge_base.Models
{
    public partial class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDesciption { get; set; }
        public string ProductColour { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
