using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Product1 { get; set; }
        public string? Category { get; set; }
        public double? Price { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
