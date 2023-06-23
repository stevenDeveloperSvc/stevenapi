using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Username { get; set; }
        public int? Roleid { get; set; }
        public string? PasswordHash { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
