using System;
using System.Collections.Generic;

namespace farmLab05.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public float Price { get; set; }

        public static implicit operator Products?(List<Products>? v)
        {
            throw new NotImplementedException();
        }
    }
}
